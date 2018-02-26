namespace TwinCatAdsCommunication
{
    using TwinCAT.Ads;

    public class ConnectedClient
    {
        private TcAdsClient client;

        private ConnectedClient(TcAdsClient client)
        {
            this.client = client;
        }

        public static ConnectedClient CreateAndConnect(AmsNetId id, int port)
        {
            var client = new TcAdsClient();
            client.Connect(id, port);
            return new ConnectedClient(client);
        }

        public ITcAdsSymbol ReadSymbolInfo(string name)
        {
            if (this.client.IsConnected)
            {
                this.client.Connect(this.client.Address);
            }

            return this.client.ReadSymbolInfo(name);
        }
    }
}
