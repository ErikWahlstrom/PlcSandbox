namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TwinCAT.Ads;

    public static class PlcWriter
    {

        private const int BitSizeSize = sizeof(int);
        private const int VariableHandleSize = sizeof(int);
        private const int SymbolValueByHandleSize = sizeof(int);
        private const int ErrorSize = sizeof(int);

        internal static void WriteAllValues(TcAdsClient writeClient, IList<IWritableAddress> addresses)
        {
            if (!addresses.Any())
            {
                throw new InvalidOperationException("Addresses should not be empty");
            }

            using (var stream = BatchWrite(writeClient, addresses))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    reader.CheckErrors((IList<IAddressable>) addresses);
                }
            }
        }

        private static AdsStream BatchWrite(TcAdsClient adsClient, IList<IWritableAddress> addresses)
        {
            if (!addresses.Any())
            {
                throw new InvalidOperationException("addresses shoule not be empty");
            }

            // Allocate memory
            int rdLength = addresses.Count * ErrorSize;
            int wrLength = (addresses.Count * (SymbolValueByHandleSize + VariableHandleSize + BitSizeSize)) + 7; // Magic seven. Not sure why needed, needs to be looked up.
            using (var writer = new BinaryWriter(new AdsStream(wrLength)))
            {
                // Write data for handles into the ADS stream
                foreach (var writableAddress in addresses)
                {
                    writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                    writer.Write(writableAddress.Address.VariableHandle);
                    writer.Write(writableAddress.Address.BitSize);
                }

                foreach (var writableAddress in addresses)
                {
                    writableAddress.WriteValueToStream(writer);
                }

                AdsStream errorStream = new AdsStream(rdLength);
                adsClient.ReadWrite(0xF081, addresses.Count, errorStream, (AdsStream)writer.BaseStream);

                foreach (var writableAddress in addresses)
                {
                    // Ska vi signalera här?
                    writableAddress.NotifyWritten();
                }

                // Return the ADS error codes
                return errorStream;
            }
        }
    }
}
