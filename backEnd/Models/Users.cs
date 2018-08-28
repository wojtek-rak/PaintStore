using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string AvatarImgLink { get; set; }
        public string BackgroundImgLink { get; set; }
        public string About { get; set; }
    }
}
