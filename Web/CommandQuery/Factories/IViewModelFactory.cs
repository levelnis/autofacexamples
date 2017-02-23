namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.Factories
{
    public interface IViewModelFactory<in TInput, out TViewModel>
    {
        TViewModel Create(TInput input);
    }
}