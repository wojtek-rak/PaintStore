using System.Collections.Generic;

namespace PaintStore.Domain.InputModels
{
    public class PostAddTags
    {
        public List<string> TagsList { get; set; }
        public int PostId { get; set; }
    }
}
