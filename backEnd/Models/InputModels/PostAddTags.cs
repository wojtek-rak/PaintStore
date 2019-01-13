using System.Collections.Generic;

namespace backEnd.Models.InputModels
{
    public class PostAddTags
    {
        public List<string> TagsList { get; set; }
        public int PostId { get; set; }
    }
}
