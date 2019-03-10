using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class AddPostCommand
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string ImgLink { get; set; }
        public string Description { get; set; }
    }
}
