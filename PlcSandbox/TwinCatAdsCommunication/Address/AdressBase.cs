namespace TwinCatAdsCommunication.Address
{
    using System;

    public abstract class AdressBase<T>
    {
        protected AdressBase(int bitSize, string name, int bitOffset)
        {
            this.BitSize = bitSize;
            this.Name = name;
            this.BitOffset = bitOffset;
        }

        public string Name { get; }

        public int BitSize { get; }

        public int BitOffset { get; }

        public Type Type { get; } = typeof(T);
    }
}
