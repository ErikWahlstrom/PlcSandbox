namespace TwinCatAdsCommunication.Address
{
    public class DoubleAddress : AddressBase<double>
    {
        public DoubleAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}