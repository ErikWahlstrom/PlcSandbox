namespace TwinCatAdsCommunication.Address
{
    using System.IO;

    public class DoubleAddress : AddressBase<double>
    {
        internal DoubleAddress(int bitSize, string name, int bitOffset)
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
    }

    public class FloatAddressInitial : UnconnectedAddressBase<float>
    {
        public FloatAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }
    }

    public class IntAddressInitial : UnconnectedAddressBase<int>
    {
        public IntAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }
    }

    public class ShortAddressInitial : UnconnectedAddressBase<short>
    {
        public ShortAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }
    }

    public class StringAddressInitial : UnconnectedAddressBase<string>
    {
        public StringAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }
    }

    public class UintAddressInitial : UnconnectedAddressBase<uint>
    {
        public UintAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }
    }

    public class UshortAddressInitial : UnconnectedAddressBase<short>
    {
        public UshortAddressInitial(int bitSize, string name)
            : base(bitSize, name)
        {
        }
    }
}
