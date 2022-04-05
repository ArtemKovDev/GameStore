using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.GameGenres
{
    public class GameGenreUpdateModel
    {
        [Required(ErrorMessage = "GameGenreId is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "GameId is required")]
        public int GameId { get; set; }

        [Required(ErrorMessage = "GenreId is required")]
        public int GenreId { get; set; }
    }
}
