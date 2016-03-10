﻿using System.Net.Http;
using System.Web.Http;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.Controllers.V2
{
    using Common;

    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        [Route("", Name="AddTaskRouteV2")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, Models.Task newTask)
        {
            return new Task
            {
                Subject = "In v2, newTask.subject = " + newTask.Subject
            };
        }
    }
}
