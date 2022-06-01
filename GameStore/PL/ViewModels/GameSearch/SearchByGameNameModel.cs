using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.GameSearch
{
    public class SearchByGameNameModel
    {
        [Required(ErrorMessage = "Game name is required"), MinLength(3)]
        public string GameName { get; set; }
    }
}
