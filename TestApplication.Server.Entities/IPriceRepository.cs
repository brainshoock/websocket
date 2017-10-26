
namespace TestApplication.Server.Entities
{
    public interface IPriceRepository
    {
        PriceItemEntity Add(PriceItemEntity entity);

        PriceItemEntity[] GetTop10();
    }
}
