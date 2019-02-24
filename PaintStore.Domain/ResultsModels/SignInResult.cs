using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.ResultsModels
{
    public class SignInResult
    {
        public int UserId { get; set; }
        public int Token { get; set; }
    }
}
