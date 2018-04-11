namespace TwinCatAdsCommunication.Address
{
    public class ShortAddressUnconnected : UnconnectedAddressBase<short>
    {
        public ShortAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new ShortAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}