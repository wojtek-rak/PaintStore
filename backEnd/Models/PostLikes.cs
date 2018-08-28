using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class PostLikes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
