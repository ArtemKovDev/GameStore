using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class CartLine : BaseEntity
    {
        public int GameId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
