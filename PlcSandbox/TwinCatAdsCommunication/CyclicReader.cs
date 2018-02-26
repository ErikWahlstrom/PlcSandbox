namespace TwinCatAdsCommunication
{
    using System;
    using System.IO;
    using TwinCAT.Ads;

    public class CyclicReader
    {
        public CyclicReader(TimeSpan fromMilliseconds, params IReadableAddress[] variables)
        {
            TwinCAT.Ads.TcAdsClient client = new TcAdsClient();
            this.ReadToAllValues(variables, client);
        }

        private void ReadToAllValues(IReadableAddress[] variables, TcAdsClient adsClient)
        {
            var stream = this.BatchRead(variables, adsClient);
            BinaryReader reader = new BinaryReader(stream);
            reader.CheckErrors(variables);
            foreach (var readableAddress in variables)
            {
                readableAddress.UpdateValue(reader);
            }
        }

        private AdsStream BatchRead(IReadableAddress[] variables, TcAdsClient adsClient)
        {
            // Allocate memory
            int rdLength = variables.Length * 4;
            int wrLength = variables.Length * 12;

            // Write data for handles into the ADS Stream
            BinaryWriter writer = new BinaryWriter(new AdsStream(wrLength));
            for (int i = 0; i < variables.Length; i++)
            {
                writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                writer.Write(variables[i].Address.BitOffset);
                writer.Write(variables[i].Address.BitSize);
                rdLength += variables[i].Address.BitSize;
            }

            // Sum command to read variables from the PLC
            AdsStream rdStream = new AdsStream(rdLength);
            adsClient.ReadWrite(0xF080, variables.Length, rdStream, (AdsStream)writer.BaseStream);

            // Return the ADS error codes
            return rdStream;
        }
    }

    public class CyclicWriter
    {
        public CyclicWriter(TimeSpan fromMilliseconds, params IWritableAddress[] variables)
        {
            var client = new TcAdsClient();
            var errorStream = this.BatchWrite(variables, client);
            using (var reader = new BinaryReader(errorStream))
            {
                reader.CheckErrors(variables);
            }
        }

        private AdsStream BatchWrite(IWritableAddress[] variables, TcAdsClient adsClient)
        {
            // Allocate memory
            int rdLength = variables.Length * 4;
            int wrLength = variables.Length * 12 + 7; //Skumt?

            BinaryWriter writer = new BinaryWriter(new AdsStream(wrLength));

            // Write data for handles into the ADS stream
            foreach (var writableAddress in variables)
            {
                writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                writer.Write(writableAddress.Address.BitOffset);
                writer.Write(writableAddress.Address.BitSize);
            }

            foreach (var writableAddress in variables)
            {
                writableAddress.WriteValueToStream(writer);
            }

            // Sum command to write the data into the PLC
            AdsStream rdStream = new AdsStream(rdLength);
            adsClient.ReadWrite(0xF081, variables.Length, rdStream, (AdsStream)writer.BaseStream);

            foreach (var writableAddress in variables)
            {
                writableAddress.NotifyWritten();
            }

            // Return the ADS error codes
            return rdStream;
        }
    }

    public static class AdsStreamExtension
    {
        public static void CheckErrors(this BinaryReader reader, IAddressable[] variables)
        {
            for (int i = 0; i < variables.Length; i++)
            {
                int error = reader.ReadInt32();
                if (error != (int)AdsErrorCode.NoError)
                {
                    variables[i].Error = (AdsErrorCode) error;
                    System.Diagnostics.Debug.WriteLine($"Unable to read variable {i} (Error = {error})");
                }
            }
        }
    }
}
