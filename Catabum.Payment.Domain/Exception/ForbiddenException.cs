using System;
using Microsoft.AspNetCore.Http;

namespace Catabum.Payment.Domain.Exception
{
    [Serializable]
    public sealed class ForbiddenException : ClientErrorException
    {
        /// <summary>
        /// Create 403 ForbiddenException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public ForbiddenException(string details = null) : base(StatusCodes.Status403Forbidden, "Forbidden",
            details)
        {
        }
    }
}
