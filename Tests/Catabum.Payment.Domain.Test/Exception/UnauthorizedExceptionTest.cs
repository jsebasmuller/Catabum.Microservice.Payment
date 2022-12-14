using Microsoft.AspNetCore.Http;
using Catabum.Payment.Domain.Exception;
using Xunit;

namespace Catabum.Payment.Domain.Test.Exception
{
    public class UnauthorizedExceptionTest
    {
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new UnauthorizedException("unauthorized", "Unauthorized");
            //Asserts
            Assert.Equal(StatusCodes.Status401Unauthorized, exception.StatusCode);
            Assert.Equal("unauthorized", exception.Code);
        }
    }
}
