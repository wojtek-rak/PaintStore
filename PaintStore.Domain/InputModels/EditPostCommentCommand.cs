using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class EditPostCommentCommand
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
