namespace Levelnis.Learning.AutofacExamples.Web.CommandQuery.Factories
{
    public interface IViewModelFactory<in TInput, out TViewModel>
    {
        TViewModel Create(TInput input);
    }

    public interface IViewModelFactory<out TViewModel>
    {
        TViewModel Create();
    }
}