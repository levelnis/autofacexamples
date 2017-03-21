namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        private const string EmailAddressMatchError = "Your email addresses don't match. Please check and re-enter.";
        private const string PasswordMatchError = "Your passwords don't match. Please check and re-enter.";

        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [Compare("EmailAgain", ErrorMessage = EmailAddressMatchError)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please re-enter your email address")]
        [Compare("Email", ErrorMessage = EmailAddressMatchError)]
        public string EmailAgain { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Compare("PasswordAgain", ErrorMessage = PasswordMatchError)]
        [StringLength(20, ErrorMessage = "Your password must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password")]
        [Compare("Password", ErrorMessage = PasswordMatchError)]
        public string PasswordAgain { get; set; }
    }
}