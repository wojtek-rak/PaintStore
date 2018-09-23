using backEnd.Models;

namespace backEnd.Actors.Messages
{
    public class StartSupervisorMessage
    {
        public Accounts Account { get; set; }

        public StartSupervisorMessage(Accounts account)
        {
            Account = account;
        }
    }
}
