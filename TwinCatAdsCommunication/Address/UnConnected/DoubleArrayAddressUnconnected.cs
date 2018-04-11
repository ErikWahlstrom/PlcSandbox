namespace TwinCatAdsCommunication.Address
{
    public class DoubleArrayAddressUnconnected : UnconnectedAddressBase<double[]>
    {
        public DoubleArrayAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new DoubleArrayAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}