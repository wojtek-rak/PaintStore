using System;
using System.Linq;
using PaintStore.Application.Helpers;
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
            using (var db = _paintStoreContext)
            {
                var userToSignIn = db.Users.First(x => x.Email == signInCommand.Email);
                if (userToSignIn.Token == null)
                {
                    userToSignIn.Token = CredentialsHelpers.CreateSalt();
                    db.SaveChanges();
                    return new SignInResult() {UserId = userToSignIn.Id, Token = userToSignIn.Token};
                }
                else
                {
                    return new SignInResult() {UserId = userToSignIn.Id, Token = userToSignIn.Token};
                }
                
            }
        }

        public bool SignOut(SignOutCommand signOutCommand)
        {
            try
            {
                using (var db = _paintStoreContext)
                {
                    var userToSignOut = db.Users.First(x => x.Id == signOutCommand.UserId);
                    userToSignOut.Token = null;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
