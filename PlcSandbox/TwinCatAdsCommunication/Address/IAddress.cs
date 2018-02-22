namespace TwinCatAdsCommunication.Address
{
    public interface IAddress
    {
        string Name { get; }

        int BitSize { get; }

        // Den här ska nog kanske läsas ur istället?
        int BitOffset { get; }
    }
}
