namespace TwinCatAdsCommunication.Address
{
    public class ShortAddress : AddressBase<short>
    {
        public ShortAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}