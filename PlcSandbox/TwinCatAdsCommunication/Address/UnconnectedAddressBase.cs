namespace TwinCatAdsCommunication.Address
{
    using System;

    public abstract class UnconnectedAddressBase<T> : IUnconnectedAddress
    {
        protected UnconnectedAddressBase(int bitSize, string name)
        {
            this.BitSize = bitSize;
            this.Name = name;
        }

        public string Name { get; }

        public int BitSize { get; }

        public Type Type { get; } = typeof(T);

        public override string ToString()
        {
            return $"{this.Name}, {this.BitSize}";
        }

        public abstract IAddress GetConnectedAddress(IConnectedClient connectedReadClient);
    }
}
