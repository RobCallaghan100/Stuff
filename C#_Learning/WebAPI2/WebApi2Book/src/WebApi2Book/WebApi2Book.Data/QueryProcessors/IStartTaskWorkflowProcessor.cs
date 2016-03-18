
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Data.QueryProcessors
{
    public interface IStartTaskWorkflowProcessor
    {
        Task StartTask(long taskId);
    }
}
