namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.ViewModels
{
    public class RegisterFluentViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmailAgain { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string BlogUrl { get; set; }
        public string Comments { get; set; }
        public bool NoComment { get; set; }
        public string OtherComments { get; set; }
        public bool NoOtherComment { get; set; }
    }
}