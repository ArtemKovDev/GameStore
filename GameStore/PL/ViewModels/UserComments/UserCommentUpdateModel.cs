using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.UserComments
{
    public class UserCommentUpdateModel
    {
        [Required(ErrorMessage = "CommentId is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "CommentText is required"), MinLength(3), MaxLength(200)]
        public string CommentText { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = "GameId is required")]
        public int GameId { get; set; }
    }
}
