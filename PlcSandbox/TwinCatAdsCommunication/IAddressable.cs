namespace TwinCatAdsCommunication
{
    using System.IO;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public interface IAddressable
    {
        IAddress Address { get; set; }

        AdsErrorCode Error { get; set; }

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
