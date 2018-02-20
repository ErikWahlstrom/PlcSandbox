namespace TwinCatAdsCommunication.Address
{
    public class BoolAddress : Adress<bool>
    {
        public BoolAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}