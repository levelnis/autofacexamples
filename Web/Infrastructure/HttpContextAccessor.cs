namespace Levelnis.Learning.AutofacExamples.Web.Infrastructure
{
    using System.Web;

    public class HttpContextAccessor : IHttpContextAccessor
    {
        public HttpContextBase Current
        {
            get
            {
                var httpContext = HttpContext.Current;
                return httpContext == null ? null : new HttpContextWrapper(httpContext);
            }
        }

        public HttpRequestBase Request
        {
            get { return Current.Request; }
        }

        public HttpResponseBase Response
        {
            get { return Current.Response; }
        }

        public HttpServerUtilityBase Server
        {
            get { return Current.Server; }
        }
    }
}