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

            Logger.Debug("Run");

            host.Open();
            Logger.Debug("Wait clients...");
            Console.ReadLine();
            host.Close();
            Logger.Debug("Host closed");
        }
    }
}
