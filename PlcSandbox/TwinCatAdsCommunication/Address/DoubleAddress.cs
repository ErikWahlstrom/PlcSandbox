namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class DoubleAddress : AddressBase<double>
    {
        internal DoubleAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
