namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class TwincSymbols
    {
        public static BoolAddress ConnectBoolAddress(BoolAddressInitial boolAddressInitial, ConnectedClient adsClient)
        {
            var symbolInfo = adsClient.ReadSymbolInfo(boolAddressInitial.Name);
            return new BoolAddress(symbolInfo.Size, symbolInfo.Name, symbolInfo.IndexOffset);
        }
    }
}
