namespace TwinCatAdsCommunication.Address
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;

    public class Array2dAddress<T> : AddressBase<T[]>
        where T : struct
    {
        internal Array2dAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override T[] ReadStream(BinaryReader reader)
        {
            if (typeof(T) == typeof(double))
            {
                int valueAmount = this.BitSize / sizeof(double);
                var array = new double[valueAmount];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadDouble();
                }

                return (T[])(object)array;
            }

            throw new NotImplementedException();
        }

        public override void WriteToStream(BinaryWriter writer, T[] value)
        {
            if (value != null)
            {
                if (typeof(T) == typeof(double))
                {
                    foreach (var doubleValue in value)
                    {
                        double hej = (double)(object)doubleValue;
                        writer.Write(hej);
                    }
                }
            }
        }
    }
}
