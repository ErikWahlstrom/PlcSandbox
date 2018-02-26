namespace TwinCatAdsCommunication
{
    using TwinCAT.Ads;

    public interface IConnectedClient
    {
        ITcAdsSymbol ReadSymbolInfo(string name);
    }
}
