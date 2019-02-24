using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class AddUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
