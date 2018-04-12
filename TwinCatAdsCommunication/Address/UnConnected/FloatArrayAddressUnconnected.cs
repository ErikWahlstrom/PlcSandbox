namespace TwinCatAdsCommunication.Address
{
    public class FloatArrayAddressUnconnected : UnconnectedAddressBase<float[]>
    {
        public FloatArrayAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new FloatArrayAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}
