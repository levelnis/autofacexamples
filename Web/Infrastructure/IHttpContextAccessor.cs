namespace Levelnis.Learning.AutofacExamples.Web.Infrastructure
{
    using System.Web;

    public interface IHttpContextAccessor
    {
        HttpContextBase Current { get; }

        HttpRequestBase Request { get; }

        HttpResponseBase Response { get; }

        HttpServerUtilityBase Server { get; }
    }
}