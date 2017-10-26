using Newtonsoft.Json;

namespace TestApplication.Server.Contracts.Dto
{
    public class PricesCommandData: WebSocketCommandDataBase
    {
        [JsonProperty("id")]
        public int ItemId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
