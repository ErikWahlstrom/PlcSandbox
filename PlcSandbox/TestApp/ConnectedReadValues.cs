namespace TestApp
{
    using System;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication;

    public sealed class ConnectedReadValues : IDisposable
    {
        private readonly ConnectedClient connectedClient;
        private bool disposed;

        public ConnectedReadValues()
        {
            this.connectedClient = ConnectedClient.CreateAndConnect(new AmsNetId("1.2.3.5.1.1"), 851);
            this.IsLightOn = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.IsLightOn, this.connectedClient));
            this.BuildingBoxConnected = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.bBuildingBoxConnected, this.connectedClient));
            var cyclicReader = new PlcReader(this.IsLightOn, this.BuildingBoxConnected);
            this.connectedClient.StartCyclicReading(cyclicReader, TimeSpan.FromMilliseconds(200));
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
            this.connectedClient?.Dispose();
        }
    }
}
