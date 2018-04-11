namespace TwinCatAdsCommunication
{
    using System;
    using System.IO;
    using TwinCatAdsCommunication.Address;

    public interface IAddressable
    {
        IAddress Address { get; set; }

        Exception Exception { get; set; }

        IUnconnectedAddress UnconnectedAddress { get; }
    }

    public interface IUnconnectedAddress
    {
        string Name { get; }

        IAddress GetConnectedAddress(IConnectedClient connectedReadClient);
    }

    public interface IReadableAddress : IAddressable
    {
        void UpdateValue(BinaryReader stream);
    }

    public interface IWritableAddress : IAddressable
    {
        void WriteValueToStream(BinaryWriter writer);

        void NotifyWritten();
    }
}
