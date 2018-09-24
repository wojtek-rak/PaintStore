using backEnd.Models;

namespace backEnd.Actors.Messages
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
