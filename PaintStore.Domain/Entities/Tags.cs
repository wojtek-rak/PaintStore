using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.Entities
{
    public partial class Tags: ITagsSearchResult
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int Count { get; set; }
    }
}
