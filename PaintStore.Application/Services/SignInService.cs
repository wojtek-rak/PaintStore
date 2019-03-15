using System;
using System.Linq;
using System.Text;
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
        private readonly ASCIIEncoding _encoding = new ASCIIEncoding();

        public SignInService(PaintStoreContext ctx)
        {
            _paintStoreContext = ctx;
        }

        public SignInResult SignIn(SignInCommand signInCommand)
        {
            using (var db = _paintStoreContext)
            {
                var userToSignIn = db.Users.FirstOrDefault(x => x.Email == signInCommand.Email);

                if (userToSignIn == null) throw new UnauthorizedAccessException();

                var soil = _encoding.GetBytes(userToSignIn.PasswordSoil);
                var passwordBytes = _encoding.GetBytes(signInCommand.Password);

                var soiledPassword = Encoding.UTF8.GetString(CredentialsHelpers.GenerateSaltedHash(passwordBytes, soil));

                if (soiledPassword != userToSignIn.PasswordHash) throw new UnauthorizedAccessException();

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
                    userToSignOut.Token = CredentialsHelpers.CreateSalt();
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }   
        }

        public SignInResult SignInCheck(SignInCommand signInCommand, PaintStoreContext db)
        {
            var userToSignIn = db.Users.FirstOrDefault(x => x.Email == signInCommand.Email);

            if (userToSignIn == null) throw new UnauthorizedAccessException();

            var soil = _encoding.GetBytes(userToSignIn.PasswordSoil);
            var passwordBytes = _encoding.GetBytes(signInCommand.Password);

            var soiledPassword = Encoding.UTF8.GetString(CredentialsHelpers.GenerateSaltedHash(passwordBytes, soil));

            if (soiledPassword != userToSignIn.PasswordHash) throw new UnauthorizedAccessException();

            if (userToSignIn.Token == null)
            {
                userToSignIn.Token = CredentialsHelpers.CreateSalt();
                return new SignInResult() {UserId = userToSignIn.Id, Token = userToSignIn.Token};
            }
            else
            {
                return new SignInResult() {UserId = userToSignIn.Id, Token = userToSignIn.Token};
            }
        }
    }
}
