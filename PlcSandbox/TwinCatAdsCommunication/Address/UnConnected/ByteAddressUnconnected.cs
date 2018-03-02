namespace TwinCatAdsCommunication.Address
{
    public class ByteAddressUnconnected : UnconnectedAddressBase<byte>
    {
        public ByteAddressUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new ByteAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}
