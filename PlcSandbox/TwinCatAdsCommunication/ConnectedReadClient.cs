namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using TwinCAT.Ads;

    public sealed class ConnectedReadClient : IDisposable, IConnectedClient
    {
        private readonly TcAdsClient client;
        private readonly IList<IReadableAddress> addresses;
        private readonly IList<IReadableAddress> unConnectedAddresses;
        private readonly IDisposable disposable;
        private bool disposed;

        private ConnectedReadClient(TimeSpan cycle)
        {
            this.client = new TcAdsClient();
            this.addresses = new List<IReadableAddress>();
            this.unConnectedAddresses = new List<IReadableAddress>();
            this.disposable = Observable.Interval(cycle).Subscribe(_ =>
            {
                this.ConnectedUnconnectedAddresses();
                if (this.addresses.Count > 0)
                {
                    PlcReader.ReadToAllValues(this.client, this.addresses);
                }
            });
        }

        public static ConnectedReadClient CreateAndConnect(AmsNetId id, int port, TimeSpan readCycle)
        {
            var connectedClient = new ConnectedReadClient(readCycle);
            connectedClient.client.Connect(id.ToString(), port);
            return connectedClient;
        }

        public VariableHandleAndSize ReadSymbolInfo(string name)
        {
            return this.client.ReadSymbolInfoAds(name);
        }

        public void RegisterForCyclicReading(IReadableAddress readableAddress)
        {
            this.ThrowIfDisposed();
            this.unConnectedAddresses.Add(readableAddress);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.client.Dispose();
            this.disposable?.Dispose();
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
                    readableAddress.Exception = null;
                }
                catch (Exception e)
                {
                    readableAddress.Exception = e;
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

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
}
