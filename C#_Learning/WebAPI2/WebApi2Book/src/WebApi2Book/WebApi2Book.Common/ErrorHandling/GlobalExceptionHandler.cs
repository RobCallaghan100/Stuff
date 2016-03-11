namespace WebApi2Book.Common.ErrorHandling
{
    using System.Net;
    using System.Web;
    using System.Web.Http.ExceptionHandling;
    using Data.Exceptions;

    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new SimpleErrorResult(context.Request, 
                    (HttpStatusCode) httpException.GetHttpCode(),
                    httpException.Message);
            }

            if (exception is RootObjectNotFoundException)
            {
                context.Result= new SimpleErrorResult(context.Request, HttpStatusCode.NotFound, exception.Message);
                return;
            }

            if (exception is ChildObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }

            context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError, exception.Message);
        }
    }
}
