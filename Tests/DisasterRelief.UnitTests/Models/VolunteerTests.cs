using Xunit;
using DisasterReliefApp.Models;

namespace DisasterRelief.UnitTests.Models
{
    public class VolunteerTests
    {
        [Fact]
        public void Volunteer_ValidData_CreatesSuccessfully()
        {
            // Arrange
            var volunteer = new Volunteer
            {
                Name = "Alice Smith",
                Email = "alice@example.com",
                Phone = "123-456-7890",
                Skills = "Medical, First Aid",
                Availability = "Weekends"
            };

            // Act & Assert
            Assert.Equal("Alice Smith", volunteer.Name);
            Assert.Equal("alice@example.com", volunteer.Email);
            Assert.Equal("123-456-7890", volunteer.Phone);
            Assert.Equal("Medical, First Aid", volunteer.Skills);
            Assert.Equal("Weekends", volunteer.Availability);
        }
    }
}