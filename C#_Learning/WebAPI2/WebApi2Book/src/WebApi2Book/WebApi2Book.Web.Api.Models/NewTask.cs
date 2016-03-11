namespace WebApi2Book.Web.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class NewTask
    {
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public List<User> Assignees { get; set; } 
    }
}
