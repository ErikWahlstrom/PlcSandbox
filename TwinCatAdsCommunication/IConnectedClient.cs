namespace TwinCatAdsCommunication
{
    public interface IConnectedClient
    {
        VariableHandleAndSize ReadSymbolInfo(string name);
    }
}
