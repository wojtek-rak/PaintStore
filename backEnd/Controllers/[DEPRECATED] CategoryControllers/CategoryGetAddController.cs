using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Controllers.CategoryControllers;
using backEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CategoryGetAddController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;
        private CategoryToFind categoryToFind = new CategoryToFind();
        public CategoryGetAddController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }

        [HttpPost]
        public CategoryToFind GetCategory([FromBody] CategoryToFind category)
        {
            using (var db = paintStoreContext)
            {

                if (category.ToolName != null)
                {
                    if (!db.CategoryTools.Any(x => x.ToolName == category.ToolName))
                    {
                        categoryToFind = CategoryManager.CategoryToolAdd(db, category);
                    }
                    else
                    {
                        categoryToFind.ToolName = category.ToolName;
                        categoryToFind.Id = db.CategoryTools.Where(x => x.ToolName == category.ToolName).First().Id;
                        categoryToFind.Count = db.CategoryTools.Where(x => x.ToolName == category.ToolName).First().Count;
                    }
                }
                else
                {
                    if (!db.CategoryTypes.Any(x => x.TypeName == category.TypeName))
                    {
                        categoryToFind = CategoryManager.CategoryTypeAdd(db, category);
                    }
                    else
                    {
                        categoryToFind.TypeName = category.TypeName;
                        categoryToFind.Id = db.CategoryTypes.Where(x => x.TypeName == category.TypeName).First().Id;
                        categoryToFind.Count = db.CategoryTypes.Where(x => x.TypeName == category.TypeName).First().Count;

                    }
                }

                
                return categoryToFind;
            }

        }
    }

    public class CategoryToFind
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string ToolName { get; set; }
        public int Count { get; set; }
    }
}

