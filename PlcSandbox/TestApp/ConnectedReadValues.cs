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
            this.connectedReadClient = ConnectedReadClient.CreateAndConnect(new AmsNetId("123.2.3.55.1.3"), 851);
            this.IsLightOn = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.IsLightOn, this.connectedReadClient));
            this.BuildingBoxConnected = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.bBuildingBoxConnected, this.connectedReadClient));
            var cyclicReader = new PlcReader(this.IsLightOn, this.BuildingBoxConnected);
            this.connectedReadClient.StartCyclicReading(cyclicReader, TimeSpan.FromMilliseconds(200));
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

    public sealed class ConnectedWriteValues : IDisposable
    {
        private readonly ConnectedWriteClient connectedWriteClient;
        private bool disposed;

        public ConnectedWriteValues()
        {
            this.connectedWriteClient = ConnectedWriteClient.CreateAndConnect(new AmsNetId("1.2.3.5.1.1"), 851);
            this.LightOn = new WriteableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.LightOn, this.connectedWriteClient));
            var cyclicWriter = new PlcWriter(this.LightOn);
            this.connectedWriteClient.StartCyclicWriting(cyclicWriter, TimeSpan.FromMilliseconds(200));
        }

        public WriteableValue<bool> LightOn { get; }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.connectedWriteClient?.Dispose();
        }
    }
}
