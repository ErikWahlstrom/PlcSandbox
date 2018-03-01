namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using TwinCAT.Ads;

    public sealed class ConnectedReadClient : IDisposable, IConnectedClient
    {
        private readonly TcAdsClient client;
        private readonly IList<IReadableAddress> addresses;
        private readonly IList<IReadableAddress> unConnectedAddresses;
        private readonly TimeSpan readCycle;
        private CancellationTokenSource cancellationTokenSource;
        private bool disposed;
        private Task eternalTask;

        private ConnectedReadClient(TimeSpan cycle)
        {
            this.client = new TcAdsClient();
            this.addresses = new List<IReadableAddress>();
            this.unConnectedAddresses = new List<IReadableAddress>();
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

            var info = this.client.ReadSymbolInfo(name);
            if (info == null)
            {
                throw new InvalidOperationException($"Address does not exist in PLC: {name}");
            }

            return info;
        }

        public void RegisterForCyclicReading(IReadableAddress readableAddress)
        {
            this.ThrowIfDisposed();
            this.unConnectedAddresses.Add(readableAddress);

            if (this.eternalTask == null)
            {
                var cancelCycle = new CancellationTokenSource();
                this.eternalTask = Task.Run(
                    async () =>
                    {
                        while (true)
                        {
                            this.ConnectedUnconnectedAddresses();
                            if (this.addresses.Count > 0)
                            {
                                PlcReader.ReadToAllValues(this.client, this.addresses);
                            }
                            await Task.Delay(this.readCycle, cancelCycle.Token);
                        }

                        // ReSharper disable once FunctionNeverReturns
                    }, cancelCycle.Token);

                this.cancellationTokenSource?.Dispose();
                this.cancellationTokenSource = cancelCycle;
            }
        }

        private void ConnectedUnconnectedAddresses()
        {
            if (this.unConnectedAddresses.Count < 1)
            {
                return;
            }

            foreach (var readableAddress in this.unConnectedAddresses)
            {
                try
                {
                    readableAddress.Address = readableAddress.UnconnectedAddress.GetConnectedAddress(this);
                }
                catch (Exception e)
                {
                    readableAddress.Error = AdsErrorCode.DeviceSymbolNotFound;
                    Console.WriteLine(e);
                }

                if (readableAddress.Address != null)
                {
                    this.addresses.Add(readableAddress);
                }
            }

            var connectedFromUnconnected = this.unConnectedAddresses.Where(x => x.Address != null).ToArray();

            for (var index = 0; index < connectedFromUnconnected.Length; index++)
            {
                var removeAddress = connectedFromUnconnected[index];
                this.unConnectedAddresses.Remove(removeAddress);
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
