using backEnd.Models;

namespace backEnd.Actors.Messages
{
    public class StartChildMessage
    {
        public Accounts Account { get; set; }

        public StartChildMessage(Accounts account)
        {
            Account = account;
        }
    }
}
