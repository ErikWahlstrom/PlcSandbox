namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TwinCAT.Ads;

    public sealed class ConnectedClient : IDisposable
    {
        private readonly TcAdsClient client;
        private readonly List<CancellationTokenSource> tasks;
        private bool disposed;

        private ConnectedClient()
        {
            this.client = new TcAdsClient();
            this.tasks = new List<CancellationTokenSource>();
        }

        public static ConnectedClient CreateAndConnect(AmsNetId id, int port)
        {
            var connectedClient = new ConnectedClient();
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

        public void StartCyclicReading(PlcReader plcReader, TimeSpan readCycle)
        {
            this.ThrowIfDisposed();
            var cancelCycle = new CancellationTokenSource();
            Task.Run(
                async () =>
                {
                    plcReader.ReadToAllValues(this.client);
                    await Task.Delay(readCycle, cancelCycle.Token);
                }, cancelCycle.Token);

            this.tasks.Add(cancelCycle);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            foreach (var cancellationToken in this.tasks)
            {
                cancellationToken.Cancel();
            }

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
