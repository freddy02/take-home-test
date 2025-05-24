using Fundo.Applications.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Integration
{
    public class LoanManagementControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public LoanManagementControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false, 

            });
        }

        [Fact]
        public async Task GetAllLoans_ReturnsOk()
        {
            var response = await _client.GetAsync("/loan/all");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateLoan_ThenFetchById_Success()
        {
            var loanRequest = new
            {
                amount = 1000,
                currentBalance = 1000,
                applicantName = "Alice",
                applicantId = "A123",
                status = 1
            };

            var createResponse = await _client.PostAsJsonAsync("/loan", loanRequest);
            createResponse.EnsureSuccessStatusCode();

            var loanId = await createResponse.Content.ReadFromJsonAsync<Guid>();
            Assert.NotEqual(Guid.Empty, loanId);

            var getResponse = await _client.GetAsync($"/loan/{loanId}");
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateLoan_ThenMakePayment_Success()
        {
            var loanRequest = new
            {
                amount = 1000,
                currentBalance = 1000,
                applicantName = "Alice",
                applicantId = "A123",
                status = 1
            };

            var createResponse = await _client.PostAsJsonAsync("/loan", loanRequest);
            createResponse.EnsureSuccessStatusCode();

            var loanId = await createResponse.Content.ReadFromJsonAsync<Guid>();
            Assert.NotEqual(Guid.Empty, loanId);

            var paymentRequest = new { paidAmount = 500 };
            var paymentResponse = await _client.PostAsJsonAsync($"/loan/{loanId}/payment", paymentRequest);
            paymentResponse.EnsureSuccessStatusCode();
        }
    }
}
