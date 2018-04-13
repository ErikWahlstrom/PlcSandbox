namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class DoubleArray2DAddress : AddressBase<double[,]>
    {
        private readonly int dim0Length;
        private readonly int dim1Length;

        internal DoubleArray2DAddress(string name, int bitSize, int variableHandle, int dim0Length, int dim1Length)
            : base(name, bitSize, variableHandle)
        {
            this.dim0Length = dim0Length;
            this.dim1Length = dim1Length;
        }

        public override double[,] ReadStream(BinaryReader reader)
        {
            var array = new double[this.dim0Length, this.dim1Length];
            for (int i = 0; i < this.dim0Length; i++)
            {
                for (int j = 0; j < this.dim1Length; j++)
                {
                    array[i, j] = reader.ReadDouble();
                }
            }

            return array;
        }

        public override void WriteToStream(BinaryWriter writer, double[,] value)
        {
            if (value != null)
            {
                for (int i = 0; i < this.dim0Length; i++)
                {
                    for (int j = 0; j < this.dim1Length; j++)
                    {
                        writer.Write(value[i, j]);
                    }
                }
            }
        }
    }
}
