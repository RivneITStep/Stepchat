using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace StepChatServer
{
    public partial class StepChatServer : ServiceBase
    {
        ServiceHost host;
        public StepChatServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(Service.Service));
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
