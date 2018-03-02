namespace TwinCatAdsCommunication.Address
{
    public interface IAddress
    {
        string Name { get; }

        int BitSize { get; }

        int VariableHandle { get; }
    }
}
