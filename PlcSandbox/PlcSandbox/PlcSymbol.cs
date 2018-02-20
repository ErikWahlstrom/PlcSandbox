namespace PlcSandbox
{
    public class PlcSymbol
    {
        public PlcSymbol(string name, string type, int bitSize, int bitOffset)
        {
            Name = name;
            Type = type;
            BitSize = bitSize;
            BitOffset = bitOffset;
        }

        public string Name { get; }

        public string Type { get; }

        public int BitSize { get; }

        public int BitOffset { get; }
    }
}