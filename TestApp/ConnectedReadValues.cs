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
            this.connectedReadClient = ConnectedReadClient.CreateAndConnect(new AmsNetId("164.4.3.67.1.1"), 851, TimeSpan.FromMilliseconds(100));
            this.IsLightOn = new ReadableValue<bool>(GeneratedAddress.MAIN.IsLightOn, this.connectedReadClient);
            this.BuildingBoxConnected = new ReadableValue<bool>(GeneratedAddress.MAIN.bBuildingBoxConnected, this.connectedReadClient);
            this.StringOut = new ReadableValue<string>(GeneratedAddress.MAIN.TestStringOut, this.connectedReadClient);
            this.ReadArray = new ReadableValue<float[]>(GeneratedAddress.MC.lrSampleArray, this.connectedReadClient);
            this.ReadArrayLong = new ReadableValue<double[]>(GeneratedAddress.MC.lrLongSampleArray, this.connectedReadClient);
            this.ReadArrayLong2D = new ReadableValue<double[,]>(GeneratedAddress.MC.lrLong2DSampleArray, this.connectedReadClient);
        }

        public ReadableValue<float[]> ReadArray { get; }

        public ReadableValue<double[]> ReadArrayLong { get; }

        public ReadableValue<double[,]> ReadArrayLong2D { get; }

        public ReadableValue<string> StringOut { get; }

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
