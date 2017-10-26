using WebSocketSharp;
using WebSocketSharp.Server;
using TestApplication.Server.Contracts;
using TestApplication.Server.CommandHandlers;
using System.Collections.Generic;
using TestApplication.Server.Contracts.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using ServiceStack.Logging;
using TestApplication.Server.Entities;
using System.Linq;
using Microsoft.Practices.Unity;

namespace TestApplication.Server
{
    public class WebsocketTestService: WebSocketBehavior
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WebsocketTestService).Name);

        IList<WebSocketCommandHandlerBase> availableCommands = new[]
        {
            WebSocketCommandHandlerBase.Create<PricesCommandHandler, PricesCommandData>(WebSocketCommandList.SendPricesCommand),
        };

        protected override void OnMessage(MessageEventArgs e)
        {
            object edata = null;
            ClientResponse response = null;
            WebSocketCommandHandlerBase command = null;
            try
            {
                edata = JsonConvert.DeserializeObject(e.Data);

                // если в дальнейшем указывать имя команды в запросе - можно выбирать из доступных (availableCommands)
                var ch = availableCommands[0];
                var data = edata == null ? null : (edata as JObject).ToObject(ch.CommandDataType) as WebSocketCommandDataBase;

                // собственно обработка команды
                var cmdResult = ch.Handle(data);

                // броадкастим сообщение топ цен
                var priceRepository = Root.Container.Resolve<IPriceRepository>();
                var top10 = priceRepository.GetTop10();

                var top10Items = top10.Select(x => new PricesCommandData
                {
                    ItemId = x.ItemId,
                    Amount = x.Amount,
                    Price = x.Price
                });

                var json = JsonConvert.SerializeObject(ClientResponse.Success("Top10", top10Items));
                Sessions.Broadcast(json);

                response = ClientResponse.Success(ch.Command, cmdResult);
            }
            catch (WebSocketCommandHandlerException ex)
            {
                Logger.Error(ex);
                response = ClientResponse.Error(command?.Command, ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                response = ClientResponse.Error(command?.Command, "Internal server error");
            }

            var responseStr = JsonConvert.SerializeObject(response);
            
            Send(responseStr);
        }
    }
}
