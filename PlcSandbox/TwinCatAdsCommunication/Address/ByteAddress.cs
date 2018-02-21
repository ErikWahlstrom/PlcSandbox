namespace TwinCatAdsCommunication.Address
{
    public class ByteAddress : AddressBase<byte>
    {
        public ByteAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}