using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    using TwinCatAdsCommunication;

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
            IsLightOn = new WritableValue<bool>(GeneratedAddress.MAIN.IsLightOn);
        }

        public WritableValue<bool> IsLightOn { get; }
    }


}
