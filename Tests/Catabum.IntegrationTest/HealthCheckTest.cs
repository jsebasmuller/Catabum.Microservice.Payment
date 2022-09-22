using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Catabum.IntegrationTest.Fixtures;
using Catabum.Payment.Api;
using Xunit;

namespace Catabum.IntegrationTest
{
    public class HealthCheckTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public HealthCheckTest(CustomWebApplicationFactory<Startup> factory) =>
            client = factory.CreateClient();

        [Fact]
        public async Task GetStatus_Default_Returns200Ok()
        {
            var response = await this.client.GetAsync("/health");

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
    }
}
