namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class DoubleAddress : AddressBase<double>
    {
        internal DoubleAddress(int bitSize, string name, long bitOffset)
            : base(bitSize, name, bitOffset)
        {
        }

        public override double ReadStream(BinaryReader reader)
        {
            return reader.ReadDouble();
        }

        public override void WriteToStream(BinaryWriter writer, double value)
        {
            writer.Write(value);
        }
    }

    public class DoubleAddressInitial : UnconnectedAddressBase<double>
    {
        public DoubleAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new DoubleAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }

    public class FloatAddressInitial : UnconnectedAddressBase<float>
    {
        public FloatAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new FloatAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }

    public class IntAddressInitial : UnconnectedAddressBase<int>
    {
        public IntAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new IntAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }

    public class ShortAddressInitial : UnconnectedAddressBase<short>
    {
        public ShortAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new ShortAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }

    public class StringAddressInitial : UnconnectedAddressBase<string>
    {
        public StringAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new StringAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }

    public class UintAddressInitial : UnconnectedAddressBase<uint>
    {
        public UintAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new UintAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }

    public class UshortAddressInitial : UnconnectedAddressBase<short>
    {
        public UshortAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }

        public override IAddress GetConnectedAddress(IConnectedClient connectedReadClient)
        {
            var symbolInfo = connectedReadClient.ReadSymbolInfo(this.Name);
            return new ShortAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }
}
