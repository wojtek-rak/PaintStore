using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class EditUserCredentialsCommand
    {
        public int Id { get; set; }
        public string OldEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewEmail { get; set; }
        public string NewPassword { get; set; }
    }
}
