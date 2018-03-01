namespace TwinCatAdsCommunication.Address
{
    public class BoolAddressInitial : UnconnectedAddressBase<bool>
    {
        public BoolAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(ConnectedReadClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new BoolAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }
}
