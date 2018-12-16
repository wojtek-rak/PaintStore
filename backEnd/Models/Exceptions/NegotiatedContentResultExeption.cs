using System;

namespace backEnd.Exceptions
{
    public class NegotiatedContentResultExeption : Exception
    {
        //public T Content { get; set; }

        //public NegotiatedContentResultExeption(T content)
        //    : base()
        //{
        //    Content = content;
        //}
        public NegotiatedContentResultExeption()
            : base() { }
        public NegotiatedContentResultExeption(string message) 
            : base(message) { }

        public NegotiatedContentResultExeption(string message, Exception e)
            : base(message, e) { }
    }
}