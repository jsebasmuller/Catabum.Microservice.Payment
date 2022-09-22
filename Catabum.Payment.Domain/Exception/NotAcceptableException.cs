using System;
using Microsoft.AspNetCore.Http;

namespace Catabum.Payment.Domain.Exception
{
    [Serializable]
    public sealed class NotAcceptableException : ClientErrorException
    {
        
        /// <summary>
        /// Create 406 NotAcceptableException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public NotAcceptableException(string details = null) : base(StatusCodes.Status406NotAcceptable,
            "Not Acceptable",
            details)
        {
        }
    }
}
