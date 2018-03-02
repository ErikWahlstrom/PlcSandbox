namespace TestApp
{
    using System;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication;

    public sealed class ConnectedWriteValues : IDisposable
    {
        private readonly ConnectedWriteClient connectedWriteClient;
        private bool disposed;

        public ConnectedWriteValues()
        {
            this.connectedWriteClient = ConnectedWriteClient.CreateAndConnect(new AmsNetId("164.4.3.67.1.1"), 851, TimeSpan.FromMilliseconds(10));
            this.LightOn = new WriteableValue<bool>(GeneratedAddress.MAIN.LightOn, this.connectedWriteClient);
            this.connectedWriteClient.RegisterCyclicWriting(this.LightOn);
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
