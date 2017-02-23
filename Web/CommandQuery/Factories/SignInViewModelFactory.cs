namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.Factories
{
    using Core.Infrastructure;
    using Infrastructure;
    using ViewModels;

    public class SignInViewModelFactory : IViewModelFactory<bool, SignInViewModel>
    {
        private readonly IUserHandler userHandler;
        private readonly ILogger logger;

        public SignInViewModelFactory(IUserHandler userHandler, ILogger logger)
        {
            this.userHandler = userHandler;
            this.logger = logger;
        }

        public SignInViewModel Create(bool input)
        {
            logger.Info("UserDetailsViewModelFactory: Entering Create");
            var user = userHandler.GetCurrentUser();
            return new SignInViewModel
            {
                ShowSignIn = input,
                IsSignedIn = user != null
            };
        }
    }
}