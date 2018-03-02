namespace TwinCatAdsCommunication.Address
{
    public class DoubleAddressUnconnected : UnconnectedAddressBase<double>
    {
        public DoubleAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new DoubleAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}
