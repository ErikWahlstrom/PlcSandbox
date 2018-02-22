namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class DoubleAddress : AddressBase<double>
    {
        public DoubleAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override double ReadStream(BinaryReader reader)
        {
            return reader.ReadDouble();
        }

        public override void WriteToStream(BinaryWriter writer, double value)
        {
            writer.Write(value);
        }
    }
}