namespace TwinCatAdsCommunication.Address
{
    using System;

    public abstract class Adress<T>
    {
        protected Adress(int bitSize, string name, int bitOffset)
        {
            BitSize = bitSize;
            Name = name;
            BitOffset = bitOffset;
        }

        public string Name { get; }
        public int BitSize { get; }
        public int BitOffset { get; }
        public Type Type { get; } = typeof(T);
    }
}
