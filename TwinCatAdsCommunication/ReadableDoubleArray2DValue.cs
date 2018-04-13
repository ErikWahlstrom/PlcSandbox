namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class ReadableDoubleArray2DValue : ReadableValue<double[,]>
    {
        public ReadableDoubleArray2DValue(UnconnectedAddressBase<double[,]> address, ConnectedReadClient connectedReadClient)
            : base(address, connectedReadClient)
        {
        }
    }
}
