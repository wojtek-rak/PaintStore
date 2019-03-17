using System;
using System.Collections.Generic;
using System.Text;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.ResultsModels;
using PaintStore.Persistence;

namespace PaintStore.Application.Interfaces
{
    public interface ISignInService
    {
        SignInResult SignIn(SignInCommand signInCommand);
        SignInResult SignInCheck(SignInCommand signInCommand, PaintStoreContext db);
        bool SignOut(SignOutCommand signOutCommand);
    }
}
