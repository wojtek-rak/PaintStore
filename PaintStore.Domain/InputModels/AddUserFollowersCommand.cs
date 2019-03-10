using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class AddUserFollowersCommand
    {
        public int FollowedUserId { get; set; }
        public int FollowingUserId { get; set; }
    }
}
