using Microsoft.AspNetCore.Http;
using Catabum.Payment.Domain.Exception;
using Xunit;

namespace Catabum.Payment.Domain.Test.Exception
{
    public class BadRequestExceptionTest
    {
        private readonly string details = "BadRequestException Detail";
        
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new BadRequestException(details);
            //Asserts
            Assert.Equal(details, exception.Details);
            Assert.Equal(StatusCodes.Status400BadRequest, exception.StatusCode);
            Assert.Equal("Bad Request", exception.Message);
            
        }
    }
}
