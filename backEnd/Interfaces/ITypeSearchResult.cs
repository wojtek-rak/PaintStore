using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Interfaces
{
    public interface ITypeSearchResult
    {
        int Id { get; set; }
        string TypeName { get; set; }
        int Count { get; set; }
    }
}
