namespace TwinCatAdsCommunication.Address
{
    public class BoolAddress : AddressBase<bool>
    {
        public BoolAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}