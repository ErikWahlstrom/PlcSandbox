namespace TwinCatAdsCommunication.Address
{
    using System;
    using System.IO;
    using TwinCAT.Ads;

    public abstract class AddressBase<T> : IAddress
    {
        protected AddressBase(int bitSize, string name, int bitOffset)
        {
            this.BitSize = bitSize;
            this.Name = name;
            this.BitOffset = bitOffset;
        }

        public string Name { get; }

        public int BitSize { get; }

        public int BitOffset { get; }

        public Type Type { get; } = typeof(T);

        public override string ToString()
        {
            return $"{this.Name}, {this.BitOffset}, {this.BitSize}";
        }

        public abstract T ReadStream(BinaryReader reader);

        public abstract void WriteToStream(BinaryWriter writer, T value);
    }
}
