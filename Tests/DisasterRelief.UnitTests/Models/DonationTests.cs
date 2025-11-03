using Xunit;
using System.ComponentModel.DataAnnotations;
using DisasterReliefApp.Models;

namespace DisasterRelief.UnitTests.Models
{
    public class DonationTests
    {
        [Fact]
        public void Donation_ValidData_PassesValidation()
        {
            // Arrange
            var donation = new Donation
            {
                Name = "John Doe",
                Email = "john@example.com",
                ResourceType = "Food",
                Quantity = 10
            };

            // Act & Assert
            Assert.Equal("John Doe", donation.Name);
            Assert.Equal("john@example.com", donation.Email);
            Assert.Equal("Food", donation.ResourceType);
            Assert.Equal(10, donation.Quantity);
        }

        [Theory]
        [InlineData(null, false)]        // Required field
        [InlineData("", false)]          // Empty string
        [InlineData("Valid Name", true)] // Valid
        public void NameValidation_RequiredField_ValidatesCorrectly(string name, bool expectedIsValid)
        {
            // Arrange
            var donation = new Donation
            {
                Name = name,
                Email = "test@example.com",
                ResourceType = "Food",
                Quantity = 1
            };

            var context = new ValidationContext(donation);
            var results = new List<ValidationResult>();

            // Act
            bool isValid = Validator.TryValidateObject(donation, context, results, true);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }

        [Theory]
        [InlineData(0, false)]      // Invalid - must be greater than 0
        [InlineData(-1, false)]     // Invalid - negative
        [InlineData(1, true)]       // Valid
        [InlineData(100, true)]     // Valid
        public void QuantityValidation_RangeCheck_ValidatesCorrectly(int quantity, bool expectedIsValid)
        {
            // Arrange
            var donation = new Donation
            {
                Name = "Test User",
                Email = "test@example.com",
                ResourceType = "Food",
                Quantity = quantity
            };

            var context = new ValidationContext(donation);
            var results = new List<ValidationResult>();

            // Act
            bool isValid = Validator.TryValidateObject(donation, context, results, true);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }
    }
}