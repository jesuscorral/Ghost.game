using System;

namespace Ghost.Core.Exceptions
{
    public class NullRequestException<T> : Exception
    {
        public NullRequestException()
            : base($"Service Request {typeof(T).Name} cannot be null.")
        {
        }
    }
}