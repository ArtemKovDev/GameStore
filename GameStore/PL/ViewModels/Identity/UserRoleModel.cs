using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Identity
{
    public class UserRoleModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}
