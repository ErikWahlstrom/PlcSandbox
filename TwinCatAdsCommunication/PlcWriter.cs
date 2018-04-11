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
                    reader.CheckErrors(addresses.Select(x => (IAddressable)x).ToList());
                }
            }
        }

        private static AdsStream BatchWrite(TcAdsClient adsClient, IList<IWritableAddress> addresses)
        {
            if (!addresses.Any())
            {
                throw new InvalidOperationException("addresses should not be empty");
            }

            // Allocate memory
            int rdLength = addresses.Count * ErrorSize;
            var totalMemorySize = addresses.Sum(x => x.Address.BitSize);
            int wrLength = (addresses.Count * (SymbolValueByHandleSize + VariableHandleSize + BitSizeSize)) + totalMemorySize;
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
                    writableAddress.NotifyWritten();
                }

                // Return the ADS error codes
                return errorStream;
            }
        }
    }
}
