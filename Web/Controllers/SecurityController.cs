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
        private readonly IViewModelFactory<RegisterFluentViewModel> registerFluentViewModelFactory;
        private readonly IMembershipProvider membershipProvider;
        private readonly ILogger logger;

        public SecurityController(IViewModelFactory<bool, SignInViewModel> signInViewModelFactory, IViewModelFactory<RegisterViewModel> registerViewModelFactory,
            IViewModelFactory<RegisterFluentViewModel> registerFluentViewModelFactory, IMembershipProvider membershipProvider, ILogger logger)
        {
            this.signInViewModelFactory = signInViewModelFactory;
            this.registerViewModelFactory = registerViewModelFactory;
            this.registerFluentViewModelFactory = registerFluentViewModelFactory;
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
            if (ModelState.IsValid)
            {
                // do something here with the model, like saving the user details in the data store

                return RedirectToAction("SignIn");
            }

            model = registerViewModelFactory.Create();
            return View(model);
        }

        public ActionResult RegisterFluent()
        {
            var model = registerFluentViewModelFactory.Create();
            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterFluent(RegisterFluentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // do something here with the model, like saving the user details in the data store

                return RedirectToAction("SignIn");
            }

            model = registerFluentViewModelFactory.Create();
            return View(model);
        }
    }
}