namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class UintAddress : AddressBase<uint>
    {
        public UintAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
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