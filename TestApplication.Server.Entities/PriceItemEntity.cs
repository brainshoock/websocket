using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Server.Entities
{
    [Table("PriceItems")]
    public class PriceItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}
