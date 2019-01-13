using System.Linq;
using backEnd.Models;

namespace backEnd.Managers
{
    public class TagsManager
    {
        public static Tags TagsCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Tags.Where(x => x.Id == id).First();
            countTool.Count += 1;
            return countTool;
        }
        public static Tags TagsCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Tags.Where(x => x.Id == id).First();
            countTool.Count -= 1;
            return countTool;
        }
    }
}
