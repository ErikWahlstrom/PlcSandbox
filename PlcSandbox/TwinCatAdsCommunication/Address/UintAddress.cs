namespace TwinCatAdsCommunication.Address
{
    public class UintAddress : Adress<uint>
    {
        public UintAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}