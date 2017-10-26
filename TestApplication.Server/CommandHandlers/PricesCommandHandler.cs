using TestApplication.Server.Contracts.Dto;
using TestApplication.Server.Contracts;
using TestApplication.Server.Entities;
using ServiceStack.Logging;
using System;
using Microsoft.Practices.Unity;

namespace TestApplication.Server.CommandHandlers
{
    class PricesCommandHandler : WebSocketCommandHandlerBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PricesCommandHandler).Name);

        public override object Handle(WebSocketCommandDataBase data)
        {
            var cmd = data as PricesCommandData;
            var priceRepository = Root.Container.Resolve<IPriceRepository>();

            try
            {
                var entity = new PriceItemEntity
                {
                    ItemId = cmd.ItemId,
                    Amount = cmd.Amount,
                    Price = cmd.Price
                };

                priceRepository.Add(entity);

                return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw new WebSocketCommandHandlerException("Internal server error");
            }            
        }
    }
}
