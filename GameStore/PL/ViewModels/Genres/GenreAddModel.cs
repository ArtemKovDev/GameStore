using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Genres
{
    public class GenreAddModel
    {
        [Required(ErrorMessage = "Genre name is required"), MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}
