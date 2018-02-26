namespace TwinCatAdsCommunication
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TwinCAT.Ads;

    public sealed class ConnectedWriteClient : IDisposable, IConnectedClient
    {
        private readonly TcAdsClient client;
        private CancellationTokenSource cancellationTokenSource;
        private bool disposed;
        private Task eternalTask;

        private ConnectedWriteClient()
        {
            this.client = new TcAdsClient();
        }

        public static ConnectedWriteClient CreateAndConnect(AmsNetId id, int port)
        {
            var connectedClient = new ConnectedWriteClient();
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

        public void StartCyclicWriting(PlcWriter plcReader, TimeSpan readCycle)
        {
            this.ThrowIfDisposed();
            if (this.cancellationTokenSource != null)
            {
                throw new InvalidOperationException("Reading is already started");
            }

            var cancelCycle = new CancellationTokenSource();
            this.eternalTask = Task.Run(
                async () =>
                {
                    while (true)
                    {
                        using (plcReader.BatchWrite(this.client))
                        {
                            await Task.Delay(readCycle, cancelCycle.Token);
                        }
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
