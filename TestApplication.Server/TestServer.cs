using System;
using TestApplication.Server.Contracts;
using ServiceStack.Logging;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TestApplication.Server
{
    public class TestServer : ITestServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TestServer).Name);
        private WebSocketServer Wss;

        public void Start()
        {
            Wss = new WebSocketServer(8088);
            Wss.AddWebSocketService<WebsocketTestService>("/wstest");

            Wss.Log.Level = LogLevel.Trace;
            Wss.Start();
            if (Wss.IsListening)
            {
                Console.WriteLine($"Listening on port {Wss.Port}, and providing WebSocket services:");
                foreach (var path in Wss.WebSocketServices.Paths)
                {
                    Console.WriteLine("- " + path);
                }
            }

            Logger.Info("Server is started.");
        }

        public void Stop()
        {
            Wss.Stop();
            Logger.Info("Server is stopped.");
        }
    }
}
