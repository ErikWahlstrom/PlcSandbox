namespace TwinCatAdsCommunication
{
    using System;
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

            return new VariableHandleAndSize(handle, info.Size);
        }
    }

    public class VariableHandleAndSize
    {
        public VariableHandleAndSize(int handle, int size)
        {
            this.Handle = handle;
            this.Size = size;
        }

        public int Handle { get; }

        public int Size { get; }
    }
}
