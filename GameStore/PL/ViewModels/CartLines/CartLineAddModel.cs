using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.CartLines
{
    public class CartLineAddModel
    {
        [Required(ErrorMessage = "Game Id is required")]
        public int GameId { get; set; }

        [Required(ErrorMessage = "Order Id is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be correct")]
        public int Quantity { get; set; }
    }
}
