using System.ServiceProcess;
using Microsoft.Practices.Unity;
using TestApplication.Server.Contracts;

namespace TestApplication.Server
{
    partial class Main : ServiceBase
    {
        [Dependency]
        public ITestServer Service { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Service.Start();
        }

        protected override void OnStop()
        {
            Service.Stop();
        }
    }
}
