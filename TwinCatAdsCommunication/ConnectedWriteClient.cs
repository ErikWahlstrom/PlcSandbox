namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using TwinCAT.Ads;

    public sealed class ConnectedWriteClient : IDisposable, IConnectedClient
    {
        private readonly TcAdsClient client;
        private readonly TimeSpan cycleTime;
        private readonly IList<IWritableAddress> addresses;
        private readonly IDisposable disposable;
        private bool disposed;
        private IList<IWritableAddress> unConnectedAddresses;

        private ConnectedWriteClient(TimeSpan cycleTime)
        {
            this.client = new TcAdsClient();
            this.cycleTime = cycleTime;
            this.unConnectedAddresses = new List<IWritableAddress>();
            this.addresses = new List<IWritableAddress>();
            this.disposable = Observable.Interval(cycleTime).Subscribe(_ =>
            {
                this.ConnectedUnconnectedAddresses();
                if (this.addresses.Count > 0)
                {
                    PlcWriter.WriteAllValues(this.client, this.addresses);
                }
            });
        }

        public static ConnectedWriteClient CreateAndConnect(AmsNetId id, int port, TimeSpan cycleTime)
        {
            var connectedClient = new ConnectedWriteClient(cycleTime);
            connectedClient.client.Connect(id, port);
            return connectedClient;
        }

        public VariableHandleAndSize ReadSymbolInfo(string name)
        {
            this.ThrowIfDisposed();
            if (this.client.IsConnected)
            {
                this.client.Connect(this.client.Address);
            }

            return this.client.ReadSymbolInfoAds(name);
        }

        public void RegisterCyclicWriting(IWritableAddress address)
        {
            this.ThrowIfDisposed();
            this.unConnectedAddresses.Add(address);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.client.Dispose();
            this.disposable?.Dispose();
            this.disposed = true;
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
                    using (var stream = PlcReader.ReadValue(this.client, readableAddress))
                    {
                        readableAddress.SetInitialValue(stream);
                    }
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
