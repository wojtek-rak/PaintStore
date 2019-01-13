using System.Collections.Generic;
using System.Linq;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers.SearchControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public SearchController(PaintStoreContext paintStoreContext)
        {
            this.paintStoreContext = paintStoreContext;
        }       

        [HttpGet("{searchWord}")]
        public IEnumerable<SearchResult> GetSearch(string searchWord)
        {
            var name = searchWord.ToLower();
            using (var db = paintStoreContext)
            {
                var searchList = new List<SearchResult>();

                db.Users.AsParallel().Where(b => b.Name.ToLower().Contains(name)).ForAll(user =>
                {
                    var index = user.Name.ToLower() == name ? 99999999 : user.FollowedCount;
                    searchList.Add(new SearchResult(user)
                    {
                        Indexer = index
                    });
                });

                db.Tags.AsParallel().Where(b => b.TagName.ToLower().Contains(name)).ForAll(tag =>
                {
                    var index = tag.TagName.ToLower() == name ? 99999999 : tag.Count;
                    searchList.Add(new SearchResult(tag)
                    {
                        Indexer = index
                    });
                });

                var sortedSearchList = searchList.OrderByDescending(x => x.GetIndexer());
                return sortedSearchList;
            }

        }

    }
}