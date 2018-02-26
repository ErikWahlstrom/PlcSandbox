namespace TwinCatAdsCommunication
{
    using System;
    using System.IO;
    using TwinCAT.Ads;

    public class PlcReader
    {
        private readonly IReadableAddress[] variables;

        public PlcReader(params IReadableAddress[] variables)
        {
            this.variables = variables;
        }

        internal void ReadToAllValues(TcAdsClient adsClient)
        {
            using (var stream = this.BatchRead(adsClient))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    reader.CheckErrors(this.variables);
                    foreach (var readableAddress in this.variables)
                    {
                        readableAddress.UpdateValue(reader);
                    }
                }
            }
        }

        private AdsStream BatchRead(TcAdsClient adsClient)
        {
            // Allocate memory
            int rdLength = this.variables.Length * 4;
            int wrLength = this.variables.Length * 12;
            using (

                        // Write data for handles into the ADS Stream
                        BinaryWriter writer = new BinaryWriter(new AdsStream(wrLength)))
            {
                foreach (IReadableAddress readableAddress in this.variables)
                {
                    writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                    writer.Write(readableAddress.Address.BitOffset);
                    writer.Write(readableAddress.Address.BitSize);
                    rdLength += readableAddress.Address.BitSize;
                }

                // Sum command to read variables from the PLC
                AdsStream rdStream = new AdsStream(rdLength);
                adsClient.ReadWrite(0xF080, this.variables.Length, rdStream, (AdsStream)writer.BaseStream);

                // Return the ADS error codes
                return rdStream;
            }
        }
    }
}
