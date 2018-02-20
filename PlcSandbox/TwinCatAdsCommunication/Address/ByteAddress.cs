namespace TwinCatAdsCommunication.Address
{
    public class ByteAddress : Adress<byte>
    {
        public ByteAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}