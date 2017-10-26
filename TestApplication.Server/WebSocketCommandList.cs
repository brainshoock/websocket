using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Server
{
    /// <summary>
    /// Список возможных команд, посылаемых клиентом веб-сокет сервису
    /// </summary>
    static class WebSocketCommandList
    {
        /// <summary>
        /// Отправка данных по ценам
        /// </summary>
        public const string SendPricesCommand = "SendPricesCommand";
    }
}
