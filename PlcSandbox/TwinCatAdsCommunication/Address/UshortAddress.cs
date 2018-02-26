namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class UshortAddress : AddressBase<ushort>
    {
        internal UshortAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override ushort ReadStream(BinaryReader reader)
        {
            return reader.ReadUInt16();
        }

        public override void WriteToStream(BinaryWriter writer, ushort value)
        {
            writer.Write(value);
        }
    }
}
