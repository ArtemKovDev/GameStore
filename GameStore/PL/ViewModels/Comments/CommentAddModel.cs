using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Comments
{
    public class CommentAddModel
    {
        [Required(ErrorMessage = "CommentText is required"), MinLength(3), MaxLength(200)]
        public string CommentText { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = "GameId is required")]
        public int GameId { get; set; }

        [Required(ErrorMessage = "RegisteredUserId is required")]
        public int RegisteredUserId { get; set; }
    }
}
