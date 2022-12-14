using Microsoft.AspNetCore.Http;
using Catabum.Payment.Domain.Exception;
using Xunit;

namespace Catabum.Payment.Domain.Test.Exception
{
    public class NotAcceptableExceptionTest
    {
        private readonly string details = "Not Acceptable Exception Detail";
        
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new NotAcceptableException(details);
            //Asserts
            Assert.Equal(details, exception.Details);
            Assert.Equal(StatusCodes.Status406NotAcceptable, exception.StatusCode);
            Assert.Equal("Not Acceptable", exception.Message);
            
        }
    }
}
