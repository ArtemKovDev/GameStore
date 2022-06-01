using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.UserComments
{
    public class UserCommentAddModel
    {
        [Required(ErrorMessage = "CommentText is required"), MinLength(3), MaxLength(200)]
        public string CommentText { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = "GameId is required")]
        public int GameId { get; set; }
    }
}
