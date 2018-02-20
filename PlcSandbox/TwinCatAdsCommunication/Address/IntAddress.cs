namespace TwinCatAdsCommunication.Address
{
    public class IntAddress : AdressBase<int>
    {
        public IntAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}