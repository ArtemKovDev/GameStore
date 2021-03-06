using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Identity
{
    public class UserUpdateModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }
    }
}
