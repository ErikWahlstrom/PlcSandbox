namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class TwincSymbols
    {
        public static BoolAddress ConnectBoolAddress(BoolAddressInitial boolAddressInitial, IConnectedClient adsReadClient)
        {
            var symbolInfo = adsReadClient.ReadSymbolInfo(boolAddressInitial.Name);
            return new BoolAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }
}
