using Microsoft.AspNetCore.Http;
using Catabum.Payment.Domain.Exception;
using Xunit;

namespace Catabum.Payment.Domain.Test.Exception
{
    public class BusinessConflictExceptionTest
    {
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new BusinessException("code", "message");
            Assert.Equal(StatusCodes.Status409Conflict, exception.StatusCode);

        }
    }
}