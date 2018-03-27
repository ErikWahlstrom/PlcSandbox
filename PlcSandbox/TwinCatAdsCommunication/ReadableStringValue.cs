namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class ReadableStringValue : ReadableValue<string>
    {
        public ReadableStringValue(UnconnectedAddressBase<string> address, ConnectedReadClient connectedReadClient)
            : base(address, connectedReadClient)
        {
        }
    }
}
