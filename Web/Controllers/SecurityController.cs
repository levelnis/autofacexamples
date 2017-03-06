using System.Web.Mvc;

namespace Levelnis.Learning.AutofacExamples.Web.Controllers
{
    using CommandQuery.Factories;
    using CommandQuery.ViewModels;
    using Core.Infrastructure;

    public class SecurityController : Controller
    {
        private readonly IViewModelFactory<bool, SignInViewModel> signInViewModelFactory;
        private readonly IViewModelFactory<RegisterViewModel> registerViewModelFactory;
        private readonly IMembershipProvider membershipProvider;
        private readonly ILogger logger;

        public SecurityController(IViewModelFactory<bool, SignInViewModel> signInViewModelFactory, IViewModelFactory<RegisterViewModel> registerViewModelFactory, IMembershipProvider membershipProvider, ILogger logger)
        {
            this.signInViewModelFactory = signInViewModelFactory;
            this.registerViewModelFactory = registerViewModelFactory;
            this.membershipProvider = membershipProvider;
            this.logger = logger;
        }

        public ActionResult SignIn()
        {
            var model = signInViewModelFactory.Create(true);
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

        public ActionResult Register()
        {
            var model = registerViewModelFactory.Create();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = registerViewModelFactory.Create();
                return View(model);
            }

            return RedirectToAction("SignIn");
        }
    }
}