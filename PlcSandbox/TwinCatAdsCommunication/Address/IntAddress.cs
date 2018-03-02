namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class IntAddress : AddressBase<int>
    {
        internal IntAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
