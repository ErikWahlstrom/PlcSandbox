namespace TwinCatAdsCommunication
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

    public class BoolAddress : Adress<bool>
    {
        public BoolAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }

    public class StringAddress : Adress<string>
    {
        public StringAddress(int bitSize, string name, int bitOffset) : base(bitSize, name, bitOffset)
        {
        }
    }
}
