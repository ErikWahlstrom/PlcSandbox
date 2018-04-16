namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class WriteDoubleArrayValue : WriteableValue<double[]>
    {
        public WriteDoubleArrayValue(UnconnectedAddressBase<double[]> address, ConnectedWriteClient connectedWriteClient, double[] initalValue)
            : base(address, connectedWriteClient)
        {
        }
    }
}
