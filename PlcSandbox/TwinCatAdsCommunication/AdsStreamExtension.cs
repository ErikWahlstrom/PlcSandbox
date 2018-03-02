namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
                    variables[i].Exception = new Exception($"Error accessing value {variables[i].Address.Name}: {(AdsErrorCode)error}");
                    System.Diagnostics.Debug.WriteLine($"Unable to read variable {i} (Error = {error})");
                }
            }
        }
    }
}
