namespace TwinCatAdsCommunication.Address
{
    public class ByteAddressInitial : UnconnectedAddressBase<byte>
    {
        public ByteAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(ConnectedReadClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new ByteAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }
}
