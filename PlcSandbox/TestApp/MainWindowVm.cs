using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    using TwinCatAdsCommunication;
    using TwinCAT.Ads;

    public class MainWindowVm
    {
        public MainWindowVm()
        {
            var plcCommunicator = new PlcReader();
        }

        public WritableValue<bool> BoolToInspect { get; }
    }

    public class ReadValues
    {
        public ReadValues()
        {
            var connectedClient = ConnectedClient.CreateAndConnect(new AmsNetId("1.2.3.5.1.1"), 851);
            this.IsLightOn = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.IsLightOn, connectedClient));
        }

        public ReadableValue<bool> IsLightOn { get; }
    }

    public class ConnectedReadValues
    {
        public ConnectedReadValues()
        {
            var connectedClient = ConnectedClient.CreateAndConnect(new AmsNetId("1.2.3.5.1.1"), 851);
            this.IsLightOn = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.IsLightOn, connectedClient));
            this.BuildingBoxConnected = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.bBuildingBoxConnected, connectedClient));
            var cyclicReader = new PlcReader(this.IsLightOn, this.BuildingBoxConnected);
        }

        public ReadableValue<bool> BuildingBoxConnected { get; }

        public ReadableValue<bool> IsLightOn { get; }
    }


}
