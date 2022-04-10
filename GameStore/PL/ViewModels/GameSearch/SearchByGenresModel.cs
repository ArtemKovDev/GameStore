using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.GameSearch
{
    public class SearchByGenresModel
    {
        [Required(ErrorMessage = "Genres are required")]
        public int[] GenreIds { get; set; }
    }
}
