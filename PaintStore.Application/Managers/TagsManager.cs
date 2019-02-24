using System.Linq;
using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Managers
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
