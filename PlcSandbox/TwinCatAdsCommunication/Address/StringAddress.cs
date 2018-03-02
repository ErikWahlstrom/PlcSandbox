namespace TwinCatAdsCommunication.Address
{
    using System;
    using System.IO;

    public class StringAddress : AddressBase<string>
    {
        internal StringAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
