namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TwinCAT.Ads;

    public sealed class ConnectedWriteClient : IDisposable, IConnectedClient
    {
        private readonly TcAdsClient client;
        private readonly TimeSpan cycleTime;
        private readonly IList<IWritableAddress> addresses;
        private CancellationTokenSource cancellationTokenSource;
        private bool disposed;
        private Task eternalTask;
        private IList<IWritableAddress> unConnectedAddresses;

        private ConnectedWriteClient(TimeSpan cycleTime)
        {
            this.client = new TcAdsClient();
            this.cycleTime = cycleTime;
            this.unConnectedAddresses = new List<IWritableAddress>();
            this.addresses = new List<IWritableAddress>();
        }

        public static ConnectedWriteClient CreateAndConnect(AmsNetId id, int port, TimeSpan cycleTime)
        {
            var connectedClient = new ConnectedWriteClient(cycleTime);
            connectedClient.client.Connect(id, port);
            return connectedClient;
        }

        public ITcAdsSymbol ReadSymbolInfo(string name)
        {
            this.ThrowIfDisposed();
            if (this.client.IsConnected)
            {
                this.client.Connect(this.client.Address);
            }

            return this.client.ReadSymbolInfo(name);
        }

        public void RegisterCyclicWriting(IWritableAddress address)
        {
            this.ThrowIfDisposed();
            this.unConnectedAddresses.Add(address);
            var cancelCycle = new CancellationTokenSource();
            this.eternalTask = Task.Run(
                async () =>
                {
                    while (true)
                    {
                        if (this.addresses.Count > 0)
                        {
                            PlcWriter.WriteAllValues(this.client, this.addresses);
                        }
                        await Task.Delay(this.cycleTime, cancelCycle.Token);
                    }

                    // ReSharper disable once FunctionNeverReturns
                }, cancelCycle.Token);

            this.cancellationTokenSource?.Dispose();
            this.cancellationTokenSource = cancelCycle;
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
