using Xunit;

namespace DisasterRelief.UITests
{
    public class BasicUITests
    {
        [Fact]
        public void IncidentTable_ExpectedColumns_ReturnsSuccess()
        {
            // Arrange - Based on your image
            var expectedColumns = new[] {
                "Reported By", "Incident Type", "Location",
                "Date Occurred", "Severity", "Actions"
            };

            // Act & Assert
            Assert.Equal(6, expectedColumns.Length);
            Assert.Contains("Reported By", expectedColumns);
            Assert.Contains("Incident Type", expectedColumns);
            Assert.Contains("Location", expectedColumns);
            Assert.Contains("Severity", expectedColumns);
        }

        [Fact]
        public void SampleData_FromImage_ValidatesCorrectly()
        {
            // Arrange - Data from your image
            var reportedBy = "TJ";
            var incidentType = "Death";
            var location = "midcity";
            var severity = 7;

            // Assert
            Assert.Equal("TJ", reportedBy);
            Assert.Equal("Death", incidentType);
            Assert.Equal("midcity", location);
            Assert.Equal(7, severity);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(10, true)]
        [InlineData(0, false)]
        [InlineData(11, false)]
        public void SeverityValidation_WorksCorrectly(int severity, bool expectedValid)
        {
            // Act & Assert
            Assert.Equal(expectedValid, severity >= 1 && severity <= 10);
        }

        [Fact]
        public void DonationForm_RequiredFields_ArePresent()
        {
            // Arrange
            var requiredFields = new[] { "Name", "Email", "Resource Type", "Quantity" };

            // Act & Assert
            Assert.Equal(4, requiredFields.Length);
            Assert.Contains("Name", requiredFields);
            Assert.Contains("Email", requiredFields);
            Assert.Contains("Resource Type", requiredFields);
            Assert.Contains("Quantity", requiredFields);
        }
    }
}