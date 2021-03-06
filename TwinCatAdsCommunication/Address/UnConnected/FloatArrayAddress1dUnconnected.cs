namespace TwinCatAdsCommunication.Address
{
    public class FloatArrayAddress1DUnconnected : UnconnectedAddressBase<float[]>
    {
        public FloatArrayAddress1DUnconnected(int bitSize, string name)
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
