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
