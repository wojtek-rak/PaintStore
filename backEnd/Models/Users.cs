using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Link { get; set; }
        public string AvatarSrc { get; set; }
        public string BackgroundSrc { get; set; }
        public string About { get; set; }
    }
}
