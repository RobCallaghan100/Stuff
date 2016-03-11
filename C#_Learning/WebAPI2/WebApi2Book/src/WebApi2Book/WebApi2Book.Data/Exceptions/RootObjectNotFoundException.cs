namespace WebApi2Book.Data.Exceptions
{
    using System;

    public class RootObjectNotFoundException: Exception
    {
        public RootObjectNotFoundException(string message): base(message)
        {
        }
    }
}
