namespace TwinCatAdsCommunication.Address
{
    using TwinCAT.Ads;

    public interface IAddress
    {
        string Name { get; }

        int BitSize { get; }

        int VariableHandle { get; }
    }
}
