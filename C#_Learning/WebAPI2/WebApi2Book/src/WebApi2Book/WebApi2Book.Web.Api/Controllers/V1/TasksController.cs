using System.Net.Http;
using System.Web.Http;
using WebApi2Book.Common.Routing;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.Controllers.V1
{
    using Common;

    [ApiVersion1RoutePrefix("tasks")]   
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        [Route("", Name = "AddTaskRoute")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            return new Task
            {
                Subject = "In v1, newTask.subject = " + newTask.Subject
            };
        }
    }
}
