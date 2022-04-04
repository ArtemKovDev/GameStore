using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Games
{
    public class GameUpdateModel
    {
        [Required(ErrorMessage = "Game Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Game name is required"), MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required"), MinLength(3), MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Value must be correct")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "ImageUrl is required")]
        public string ImageUrl { get; set; }
    }
}
