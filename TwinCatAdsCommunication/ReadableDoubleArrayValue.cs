namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class ReadableDoubleArrayValue : ReadableValue<double[]>
    {
        public ReadableDoubleArrayValue(UnconnectedAddressBase<double[]> address, ConnectedReadClient connectedReadClient)
            : base(address, connectedReadClient)
        {
        }
    }
}
