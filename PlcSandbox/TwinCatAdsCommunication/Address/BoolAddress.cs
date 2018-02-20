namespace TwinCatAdsCommunication.Address
{
    public class BoolAddress : AdressBase<bool>
    {
        public BoolAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}