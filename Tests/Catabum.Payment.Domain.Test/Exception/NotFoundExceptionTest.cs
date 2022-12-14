using Microsoft.AspNetCore.Http;
using Catabum.Payment.Domain.Exception;
using Xunit;

namespace Catabum.Payment.Domain.Test.Exception
{
    public class NotFoundExceptionTest
    {
        private readonly string details = "Not Found Exception Detail";
        
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new NotFoundException(details);
            //Asserts
            Assert.Equal(details, exception.Details);
            Assert.Equal(StatusCodes.Status404NotFound, exception.StatusCode);
            Assert.Equal("Resource Not Found", exception.Message);
            
        }
    }
}
