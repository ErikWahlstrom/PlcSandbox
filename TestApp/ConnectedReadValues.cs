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
            this.connectedReadClient = ConnectedReadClient.CreateAndConnect(new AmsNetId("164.4.3.67.1.1"), 851, TimeSpan.FromMilliseconds(10));
            this.IsLightOn = new ReadableValue<bool>(GeneratedAddress.MAIN.IsLightOn, this.connectedReadClient);
            this.BuildingBoxConnected = new ReadableValue<bool>(GeneratedAddress.MAIN.bBuildingBoxConnected, this.connectedReadClient);
            this.StringOut = new ReadableValue<string>(GeneratedAddress.MAIN.TestStringOut, this.connectedReadClient);
            this.ReadArray = new ReadableValue<double[]>(GeneratedAddress.MC.lrSampleArray, this.connectedReadClient);
        }

        public ReadableValue<double[]> ReadArray { get; }

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
