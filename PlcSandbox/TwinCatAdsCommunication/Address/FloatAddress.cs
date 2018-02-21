namespace TwinCatAdsCommunication.Address
{
    public class FloatAddress : AddressBase<float>
    {
        public FloatAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}