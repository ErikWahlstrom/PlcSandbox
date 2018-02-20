namespace TwinCatAdsCommunication.Address
{
    public class ShortAddress : AdressBase<short>
    {
        public ShortAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}