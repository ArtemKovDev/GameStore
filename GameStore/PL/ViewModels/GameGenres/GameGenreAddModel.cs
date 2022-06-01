using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.GameGenres
{
    public class GameGenreAddModel
    {
        [Required(ErrorMessage = "GameId is required")]
        public int GameId { get; set; }

        [Required(ErrorMessage = "GenreId is required")]
        public int GenreId { get; set; }
    }
}
