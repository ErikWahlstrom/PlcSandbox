namespace TwinCatAdsCommunication.Address
{
    public class ByteAddress : AdressBase<byte>
    {
        public ByteAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}