using System.Web.Mvc;

namespace Levelnis.Learning.AutofacExamples.Web.Controllers
{
    using CommandQuery.Factories;
    using CommandQuery.ViewModels;
    using Core.Infrastructure;

    public class SecurityController : Controller
    {
        private readonly IViewModelFactory<bool, SignInViewModel> viewModelFactory;
        private readonly IMembershipProvider membershipProvider;
        private readonly ILogger logger;

        public SecurityController(IViewModelFactory<bool, SignInViewModel> viewModelFactory, IMembershipProvider membershipProvider, ILogger logger)
        {
            this.viewModelFactory = viewModelFactory;
            this.membershipProvider = membershipProvider;
            this.logger = logger;
        }

        public ActionResult SignIn()
        {
            var model = viewModelFactory.Create(true);
            return View(model);
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel model)
        {
            logger.Info("POST *** SecurityController: Entering SignIn: Username={0}, Password={1}", model.Username, model.Password);
            var user = membershipProvider.Find(model.Username, model.Password, true);
            if (user != null)
            {
                membershipProvider.SignIn(user, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }

            model.SignInError = "Your credentials were not recognised. Please try again.";
            return View(model);
        }
    }
}