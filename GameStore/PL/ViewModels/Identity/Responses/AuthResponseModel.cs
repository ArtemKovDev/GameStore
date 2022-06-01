namespace PL.ViewModels.Identity.Responses
{
    public class AuthResponseModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
