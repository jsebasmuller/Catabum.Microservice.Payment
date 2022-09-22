using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Catabum.Payment.Domain.Exception;
using Serilog;

namespace Catabum.Payment.Api.Filter
{
    /// <summary>
    /// File to get token info
    /// </summary>
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    /// <summary>
    /// AuthorizeFilter 
    /// </summary>
    public class AuthorizeFilter : IAuthorizationFilter
    {
        public IConfiguration _configuration { get; }

        public AuthorizeFilter(IConfiguration Configuration, params string[] claim)
        {
            Log.Information("Claims are: ",claim.ToString());
            _configuration = Configuration;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
          //  var objTokenManager = new TokenManager(_configuration);
          //  PayloadTokenIdentity payload = null;
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                throw new UnauthorizedException("unauthorized", "No autorizado");
            }
        }
    }
}