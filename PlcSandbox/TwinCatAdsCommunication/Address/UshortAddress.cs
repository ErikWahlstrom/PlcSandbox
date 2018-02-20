namespace TwinCatAdsCommunication.Address
{
    public class UshortAddress : AdressBase<ushort>
    {
        public UshortAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }
    }
}