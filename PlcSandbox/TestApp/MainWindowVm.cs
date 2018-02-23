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

        public BindableValue<bool> BoolToInspect { get; }
    }

    public class LightPlc
    {
        public LightPlc()
        {
            IsLightOn = new BindableValue<bool>(GeneratedAddress.MAIN.IsLightOn);
        }

        public BindableValue<bool> IsLightOn { get; }
    }


}
