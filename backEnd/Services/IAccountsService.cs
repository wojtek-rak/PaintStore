using backEnd.Models;

namespace backEnd.Services
{
    public interface IAccountsService
    {
        Accounts AddAccount(Accounts account);
        Accounts EditAccount(Accounts account);
        Accounts RemoveAccount(Accounts account);
    }
}
