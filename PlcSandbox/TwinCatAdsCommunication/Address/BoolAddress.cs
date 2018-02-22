namespace TwinCatAdsCommunication.Address
{
    using System.IO;
    using TwinCAT.Ads;

    public class BoolAddress : AddressBase<bool>
    {
        public BoolAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
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