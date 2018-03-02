namespace TwinCatAdsCommunication
{
    using TwinCAT.Ads;

    public interface IConnectedClient
    {
        VariableHandleAndSize ReadSymbolInfo(string name);
    }
}
