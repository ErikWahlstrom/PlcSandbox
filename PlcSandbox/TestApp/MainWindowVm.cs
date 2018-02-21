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
            BoolToInspect = new ManipulationClass<bool>(GeneratedAddress.MAIN.IsLightOn);
        }

        public ManipulationClass<bool> BoolToInspect { get; }
    }
}
