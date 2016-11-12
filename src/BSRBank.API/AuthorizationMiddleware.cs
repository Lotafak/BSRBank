using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BSRBank.API
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware( RequestDelegate next )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if ( authHeader != null && authHeader.StartsWith("Basic") )
            {
                //Extract credentials
                var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var seperatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);

                if ( username == "test" && password == "test" )
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 403; //Unauthorized
                }
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 403; //Unauthorized
                context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"localhost\"");
            }
        }
    }
}
