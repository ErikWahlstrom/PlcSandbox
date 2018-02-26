namespace TestApp
{
    using System;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication;

    public sealed class ConnectedReadValues : IDisposable
    {
        private readonly ConnectedReadClient connectedReadClient;
        private bool disposed;

        public ConnectedReadValues()
        {
            this.connectedReadClient = ConnectedReadClient.CreateAndConnect(new AmsNetId("123.2.3.55.1.3"), 851, TimeSpan.FromMilliseconds(1000));
            this.IsLightOn = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.IsLightOn, this.connectedReadClient), this.connectedReadClient);
            this.BuildingBoxConnected = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.bBuildingBoxConnected, this.connectedReadClient), this.connectedReadClient);
        }

        public ReadableValue<bool> BuildingBoxConnected { get; }

        public ReadableValue<bool> IsLightOn { get; }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.connectedReadClient?.Dispose();
        }
    }
}
