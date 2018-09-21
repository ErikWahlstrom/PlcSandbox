namespace TestApp
{
    using System;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication;
    using TwinCatAdsCommunication.Address;

    public sealed class ConnectedWriteValues : IDisposable
    {
        private readonly ConnectedWriteClient connectedWriteClient;
        private bool disposed;

        public ConnectedWriteValues()
        {
            this.connectedWriteClient = ConnectedWriteClient.CreateAndConnect(new AmsNetId("127.0.0.1.1.1"), 851, TimeSpan.FromMilliseconds(100));
            this.LightOn = new WriteableValue<bool>(GeneratedAddress.MAIN.LightOn, this.connectedWriteClient);
            this.connectedWriteClient.RegisterCyclicWriting(this.LightOn);
            this.StringIn = new WriteableValue<string>(GeneratedAddress.MAIN.TestStringIn, this.connectedWriteClient);
            this.WriteArray = new WriteableValue<float[]>(GeneratedAddress.MC.lrSampleArray, this.connectedWriteClient);
            this.WriteArrayLong = new WriteableValue<ReadOnlyArray<double>>(GeneratedAddress.MC.lrLongSampleArray, this.connectedWriteClient);
            this.WriteArrayLong2D = new WriteableValue<double[,]>(GeneratedAddress.MC.lrLong2DSampleArray, this.connectedWriteClient);
        }

        public WriteableValue<string> StringIn { get; }

        public WriteableValue<bool> LightOn { get; }

        public WriteableValue<float[]> WriteArray { get; }

        public WriteableValue<ReadOnlyArray<double>> WriteArrayLong { get; }

        public WriteableValue<double[,]> WriteArrayLong2D { get; }

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
