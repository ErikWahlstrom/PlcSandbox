namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class ShortAddress : AddressBase<short>
    {
        public ShortAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override short ReadStream(BinaryReader reader)
        {
            return reader.ReadInt16();
        }

        public override void WriteToStream(BinaryWriter writer, short value)
        {
            writer.Write(value);
        }
    }
}