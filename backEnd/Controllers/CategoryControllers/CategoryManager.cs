using backEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.Controllers.CategoryControllers
{
    public class CategoryManager
    {
        public static CategoryToFind CategoryToolAdd(PaintStoreContext db, CategoryToFind category)
        {

            db.CategoryTools.Add(new CategoryTools { ToolName = category.ToolName, Count = 0 });
            db.SaveChanges();
            category.Id = db.CategoryTools.Where(x => x.ToolName == category.ToolName).First().Id;
            return category;
        }
        public static CategoryToFind CategoryTypeAdd(PaintStoreContext db, CategoryToFind category)
        {

            db.CategoryTypes.Add(new CategoryTypes { TypeName = category.TypeName, Count = 0 });
            db.SaveChanges();
            category.Id = db.CategoryTypes.Where(x => x.TypeName == category.TypeName).First().Id;
            return category;
        }
        public static CategoryTools CategoryToolCountPlus(PaintStoreContext db, int? id)
        {

            var countTool = db.CategoryTools.Where(x => x.Id == id).First();
            countTool.Count += 1;
            return countTool;
        }
        public static CategoryTypes CategoryTypesCountPlus(PaintStoreContext db, int? id)
        {

            var countTool = db.CategoryTypes.Where(x => x.Id == id).First();
            countTool.Count += 1;
            return countTool;
        }
        public static CategoryTools CategoryToolCountMinus(PaintStoreContext db, int? id)
        {

            var countTool = db.CategoryTools.Where(x => x.Id == id).First();
            countTool.Count -= 1;
            return countTool;
        }
        public static CategoryTypes CategoryTypesCountMinus(PaintStoreContext db, int? id)
        {

            var countTool = db.CategoryTypes.Where(x => x.Id == id).First();
            countTool.Count -= 1;
            return countTool;
        }
    }
}
