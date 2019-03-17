using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PaintStore.Application.Helpers;
using PaintStore.Persistence;

namespace PaintStore.BackEnd.Middlewares
{
    public class AuthenticationMiddleware : IDBContextCreate
    {
        private readonly RequestDelegate _next;
        private readonly ASCIIEncoding _encoding = new ASCIIEncoding();

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!IgnoreMiddleware(context))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                    //Extract credentials
                    string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    int seperatorIndex = usernamePassword.IndexOf(':');

                    var userId = Int32.Parse(usernamePassword.Substring(0, seperatorIndex));
                    var password = usernamePassword.Substring(seperatorIndex + 1);

                    using (var db = CreateContext())
                    {
                        var userToAuth = db.Users.First(x => x.Id == userId);

                        var tokenBytes = _encoding.GetBytes(password);

                        var token = Convert.ToBase64String(tokenBytes);//CredentialsHelpers.GenerateSaltedHash(passwordBytes, soil));

                        if (token == userToAuth.Token)
                        {
                            await _next.Invoke(context);
                        }
                        else
                        {
                            context.Response.StatusCode = 401; //Unauthorized
                        }
                    }
                }
                else
                {
                    // no authorization header
                    context.Response.StatusCode = 401; //Unauthorized
                }
            }
            else
            {
                await _next.Invoke(context);
            }
            
        }

        private bool IgnoreMiddleware(HttpContext context)
        {
            if (context.Request.Method == "GET") return true;
            if (context.Request.Path.StartsWithSegments("/api/Users/AddUser")) return true;
            if (context.Request.Path.StartsWithSegments("/api/SignIn/In")) return true;
            return false;
        }

        public PaintStoreContext CreateContext()
        {
            return new PaintStoreContext();
        }
    }
}
