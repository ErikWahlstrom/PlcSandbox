namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class DoubleAddress : AddressBase<double>
    {
        internal DoubleAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
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
            return new DoubleAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
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
            return new FloatAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
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
            return new IntAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
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
            return new ShortAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
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
            return new StringAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
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
            return new UintAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
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
            return new ShortAddress(this.Name, symbolInfo.Size, symbolInfo.Handle);
        }
    }
}
