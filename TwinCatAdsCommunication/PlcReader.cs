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
        private const int VariableHandleSize = sizeof(int);
        private const int SymbolValueByHandleSize = sizeof(int);
        private const int ErrorSize = sizeof(int);

        internal static void ReadToAllValues(TcAdsClient adsClient, IList<IReadableAddress> addresses)
        {
            if (!addresses.Any())
            {
                throw new InvalidOperationException("addresses should not be empty");
            }

            using (var stream = BatchRead(adsClient, addresses.Select(x => (IAddressable)x).ToList()))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    reader.CheckErrors(addresses.Select(x => (IAddressable)x).ToList());
                    foreach (var address in addresses)
                    {
                        address.UpdateValue(reader);
                    }
                }
            }
        }

        internal static BinaryReader ReadValue(TcAdsClient adsClient, IAddressable address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var addressList = new List<IAddressable>()
            {
                address
            };

            var stream = BatchRead(adsClient, addressList);
            var reader = new BinaryReader(stream);
            reader.CheckErrors(addressList.Select(x => (IAddressable)x).ToList());
            return reader;
        }

        private static AdsStream BatchRead(TcAdsClient adsClient, IList<IAddressable> variables)
        {
            if (!variables.Any())
            {
                throw new InvalidOperationException("Variables should not be empty");
            }

            // Allocate memory
            int rdLength = variables.Count * ErrorSize;
            int wrLength = (SymbolValueByHandleSize + VariableHandleSize + BitSizeSize) * variables.Count;

            // Write data for handles into the ADS Stream
            using (var writer = new BinaryWriter(new AdsStream(wrLength)))
            {
                // Byt till Immutable list!
                foreach (var readableAddress in variables)
                {
                    writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                    writer.Write(readableAddress.Address.VariableHandle);
                    writer.Write(readableAddress.Address.BitSize);
                    rdLength += readableAddress.Address.BitSize;
                }

                // Sum command to read variables from the PLC
                AdsStream dataAndErrorStream = new AdsStream(rdLength);
                adsClient.ReadWrite(0xF080, variables.Count, dataAndErrorStream, (AdsStream)writer.BaseStream);

                // Return the ADS error codes
                return dataAndErrorStream;
            }
        }
    }
}
