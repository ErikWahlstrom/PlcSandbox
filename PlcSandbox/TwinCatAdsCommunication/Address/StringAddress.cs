namespace TwinCatAdsCommunication.Address
{
    using System;
    using System.IO;

    public class StringAddress : AddressBase<string>
    {
        internal StringAddress(int bitSize, string name, int bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override string ReadStream(BinaryReader reader)
        {
            throw new NotImplementedException();
            // Ytterst tveksamt att den här funkar
            return reader.ReadString();
        }

        public override void WriteToStream(BinaryWriter writer, string value)
        {
            writer.Write(value);
        }
    }
}
