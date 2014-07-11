using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
namespace IstMvcFramework.ExceptionUtilities
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CommonBusinessException)
            {
                string message = IstUtilityException.GetCaresExceptionMessage(context.Exception as CommonBusinessException);
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(message),
                    ReasonPhrase = message
                };
                context.Response = resp;
            }
        }
    }
}