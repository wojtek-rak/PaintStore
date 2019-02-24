using System;

namespace PaintStore.Domain.Exceptions
{
    public class NegotiatedContentResultException : Exception
    {
        public NegotiatedContentResultException()
            : base() { }
        public NegotiatedContentResultException(string message) 
            : base(message) { }

        public NegotiatedContentResultException(string message, Exception e)
            : base(message, e) { }
    }
}