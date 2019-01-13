using System.Linq;
using backEnd.Models;

namespace backEnd.Managers
{
    public static class TagsManager
    {
        public static Tags TagsCountPlus(PaintStoreContext db, int id)
        {
            var countTool = db.Tags.First(x => x.Id == id);
            countTool.Count += 1;
            return countTool;
        }
        public static Tags TagsCountMinus(PaintStoreContext db, int id)
        {
            var countTool = db.Tags.First(x => x.Id == id);
            countTool.Count -= 1;
            return countTool;
        }
    }
}
