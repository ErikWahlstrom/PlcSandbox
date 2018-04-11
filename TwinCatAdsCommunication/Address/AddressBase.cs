namespace TwinCatAdsCommunication.Address
{
    using System;
    using System.IO;

    public abstract class AddressBase<T> : IAddress
    {
        internal AddressBase(string name, int bitSize, int variableHandle)
        {
            this.BitSize = bitSize;
            this.Name = name;
            this.VariableHandle = variableHandle;
        }

        public string Name { get; }

        public int BitSize { get; }

        public int VariableHandle { get; }

        public Type Type { get; } = typeof(T);

        public override string ToString()
        {
            return $"{this.Name}, {this.VariableHandle}, {this.BitSize}";
        }

        public abstract T ReadStream(BinaryReader reader);

        public abstract void WriteToStream(BinaryWriter writer, T value);
    }
}
