using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class SConsole
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main()
        {

            ServiceHost host = new ServiceHost(typeof(Service));


            Console.WriteLine(@"   _____ _              _____ _           _    _____                          ");
            Console.WriteLine(@"  / ____| |            / ____| |         | |  / ____|                         ");
            Console.WriteLine(@" | (___ | |_ ___ _ __ | |    | |__   __ _| |_| (___   ___ _ ____   _____ _ __ ");
            Console.WriteLine(@"  \___ \| __/ _ \ '_ \| |    | '_ \ / _` | __|\___ \ / _ \ '__\ \ / / _ \ '__|");
            Console.WriteLine(@"  ____) | ||  __/ |_) | |____| | | | (_| | |_ ____) |  __/ |   \ V /  __/ |   ");
            Console.WriteLine(@" |_____/ \__\___| .__/ \_____|_| |_|\__,_|\__|_____/ \___|_|    \_/ \___|_|   ");
            Console.WriteLine(@"                | |                                                           ");
            Console.WriteLine(@"                |_|                                                           ");








            Logger.Debug("StepChat Server ");
            Logger.Debug("Service starting...");
            Logger.Debug("Service ready. Press Enter to stop");
            Logger.Debug("Wait client...");
            host.Open();
            Console.Read();
            host.Close();
            Logger.Debug("Host closed");
        }
    }
}
