using System;
using System.Collections.Generic;
using System.Text;
using PaintStore.Domain.InputModels;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
{
    public interface ISignInService
    {
        SignInResult SignIn(SignInCommand signInCommand);
        bool SignOut(SignOutCommand signOutCommand);
    }
}
