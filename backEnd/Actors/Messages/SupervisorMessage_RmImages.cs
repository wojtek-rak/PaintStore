using backEnd.Models;

namespace backEnd.Actors.Messages
{
    public class SupervisorMessage_RmImages
    {
        public Users UserToRm { get; }
        public PaintStoreContext ctx { get; }

        public SupervisorMessage_RmImages(Users user, PaintStoreContext ctx)
        {
            UserToRm = user;
            this.ctx = ctx;
        }
    }
}
