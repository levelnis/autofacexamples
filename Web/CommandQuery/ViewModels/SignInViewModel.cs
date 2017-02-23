namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.ViewModels
{
    public class SignInViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool ShowSignIn { get; set; }

        public bool IsSignedIn { get; set; }

        public string SignInError { get; set; }
    }
}