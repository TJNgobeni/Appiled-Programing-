using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Xunit;
using DisasterReliefApp.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace DisasterRelief.IntegrationTests
{
    public class IncidentIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public IncidentIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Remove the existing ApplicationDbContext
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Add in-memory database
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });
                });
            });
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task HomePage_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateIncidentPage_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/Home/CreateIncidentReport");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task VolunteerRegistrationPage_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/Home/VolunteerRegistration");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateDonationPage_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/Home/CreateDonation");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}