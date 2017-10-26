using System;

namespace TestApplication.Server.Contracts
{
    /// <summary>
    /// Базовый класс-обработчик команд, поступающих на веб-сокет сервер
    /// </summary>
    public abstract class WebSocketCommandHandlerBase
    {
        public string Command { get; set; }

        public Type CommandDataType { get; set; }

        public WebSocketCommandHandlerBase()
        {
        }

        public abstract object Handle(WebSocketCommandDataBase data);

        /// <summary>
        /// Создает экземпляр обработчика команд
        /// </summary>
        /// <typeparam name="TCommandHandler">Класс обработчика команд</typeparam>
        /// <typeparam name="TCommandHandlerData">Тип данных для комады</typeparam>
        /// <param name="command">Название команды</param>
        /// <returns></returns>
        public static WebSocketCommandHandlerBase Create<TCommandHandler, TCommandHandlerData>(string command)
            where TCommandHandler : WebSocketCommandHandlerBase, new()
            where TCommandHandlerData : WebSocketCommandDataBase
        {
            var result = new TCommandHandler();
            result.Command = command;
            result.CommandDataType = typeof(TCommandHandlerData);
            return result;
        }
    }
}
