namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TwinCAT.Ads;

    public sealed class ConnectedReadClient : IDisposable, IConnectedClient
    {
        private readonly TcAdsClient client;
        private CancellationTokenSource cancellationTokenSource;
        private bool disposed;
        private Task eternalTask;
        private IList<IReadableAddress> addresses;
        private readonly TimeSpan readCycle;

        private ConnectedReadClient(TimeSpan cycle)
        {
            this.client = new TcAdsClient();
            this.addresses = new List<IReadableAddress>();
            this.readCycle = cycle;
        }

        public static ConnectedReadClient CreateAndConnect(AmsNetId id, int port, TimeSpan readCycle)
        {
            var connectedClient = new ConnectedReadClient(readCycle);
            connectedClient.client.Connect(id.ToString(), port);
            return connectedClient;
        }

        public ITcAdsSymbol ReadSymbolInfo(string name)
        {
            this.ThrowIfDisposed();
            if (!this.client.IsConnected)
            {
                this.client.Connect(this.client.Address);
            }

            return this.client.ReadSymbolInfo(name);
        }

        public void RegisterForCyclicReading(IReadableAddress readableAddress)
        {
            this.ThrowIfDisposed();
            this.addresses.Add(readableAddress);

            if (this.eternalTask == null)
            {
                var cancelCycle = new CancellationTokenSource();
                this.eternalTask = Task.Run(
                    async () =>
                    {
                        while (true)
                        {
                            PlcReader.ReadToAllValues(this.client, this.addresses);
                            await Task.Delay(this.readCycle, cancelCycle.Token);
                        }

                        // ReSharper disable once FunctionNeverReturns
                    }, cancelCycle.Token);

                this.cancellationTokenSource?.Dispose();
                this.cancellationTokenSource = cancelCycle;
            }
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.cancellationTokenSource.Cancel();
            this.eternalTask.Wait(TimeSpan.FromSeconds(10));
            this.client.Dispose();
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
}
