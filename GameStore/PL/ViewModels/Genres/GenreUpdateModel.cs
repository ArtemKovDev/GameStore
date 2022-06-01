using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Genres
{
    public class GenreUpdateModel
    {
        [Required(ErrorMessage = "Genre Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre name is required"), MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}
