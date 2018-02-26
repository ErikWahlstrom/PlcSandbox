namespace TwinCatAdsCommunication
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using TwinCatAdsCommunication.Address;
    using TwinCAT.Ads;

    internal static class AdsStreamExtension
    {
        internal static void CheckErrors(this BinaryReader reader, IList<IAddressable> variables)
        {
            for (int i = 0; i < variables.Count; i++)
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
