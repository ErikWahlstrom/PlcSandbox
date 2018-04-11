namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class UshortAddress : AddressBase<ushort>
    {
        internal UshortAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
