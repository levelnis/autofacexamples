namespace Levelnis.Learning.AutofacExamples.Web.Validators
{
    using System;
    using CommandQuery.ViewModels;
    using FluentValidation;
    using FluentValidation.Results;

    public class RegisterFluentViewModelValidator : AbstractValidator<RegisterFluentViewModel>
    {
        public RegisterFluentViewModelValidator()
        {
            RuleFor(m => m.Username)
                .NotNull().WithMessage("Please enter your username");
            RuleFor(m => m.Email)
                .NotNull().WithMessage("Please enter your email address")
                .EmailAddress().WithMessage("Please enter a valid email address")
                .Equal(m => m.EmailAgain).WithMessage("Your email addresses don't match. Please check and re-enter.");
            RuleFor(m => m.EmailAgain)
                .NotNull().WithMessage("Please enter your email address again")
                .EmailAddress().WithMessage("Please enter a valid email address again")
                .Equal(m => m.Email).WithMessage("Your email addresses don't match. Please check and re-enter.");
            RuleFor(m => m.Password)
                .NotNull().WithMessage("Please enter your password")
                .Equal(m => m.PasswordAgain).WithMessage("Your passwords don't match. Please check and re-enter.")
                .Length(6, 20).WithMessage("Your password must be at least 6 characters long.");
            RuleFor(m => m.PasswordAgain)
                .NotNull().WithMessage("Please enter your password again")
                .Equal(m => m.Password).WithMessage("Your passwords don't match. Please check and re-enter.");
            RuleFor(m => m.BlogUrl)
                .NotEmpty()
                .WithMessage("Please enter a URL")
                .Must(BeAValidUrl)
                .WithMessage("Invalid URL. Please re-enter");
            RuleFor(m => m.Comments)
                .Must(BeValidComments)
                .WithMessage("Please enter at least 50 characters of comments. If you have nothing to say, please check the checkbox.");
            Custom(OtherCommentsMustBeValid);
        }

        private static ValidationFailure OtherCommentsMustBeValid(RegisterFluentViewModel model, ValidationContext<RegisterFluentViewModel> context)
        {
            context.Selector
            if (model.NoOtherComment) return null;
            return model.OtherComments != null && model.OtherComments.Length >= 50 ? null : 
                new ValidationFailure("OtherComments", "Please enter at least 50 characters of comments. If you have nothing to say, please check the checkbox.");
        }

        private static bool BeValidComments(RegisterFluentViewModel model, string comments)
        {
            if (model.NoComment) return true;
            return comments != null && comments.Length >= 50;
        }

        private static bool BeAValidUrl(string arg)
        {
            Uri result;
            return Uri.TryCreate(arg, UriKind.Absolute, out result);
        }
    }
}