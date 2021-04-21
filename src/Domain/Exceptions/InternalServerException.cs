using System;

namespace CNode.Domain.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string? message)
            : base(message)
        {

        }
    }
}
