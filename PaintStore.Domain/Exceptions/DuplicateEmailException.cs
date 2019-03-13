using System;
namespace PaintStore.Domain.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException()
        {
        }

        public DuplicateEmailException(string message)
            : base(message)
        {
        }

        public DuplicateEmailException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
