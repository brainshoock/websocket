
namespace TestApplication.Server.Contracts.Dto
{
    public class ClientResponse
    {
        /// <summary>
        /// Статус обработки команды (OK - все в порядке, ERROR - ошибка)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Сообщение об ошибке для чтения человеком
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Данные ответа
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// В ответ на какую команду высылается данный ответ
        /// </summary>
        public string Command { get; set; }

        public static ClientResponse Success(string command, object data)
        {
            return new ClientResponse
            {
                Status = "OK",
                Data = data,
                Command = command
            };
        }

        public static ClientResponse Error(string command = null, string message = null, object data = null)
        {
            return new ClientResponse
            {
                Status = "ERROR",
                Message = message,
                Data = data,
                Command = command
            };
        }

        public static ClientResponse Error(string command, WebSocketCommandHandlerException ex)
        {
            return Error(command, ex.Message, ex.Data);
        }
    }
}
