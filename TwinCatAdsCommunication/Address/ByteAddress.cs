namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class ByteAddress : AddressBase<byte>
    {
        internal ByteAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override byte ReadStream(BinaryReader reader)
        {
            return reader.ReadByte();
        }

        public override void WriteToStream(BinaryWriter writer, byte value)
        {
            writer.Write(value);
        }
    }
}
