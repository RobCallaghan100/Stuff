namespace WebApi2Book.Common
{
    using System.Web.Http.Filters;

    public interface IActionTransactionHelper
    {
        void BeginTransaction();
        void EndTransaction(HttpActionExecutedContext filterContext);
        void CloseSession();
    }
}
