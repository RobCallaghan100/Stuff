namespace WebApi2Book.Data.Exceptions
{
    using System;

    public class ChildObjectNotFoundException : Exception
    {
        public ChildObjectNotFoundException(string message) : base(message)
        {
        }
    }
}
