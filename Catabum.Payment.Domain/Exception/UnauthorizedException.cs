using System;
using Microsoft.AspNetCore.Http;

namespace Catabum.Payment.Domain.Exception
{
    [Serializable]
    public sealed class UnauthorizedException : ClientErrorException
    {
        
        /// <summary>
        /// Create 401 UnauthorizedException
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public UnauthorizedException(string code, string message, string details = null) : base(StatusCodes.Status401Unauthorized, message, details, code)
        {
        }
    }
}
