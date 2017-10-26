using System;

namespace TestApplication.Server.Contracts
{
    /// <summary>
    /// Исключение, которое должен выбрасывать обработчик команды в случае невозможности ее корректно обработать
    /// </summary>
    public class WebSocketCommandHandlerException : Exception
    {
        public WebSocketCommandHandlerException(string message) : base(message) { }

        public string StatusCode { get; set; }
    }
}
