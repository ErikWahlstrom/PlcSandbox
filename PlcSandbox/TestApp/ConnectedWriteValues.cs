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
            this.connectedWriteClient = ConnectedWriteClient.CreateAndConnect(new AmsNetId("1.2.3.5.1.1"), 851, TimeSpan.FromMilliseconds(200));
            this.LightOn = new WriteableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.LightOn, this.connectedWriteClient));
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
