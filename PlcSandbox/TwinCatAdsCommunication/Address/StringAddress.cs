namespace TwinCatAdsCommunication.Address
{
    public class StringAddress : AdressBase<string>
    {
        public StringAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}