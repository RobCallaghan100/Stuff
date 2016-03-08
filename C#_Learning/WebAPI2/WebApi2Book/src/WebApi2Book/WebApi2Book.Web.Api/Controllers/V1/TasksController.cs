using System.Net.Http;
using System.Web.Http;
using WebApi2Book.Common.Routing;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    public class TasksController : ApiController
    {
        public Task AddTask(HttpRequestMessage requestMessage, Task newTask)
        {
            return new Task
            {
                Subject = "In v1, newTask.subject = " + newTask.Subject
            };
        }
    }
}
