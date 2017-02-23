namespace Levelnis.Learning.AutofacExamples.Web.Infrastructure
{
    using Core.Entities;
    using Core.Infrastructure;

    public class UserHandler : IUserHandler
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMembershipProvider membershipProvider;
        private readonly ILogger logger;

        public UserHandler(IHttpContextAccessor httpContextAccessor, IMembershipProvider membershipProvider, ILogger logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.membershipProvider = membershipProvider;
            this.logger = logger;
        }

        public User GetCurrentUser()
        {
            logger.Info("UserHandler: Entering GetCurrentUser");
            var username = httpContextAccessor.Current.User.Identity.Name;
            var user = membershipProvider.FindByUsername(username);
            return user;
        }
    }
}