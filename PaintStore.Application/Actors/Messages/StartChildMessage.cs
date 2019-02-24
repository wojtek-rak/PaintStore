using PaintStore.Domain.Entities;
using PaintStore.Persistence;

namespace PaintStore.Application.Actors.Messages
{
    public class StartChildImagesRmMessage
    {
        public Users UsersToRm { get; }
        public PaintStoreContext ctx { get; }

        public StartChildImagesRmMessage(Users user, PaintStoreContext ctx)
        {
            UsersToRm = user;
            this.ctx = ctx;
        }
    }
}
