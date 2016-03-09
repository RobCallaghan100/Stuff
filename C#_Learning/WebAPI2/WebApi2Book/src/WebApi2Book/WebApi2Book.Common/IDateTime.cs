namespace WebApi2Book.Common
{
    using System;

    public interface IDateTime
    {
        DateTime UtcNow { get;  }
    }
}