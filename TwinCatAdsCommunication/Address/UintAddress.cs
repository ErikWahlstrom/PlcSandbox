namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class UintAddress : AddressBase<uint>
    {
        internal UintAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override uint ReadStream(BinaryReader reader)
        {
            return reader.ReadUInt32();
        }

        public override void WriteToStream(BinaryWriter writer, uint value)
        {
            writer.Write(value);
        }
    }
}
