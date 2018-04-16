namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Reactive.Linq;
    using TwinCAT.Ads;

    public sealed class ConnectedWriteClient : IDisposable, IConnectedClient
    {
        private readonly IList<IWritableAddress> addresses;
        private ImmutableList<IWritableAddress> unConnectedAddresses;
        private readonly IDisposable disposable;
        private bool disposed;

        private ConnectedWriteClient(TimeSpan cycleTime)
        {
            this.Client = new TcAdsClient();
            this.unConnectedAddresses = ImmutableList.Create<IWritableAddress>();
            this.addresses = new List<IWritableAddress>();
            this.disposable = Observable.Interval(cycleTime).Subscribe(_ =>
            {
                this.ConnectedUnconnectedAddresses();
                if (this.addresses.Count > 0)
                {
                    PlcWriter.WriteAllValues(this.Client, this.addresses);
                }
            });
        }

        internal TcAdsClient Client { get; }

        public static ConnectedWriteClient CreateAndConnect(AmsNetId id, int port, TimeSpan cycleTime)
        {
            var connectedClient = new ConnectedWriteClient(cycleTime);
            connectedClient.Client.Connect(id, port);
            return connectedClient;
        }

        public VariableHandleAndSize ReadSymbolInfo(string name)
        {
            this.ThrowIfDisposed();
            if (this.Client.IsConnected)
            {
                this.Client.Connect(this.Client.Address);
            }

            return this.Client.ReadSymbolInfoAds(name);
        }

        public void RegisterCyclicWriting(IWritableAddress address)
        {
            this.ThrowIfDisposed();
            this.unConnectedAddresses = this.unConnectedAddresses.Add(address);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.Client.Dispose();
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
                }
            }

            var connectedFromUnconnected = this.unConnectedAddresses.Where(x => x.Address != null).ToArray();

            foreach (var removeAddress in connectedFromUnconnected)
            {
                this.unConnectedAddresses = this.unConnectedAddresses.Remove(removeAddress);
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
