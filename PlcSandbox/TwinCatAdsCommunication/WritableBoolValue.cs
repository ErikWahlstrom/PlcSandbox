namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class WritableBoolValue : WriteableValue<bool>
    {
        public WritableBoolValue(UnconnectedAddressBase<bool> address, ConnectedWriteClient writeClient)
            : base(address, writeClient)
        {
        }
    }
}
