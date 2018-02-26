namespace TwinCatAdsCommunication
{
    using System.IO;
    using TwinCAT.Ads;

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
