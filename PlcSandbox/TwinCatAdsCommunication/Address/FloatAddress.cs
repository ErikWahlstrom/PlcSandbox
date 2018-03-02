namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class FloatAddress : AddressBase<float>
    {
        internal FloatAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
