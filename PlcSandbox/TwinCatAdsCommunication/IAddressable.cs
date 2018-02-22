namespace TwinCatAdsCommunication
{
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public interface IAddressable
    {
        IAddress Address { get; }
    }

    public interface IReadableAddress : IAddressable
    {
        void UpdateValue(AdsStream stream);
    }

    public interface IWritableAddress : IAddressable
    {
        byte[] ValueToWrite { get; }
    }
}
