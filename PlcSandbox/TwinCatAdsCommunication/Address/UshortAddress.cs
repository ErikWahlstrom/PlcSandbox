namespace TwinCatAdsCommunication.Address
{
    public class UshortAddress : AddressBase<ushort>
    {
        public UshortAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}