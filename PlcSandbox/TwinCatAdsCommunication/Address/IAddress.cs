namespace TwinCatAdsCommunication.Address
{
    using TwinCAT.Ads;

    public interface IAddress
    {
        string Name { get; }

        int BitSize { get; }

        // Den här ska nog kanske läsas ur istället?
        int BitOffset { get; }
    }
}
