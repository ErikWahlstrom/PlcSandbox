namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class ReadableBoolValue : ReadableValue<bool>
    {
        public ReadableBoolValue(UnconnectedAddressBase<bool> address, ConnectedReadClient connectedReadClient)
            : base(address, connectedReadClient)
        {
        }
    }
}
