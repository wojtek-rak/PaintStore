using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class Images
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category_type { get; set; }
        public string Category_tool { get; set; }
        public string ImgLink { get; set; }
        public string ImgSrc { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string OwnerPath { get; set; }
    }
}
