using System;

namespace SchedulerServices.Builders
{
    public interface IQueryStringBuilder
    {
        string BuildQueryString(string epicCode, DateTime dateTime);
        string BuildQueryString(string epicCode, DateTime fromDate, DateTime toDate);
    }
}