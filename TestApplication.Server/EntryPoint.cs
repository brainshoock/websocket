using System;
using System.ServiceProcess;
using Microsoft.Practices.Unity;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using TestApplication.Server.Contracts;

namespace TestApplication.Server
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            LogManager.LogFactory = new Log4NetFactory(true);
            Root.Init();

            if (Environment.UserInteractive)
            {
                Console.WriteLine("Server is starting...");

                var server = Root.Container.Resolve<ITestServer>();
                server.Start();

                Console.WriteLine("Server is started. Press any key to stop...");
                Console.ReadKey();
                Console.WriteLine("Server is stopping...");

                server.Stop();

                Console.WriteLine("Server is stopped. Press any key to exit...");
                Console.ReadKey();
            }
            else
            {
                ServiceBase.Run(new[] { Root.Container.Resolve<ServiceBase>() });
            }
        }
    }
}
