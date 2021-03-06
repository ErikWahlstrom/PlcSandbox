namespace TwinCatAdsCommunication.Address
{
    public class FloatAddressUnconnected : UnconnectedAddressBase<float>
    {
        public FloatAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new FloatAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}