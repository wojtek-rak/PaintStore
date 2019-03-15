using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.Exceptions
{
    public class BadPasswordException : Exception
    {
        public BadPasswordException()
        {
        }

        public BadPasswordException(string message)
            : base(message)
        {
        }

        public BadPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
