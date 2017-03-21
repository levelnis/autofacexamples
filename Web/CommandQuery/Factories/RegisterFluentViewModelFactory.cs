namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.Factories
{
    using ViewModels;

    public class RegisterFluentViewModelFactory : IViewModelFactory<RegisterFluentViewModel>
    {
        public RegisterFluentViewModel Create()
        {
            return new RegisterFluentViewModel();
        }
    }
}