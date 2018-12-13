using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Models.InputModels
{
    public class PostAddTags
    {
        public List<string> TagsList { get; set; }
        public int PostId { get; set; }
    }
}
