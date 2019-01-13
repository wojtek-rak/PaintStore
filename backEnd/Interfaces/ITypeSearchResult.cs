namespace backEnd.Interfaces
{
    public interface ITagsSearchResult
    {
        int Id { get; set; }
        string TagName { get; set; }
        int Count { get; set; }
    }
}
