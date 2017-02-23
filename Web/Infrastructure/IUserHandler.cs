namespace Levelnis.Learning.AutofacExamples.Web.Infrastructure
{
    using Core.Entities;

    public interface IUserHandler
    {
        User GetCurrentUser();
    }
}