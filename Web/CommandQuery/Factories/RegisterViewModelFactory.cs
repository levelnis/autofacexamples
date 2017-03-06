namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.Factories
{
    using ViewModels;

    public class RegisterViewModelFactory : IViewModelFactory<RegisterViewModel>
    {
        public RegisterViewModel Create()
        {
            return new RegisterViewModel();
        }
    }
}