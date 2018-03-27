namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class WritableStringValue : WriteableValue<string>
    {
        public WritableStringValue(UnconnectedAddressBase<string> address, ConnectedWriteClient writeClient)
            : base(address, writeClient)
        {
        }
    }
}