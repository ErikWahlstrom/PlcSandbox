namespace TwinCatAdsCommunication.Address
{
    using System.IO;
    using System.Security;

    public class DoubleArrayAddress : AddressBase<double[]>
    {
        internal DoubleArrayAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override double[] ReadStream(BinaryReader reader)
        {
            int valueAmount = this.BitSize / sizeof(double);
            var array = new double[valueAmount];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadDouble();
            }

            return array;
        }

        public override void WriteToStream(BinaryWriter writer, double[] value)
        {
            if (value != null)
            {
                foreach (var doubleValue in value)
                {
                    writer.Write(doubleValue);
                }
            }
        }
    }
}
