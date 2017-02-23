namespace Levelnis.Learning.AutofacExamples.Core.Infrastructure
{
    using Entities;

    public class MembershipProvider : IMembershipProvider
    {
        public User FindByUsername(string username)
        {
            return username == "dave" ? new User {UserName = "dave"} : null;
        }

        public User Find(string username, string password, bool rememberMe)
        {
            return username == "dave" ? new User { UserName = "dave", PasswordHash = password } : null;
        }

        public void SignIn(User user, bool persist)
        {
        }
    }
}