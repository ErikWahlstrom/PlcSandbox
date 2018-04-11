namespace TwinCatAdsCommunication.Address
{
    public class UintAddressUnconnected : UnconnectedAddressBase<uint>
    {
        public UintAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new UintAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}