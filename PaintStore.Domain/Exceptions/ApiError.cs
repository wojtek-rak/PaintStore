using System.Collections.Generic;
using System.Linq;

namespace PaintStore.Domain.Exceptions
{
    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
        public object Data { get; set; }

        private IDictionary<string, string[]> Errors { get; set; }

        public ApiError(string message)
        {
            Message = message;
            IsError = true;
        }

        //public ApiError(ModelStateDictionary modelState)
        //{
        //    IsError = true;

        //    Errors = modelState.ToDictionary(
        //        kvp => kvp.Key,
        //        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //}
    }
}
