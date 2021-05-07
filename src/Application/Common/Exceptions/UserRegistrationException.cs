using System;

namespace CNode.Application.Common.Exceptions
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException(string message)
            : base(message)
        {

        }
    }
}
