using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IEnumerable<SearchResult> GetSearch([FromBody] Users search)
        {
            var name = search.Name.ToLower();
            using (var db = paintStoreContext)
            {
                var searchList = new List<SearchResult>();

                //var users = db.Users.Where(b => b.Name.ToLower().Contains(name));

                db.Users.AsParallel().Where(b => b.Name.ToLower().Contains(name)).ForAll(user =>
                {
                    var index = user.Name.ToLower() == name ? 99999999 : user.FollowedCount;
                    searchList.Add(new SearchResult(user)
                    {
                        Indexer = index
                    });
                });

                //foreach (var user in users)
                //{
                //    var index = user.Name.ToLower() == name ? 99999999 : user.FollowedCount;
                //    searchList.Add(new SearchResult(user)
                //    {
                //        Indexer = index
                //    });
                //}

                //var types = db.CategoryTypes.Where(b => b.TypeName.ToLower().Contains(name));

                db.CategoryTypes.AsParallel().Where(b => b.TypeName.ToLower().Contains(name)).ForAll(type =>
                {
                    var index = type.TypeName.ToLower() == name ? 99999999 : type.Count;
                    searchList.Add(new SearchResult(type)
                    {
                        Indexer = index
                    });
                });

                //foreach (var type in types)
                //{
                //    var index = type.TypeName.ToLower() == name ? 99999999 : type.Count;
                //    searchList.Add(new SearchResult(type)
                //    {
                //        Indexer = index
                //    });
                //}

                var sortedSearchList = searchList.OrderByDescending(x => x.GetIndexer());
                return sortedSearchList;
            }

        }

    }
}