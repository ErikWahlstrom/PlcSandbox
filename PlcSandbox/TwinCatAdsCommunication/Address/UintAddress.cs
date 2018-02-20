namespace TwinCatAdsCommunication.Address
{
    public class UintAddress : AdressBase<uint>
    {
        public UintAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}