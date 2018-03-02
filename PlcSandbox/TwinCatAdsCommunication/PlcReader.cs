namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TwinCAT.Ads;

    public static class PlcReader
    {
        private const int BitSizeSize = sizeof(int);
        private const int BitOffsetSize = sizeof(int);
        private const int SymbolValueByHandleSize = sizeof(int);
        

        internal static void ReadToAllValues(TcAdsClient adsClient, IList<IReadableAddress> addresses)
        {
            if (!addresses.Any())
            {
                throw new InvalidOperationException("addresses should not be empty");
            }

            using (var stream = BatchRead(adsClient, addresses))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    reader.CheckErrors((IList<IAddressable>) addresses);
                    foreach (var address in addresses)
                    {
                        address.UpdateValue(reader);
                    }
                }
            }
        }

        private static AdsStream BatchRead(TcAdsClient adsClient, IList<IReadableAddress> variables)
        {
            if (!variables.Any())
            {
                throw new InvalidOperationException("Variables should not be empty");
            }

            // Allocate memory
            int rdLength = variables.Count * 4;
            int wrLength = (SymbolValueByHandleSize + BitOffsetSize + BitSizeSize) * variables.Count;

            // Write data for handles into the ADS Stream
            using (var writer = new BinaryWriter(new AdsStream(wrLength)))
            {
                foreach (var readableAddress in variables)
                {
                    writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                    writer.Write(readableAddress.Address.VariableHandle);
                    writer.Write(readableAddress.Address.BitSize);
                    rdLength += readableAddress.Address.BitSize;
                }

                // Sum command to read variables from the PLC
                AdsStream rdStream = new AdsStream(rdLength);
                adsClient.ReadWrite(0xF080, variables.Count, rdStream, (AdsStream)writer.BaseStream);

                // Return the ADS error codes
                return rdStream;
            }
        }
    }
}
