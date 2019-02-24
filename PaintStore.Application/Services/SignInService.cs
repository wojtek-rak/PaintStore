using PaintStore.Application.Interfaces;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.ResultsModels;
using PaintStore.Persistence;

namespace PaintStore.Application.Services
{
    public class SignInService : ISignInService
    {
        private readonly PaintStoreContext _paintStoreContext;

        public SignInService(PaintStoreContext ctx)
        {
            _paintStoreContext = ctx;
        }

        public SignInResult SignIn(SignInCommand signInCommand)
        {
            throw new System.NotImplementedException();
        }

        public bool SignOut(SignOutCommand signOutCommand)
        {
            throw new System.NotImplementedException();
        }
    }
}
