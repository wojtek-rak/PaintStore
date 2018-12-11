using System;
using System.Collections.Generic;
using backEnd.Interfaces;

namespace backEnd.Models
{
    public partial class Posts : IPosts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserOwnerName { get; set; }
        public string Title { get; set; }
        public string ImgLink { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public int CommentsCount { get; set; }
        public int PopularActivity { get; set; }
        public int NewestActivity { get; set; }
        public int MixedActivity { get; set; }
        public bool? Edited { get; set; }
        //TEMP
        //public int CategoryToolId { get; set; }
        //public int CategoryTypeId { get; set; }
    }
}
