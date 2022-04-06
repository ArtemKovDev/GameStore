using System.Collections.Generic;

namespace PL.ViewModels.Identity.Responses
{
    public class RoleAssignmentResponseModel
    {
        public bool IsRoleAssignmentSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
