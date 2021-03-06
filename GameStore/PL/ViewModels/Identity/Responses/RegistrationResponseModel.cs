using System.Collections.Generic;

namespace PL.ViewModels.Identity.Responses
{
    public class RegistrationResponseModel
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
