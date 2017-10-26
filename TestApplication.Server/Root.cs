using System;
using System.ServiceProcess;
using Microsoft.Practices.Unity;
using ServiceStack.Logging;
using TestApplication.Server.Contracts;
using TestApplication.Server.Entities;

namespace TestApplication.Server
{
    internal static class Root
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Root).Name);

        static bool _isInitialized;
        static IUnityContainer _container;

        internal static IUnityContainer Container
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new InvalidOperationException("CompositionRoot should be initialized first.");
                }
                return _container;
            }
        }


        internal static void Init()
        {
            Logger.Debug("Initializing Composition Root.");
            
            _container = new UnityContainer();
            _container.RegisterType<ServiceBase, Main>();
            _container.RegisterType<ITestServer, TestServer>();
            _container.RegisterType<IPriceRepository, PriceRepository>(); 


            Logger.Debug("Composition Root is initialized.");

            _isInitialized = true;
        }
    }
}
