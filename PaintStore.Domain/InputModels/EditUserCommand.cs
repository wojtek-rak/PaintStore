using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Domain.InputModels
{
    public class EditUserCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string AvatarImgLink { get; set; }
        public string BackgroundImgLink { get; set; }
        public string About { get; set; }
    }
}
