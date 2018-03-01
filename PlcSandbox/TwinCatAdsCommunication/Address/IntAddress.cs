namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class IntAddress : AddressBase<int>
    {
        internal IntAddress(int bitSize, string name, long bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override int ReadStream(BinaryReader reader)
        {
            return reader.ReadInt32();
        }

        public override void WriteToStream(BinaryWriter writer, int value)
        {
            writer.Write(value);
        }
    }
}
