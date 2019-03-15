using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class GetUserEmailCommand
    {
        public int UserId { get; set; }
    }
}
