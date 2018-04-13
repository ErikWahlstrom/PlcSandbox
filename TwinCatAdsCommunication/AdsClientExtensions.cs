namespace TwinCatAdsCommunication
{
    using System;
    using System.Linq;
    using TwinCAT.Ads;

    internal static class AdsClientExtensions
    {
        internal static VariableHandleAndSize ReadSymbolInfoAds(this TcAdsClient client, string name)
        {
            if (!client.IsConnected)
            {
                client.Connect(client.Address);
            }

            var info = client.ReadSymbolInfo(name);
            var handle = client.CreateVariableHandle(name);
            if (info == null)
            {
                throw new InvalidOperationException($"Address does not exist in PLC: {name}");
            }

            var infor = (ITcAdsSymbol5)info;
            return new VariableHandleAndSize(handle, info.Size, infor.DataType.Dimensions.Select(x => x.ElementCount));
        }
    }
}
