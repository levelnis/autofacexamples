namespace Levelnis.Learning.AutofacExamples.Core.Infrastructure
{
    using Entities;

    public interface IMembershipProvider
    {
        User FindByUsername(string username);
        User Find(string username, string password, bool rememberMe);
        void SignIn(User user, bool persist);
    }
}