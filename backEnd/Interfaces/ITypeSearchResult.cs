using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Interfaces
{
    public interface ITagsSearchResult
    {
        int Id { get; set; }
        string TagName { get; set; }
        int Count { get; set; }
    }
}
