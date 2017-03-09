namespace Levelnis.Learning.AutofacExamples.Web.Validators
{
    using CommandQuery.ViewModels;
    using FluentValidation;

    public class RegisterFluentViewModelValidator : AbstractValidator<RegisterFluentViewModel>
    {
        public RegisterFluentViewModelValidator()
        {
            RuleFor(m => m.Username)
                .NotNull().WithMessage("Please enter your username");
            RuleFor(m => m.Email)
                .NotNull().WithMessage("Please enter your email address")
                .EmailAddress().WithMessage("Please enter a valid email address")
                .NotEqual(m => m.EmailAgain).WithMessage("Your email addresses don't match. Please check and re-enter.");
            RuleFor(m => m.EmailAgain)
                .NotNull().WithMessage("Please enter your email address again")
                .EmailAddress().WithMessage("Please enter a valid email address again")
                .NotEqual(m => m.Email).WithMessage("Your email addresses don't match. Please check and re-enter.");
            RuleFor(m => m.Password)
                .NotNull().WithMessage("Please enter your password")
                .NotEqual(m => m.PasswordAgain).WithMessage("Your passwords don't match. Please check and re-enter.")
                .Length(6, 20).WithMessage("Your password must be at least 6 characters long.");
            RuleFor(m => m.PasswordAgain)
                .NotNull().WithMessage("Please enter your password again")
                .NotEqual(m => m.Password).WithMessage("Your passwords don't match. Please check and re-enter.");
        }
    }
}