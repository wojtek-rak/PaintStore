using backEnd.Interfaces;

namespace backEnd.Models
{
    public partial class Tags: ITagsSearchResult
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int Count { get; set; }
    }
}
