namespace TwinCatAdsCommunication.Address
{
    using System.Linq;

    public class DoubleArrayAddress2DUnconnected : UnconnectedAddressBase<double[,]>
    {
        public DoubleArrayAddress2DUnconnected(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new DoubleArray2DAddress(this.Name, symbolInfo.Size, symbolInfo.Handle, symbolInfo.ArrayDims.First(), symbolInfo.ArrayDims.Last());
        }
    }
}
