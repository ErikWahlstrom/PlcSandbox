namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class WriteDoubleArray2DValue : WriteableValue<double[,]>
    {
        public WriteDoubleArray2DValue(UnconnectedAddressBase<double[,]> address, ConnectedWriteClient connectedWriteClient, double[,] initialValue)
            : base(address, connectedWriteClient)
        {
        }
    }
}
