namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class ShortAddress : AddressBase<short>
    {
        internal ShortAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
