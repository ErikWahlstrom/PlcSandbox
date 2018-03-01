namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TwinCAT.Ads;

    public static class PlcWriter
    {
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
            int rdLength = addresses.Count * 4;
            int wrLength = (addresses.Count * 12) + 7; // Kolla den här med befintligt komm. Finns några mer logiska siffror (dock samma) att använda
            using (var writer = new BinaryWriter(new AdsStream(wrLength)))
            {
                // Write data for handles into the ADS stream
                foreach (var writableAddress in addresses)
                {
                    writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                    writer.Write(writableAddress.Address.BitOffset);
                    writer.Write(writableAddress.Address.BitSize);
                }

                foreach (var writableAddress in addresses)
                {
                    writableAddress.WriteValueToStream(writer);
                }

                // Sum command to write the data into the PLC
                AdsStream rdStream = new AdsStream(rdLength);
                adsClient.ReadWrite(0xF081, addresses.Count, rdStream, (AdsStream)writer.BaseStream);

                foreach (var writableAddress in addresses)
                {
                    // Ska vi signalera här?
                    writableAddress.NotifyWritten();
                }

                // Return the ADS error codes
                return rdStream;
            }
        }
    }
}
