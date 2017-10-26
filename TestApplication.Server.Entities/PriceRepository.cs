using System;
using System.Linq;

namespace TestApplication.Server.Entities
{
    public class PriceRepository : IPriceRepository
    {
        public PriceItemEntity Add(PriceItemEntity entity)
        {
            using (var db = new DefaultDbContext())
            {
                var item = new PriceItemEntity
                {
                    ItemId = entity.ItemId,
                    Amount = entity.Amount,
                    Price = entity.Price
                };

                db.PriceItems.Add(item);
                db.SaveChanges();

                return item;
            }
        }

        public PriceItemEntity[] GetTop10()
        {
            using (var db = new DefaultDbContext())
            {
                return db.PriceItems.OrderByDescending(x => x.Price).Take(10).ToArray();
            }
        }
    }
}
