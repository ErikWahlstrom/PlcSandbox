namespace TwinCatAdsCommunication
{
    using System;
    using System.IO;
    using TwinCAT.Ads;

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
            for (int i = 0; i < variables.Length; i++)
            {
                writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                writer.Write(variables[i].Address.BitOffset);
                writer.Write(variables[i].Address.BitSize);
            }

            for (int i = 0; i < variables.Length; i++)
            {
                variables[i].WriteValueToStream(writer);
            }

            // Sum command to write the data into the PLC
            AdsStream rdStream = new AdsStream(rdLength);
            adsClient.ReadWrite(0xF081, variables.Length, rdStream, (AdsStream)writer.BaseStream);

            foreach (var writableAddress in variables)
            {
                // Ska vi signalera här?
                writableAddress.
            }

            // Return the ADS error codes
            return rdStream;
        }
    }
}