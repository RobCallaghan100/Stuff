namespace WebApi2Book.Web.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class NewTaskV2
    {
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public User Assignee { get; set; }
    }
}
    