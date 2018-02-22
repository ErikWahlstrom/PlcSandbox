namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class ByteAddress : AddressBase<byte>
    {
        public ByteAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
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