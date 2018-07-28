using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string UserPath { get; set; }
        public string ImgLink { get; set; }
    }
}
