namespace TwinCatAdsCommunication.Address
{
    public class IntAddressUnconnected : UnconnectedAddressBase<int>
    {
        public IntAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new IntAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}