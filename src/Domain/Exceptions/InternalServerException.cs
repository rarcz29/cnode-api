using System;

namespace GitNode.Domain.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string message)
            : base(message)
        {

        }
    }
}
