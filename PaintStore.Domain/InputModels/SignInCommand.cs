using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class SignInCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
