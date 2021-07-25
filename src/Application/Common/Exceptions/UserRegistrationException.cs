using System;

namespace GitNode.Application.Common.Exceptions
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException(string message)
            : base(message)
        {

        }
    }
}
