using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Cjicot.IntegrationTests
{
    public class AccountControllerIntegrationTests: IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public AccountControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task Index_WhenCalledReturnsApplicationForm()
        {
            var response = await _client.GetAsync("/Home");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Mark", responseString);
            Assert.Contains("Evelin", responseString);
        }
    }
}
