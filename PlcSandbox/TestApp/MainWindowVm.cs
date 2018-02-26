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
            var plcCommunicator = new PlcReader();
        }

        public WritableValue<bool> BoolToInspect { get; }
    }
}
