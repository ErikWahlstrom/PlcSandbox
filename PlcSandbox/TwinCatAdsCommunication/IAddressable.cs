namespace TwinCatAdsCommunication
{
    using System.IO;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public interface IAddressable
    {
        IAddress Address { get; }

        AdsErrorCode Error { get; set; }
    }

    public interface IReadableAddress : IAddressable
    {
        void UpdateValue(BinaryReader stream);
    }

    public interface IWritableAddress : IAddressable
    {
        void WriteValueToStream(BinaryWriter writer);
    }
}
