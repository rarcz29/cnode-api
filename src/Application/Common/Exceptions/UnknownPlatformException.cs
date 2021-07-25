using System;

namespace GitNode.Application.Common.Exceptions
{
    public class UnknownPlatformException : Exception
    {
        public UnknownPlatformException() { }

        public UnknownPlatformException(string message) : base(message) { }

        public UnknownPlatformException(string message, Exception inner) : base(message, inner) { }
    }
}
