namespace TwinCatAdsCommunication.Address
{
    public class BoolAddressUnconnected : UnconnectedAddressBase<bool>
    {
        public BoolAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new BoolAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}
