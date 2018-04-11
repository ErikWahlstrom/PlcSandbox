namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class BoolAddress : AddressBase<bool>
    {
        internal BoolAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override bool ReadStream(BinaryReader reader)
        {
            return reader.ReadBoolean();
        }

        public override void WriteToStream(BinaryWriter writer, bool value)
        {
            writer.Write(value);
        }
    }
}
