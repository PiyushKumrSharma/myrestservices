
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace myrestservices
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthenticationAttribute : TypeFilterAttribute
    {
        public BasicAuthenticationAttribute(string username, string password) : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { username, password };
        }
    }

    public class BasicAuthFilter : IAsyncAuthorizationFilter
    {
        private readonly string _username;
        private readonly string _password;

        public BasicAuthFilter(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Extract credentials
                string encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                byte[] decodedBytes = Convert.FromBase64String(encodedUsernamePassword);
                string[] usernamePassword = Encoding.UTF8.GetString(decodedBytes).Split(':', 2);

                // Check credentials
                if (usernamePassword.Length == 2 && usernamePassword[0] == _username && usernamePassword[1] == _password)
                {
                    return;
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}

