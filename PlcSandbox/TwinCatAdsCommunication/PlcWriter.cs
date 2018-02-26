namespace TwinCatAdsCommunication
{
    using System.IO;
    using TwinCAT.Ads;

    public class PlcWriter
    {
        private readonly IWritableAddress[] variables;

        public PlcWriter(params IWritableAddress[] variables)
        {
            this.variables = variables;
        }

        internal void ReadAllValues(TcAdsClient writeClient)
        {
            using (var stream = this.BatchWrite(writeClient))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    reader.CheckErrors(this.variables);
                }
            }
        }

        internal AdsStream BatchWrite(TcAdsClient adsClient)
        {
            // Allocate memory
            int rdLength = this.variables.Length * 4;
            int wrLength = (this.variables.Length * 12) + 7; // Kolla den här med befintligt komm. Finns några mer logiska siffror (dock samma) att använda
            using (var writer = new BinaryWriter(new AdsStream(wrLength)))
            {
                // Write data for handles into the ADS stream
                foreach (IWritableAddress writableAddress in this.variables)
                {
                    writer.Write((int)AdsReservedIndexGroups.SymbolValueByHandle);
                    writer.Write(writableAddress.Address.BitOffset);
                    writer.Write(writableAddress.Address.BitSize);
                }

                foreach (IWritableAddress writableAddress in this.variables)
                {
                    writableAddress.WriteValueToStream(writer);
                }

                // Sum command to write the data into the PLC
                AdsStream rdStream = new AdsStream(rdLength);
                adsClient.ReadWrite(0xF081, this.variables.Length, rdStream, (AdsStream)writer.BaseStream);

                foreach (var writableAddress in this.variables)
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
