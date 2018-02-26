namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class FloatAddress : AddressBase<float>
    {
        internal FloatAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override float ReadStream(BinaryReader reader)
        {
            return reader.ReadSingle();
        }

        public override void WriteToStream(BinaryWriter writer, float value)
        {
            writer.Write(value);
        }
    }
}
