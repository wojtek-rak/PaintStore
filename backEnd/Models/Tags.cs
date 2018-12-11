using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class Tags
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int Count { get; set; }
    }
}
