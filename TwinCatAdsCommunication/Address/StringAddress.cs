namespace TwinCatAdsCommunication.Address
{
    using System;
    using System.IO;
    using System.Text;

    public class StringAddress : AddressBase<string>
    {
        internal StringAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override string ReadStream(BinaryReader reader)
        {
            System.Text.Encoding encoding = Encoding.Default; // The encoding can differ depending on string type. Investigate further
            byte[] buffer = reader.ReadBytes(this.BitSize);
            string s = encoding.GetString(buffer);
            int length = s.IndexOf('\0');
            if (length == -1)
            {
                // Null termination character not found
                return s;
            }

            return s.Substring(0, length);
        }

        public override void WriteToStream(BinaryWriter writer, string value)
        {
            if (value == null)
            {
                value = "null";
            }

            var encoding = Encoding.Default;
            byte[] data = encoding.GetBytes(value);

            // In case string length exceeds storage size in PLC, make sure there is room
            // for the null termination character at the end. When using Unicode, the
            // null termination is two bytes long.
            int dataLength = Math.Min(data.Length, this.BitSize - encoding.GetByteCount("\0"));
            byte[] zeroes = new byte[this.BitSize - dataLength]; // At least one byte

            writer.Write(data, 0, dataLength);
            writer.Write(zeroes);
        }
    }
}
