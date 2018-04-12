namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class FloatArrayAddress : AddressBase<float[]>
    {
        internal FloatArrayAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override float[] ReadStream(BinaryReader reader)
        {
            int valueAmount = this.BitSize / sizeof(float);
            var array = new float[valueAmount];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadSingle();
            }

            return array;
        }

        public override void WriteToStream(BinaryWriter writer, float[] value)
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
