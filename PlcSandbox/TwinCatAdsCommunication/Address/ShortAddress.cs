namespace TwinCatAdsCommunication.Address
{
    public class ShortAddress : Adress<short>
    {
        public ShortAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}