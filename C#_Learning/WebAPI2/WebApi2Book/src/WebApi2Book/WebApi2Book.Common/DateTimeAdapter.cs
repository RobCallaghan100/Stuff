namespace WebApi2Book.Common
{
    using System;

    public class DateTimeAdapter : IDateTime
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}