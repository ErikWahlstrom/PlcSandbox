using System;
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
            var plcCommunicator = new CyclicReader(TimeSpan.FromMilliseconds(100));
        }

        public WritableValue<bool> BoolToInspect { get; }
    }

    public class LightPlc
    {
        public LightPlc()
        {
            var connectedClient = ConnectedClient.Connected(new AmsNetId("1.2.3.5.1.1"), 851);
            this.IsLightOn = new ReadableValue<bool>(TwincSymbols.ConnectBoolAddress(GeneratedAddress.MAIN.IsLightOn, connectedClient));
        }

        public ReadableValue<bool> IsLightOn { get; }
    }


}
