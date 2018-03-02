namespace TwinCatAdsCommunication
{
    using System;
    using TwinCAT.Ads;

    public static class AdsClientExtensions
    {
        public static ITcAdsSymbol ReadSymbolInfoAds(this TcAdsClient client, string name)
        {
            if (!client.IsConnected)
            {
                client.Connect(client.Address);
            }

            var info = client.ReadSymbolInfo(name);
            if (info == null)
            {
                throw new InvalidOperationException($"Address does not exist in PLC: {name}");
            }

            return info;
        }
    }
}
