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
            //this.IsLightOn = new ReadableValue<bool>(GeneratedAddress.BLARSAF.bERR_AX5805ErrAckBlaRA_BLARPRO, this.connectedReadClient);
            //this.BuildingBoxConnected = new ReadableValue<bool>(GeneratedAddress.BLARSAF.bERR_AX5805ErrAckBlaRA_BLARPRO, this.connectedReadClient);
            //this.StringOut = new ReadableValue<string>(GeneratedAddress..BLARSAF.bERR_AX5805ErrAckBlaRA_BLARPRO.TestStringOut, this.connectedReadClient);
        }

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
