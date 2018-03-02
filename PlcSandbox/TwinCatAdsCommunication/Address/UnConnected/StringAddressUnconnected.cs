namespace TwinCatAdsCommunication.Address
{
    public class StringAddressUnconnected : UnconnectedAddressBase<string>
    {
        public StringAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new StringAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}