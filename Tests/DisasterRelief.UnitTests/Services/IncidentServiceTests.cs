using Xunit;
using DisasterReliefApp.Models;

namespace DisasterRelief.UnitTests.Services
{
    public class IncidentServiceTests
    {
        [Fact]
        public void IncidentReport_ValidData_CreatesSuccessfully()
        {
            // Arrange
            var incident = new IncidentReport
            {
                ReportedBy = "TJ",
                IncidentType = "Death",
                Location = "midcity",
                Severity = 7,
                DateOccurred = DateTime.Parse("2025/10/31 00:07"),
                Description = "Test description",
                AffectedAreas = "Test area",
                ResourcesNeeded = "Medical supplies",
                Injuries = 2,
                Fatalities = 1
            };

            // Act & Assert
            Assert.Equal("TJ", incident.ReportedBy);
            Assert.Equal("Death", incident.IncidentType);
            Assert.Equal("midcity", incident.Location);
            Assert.Equal(7, incident.Severity);
            Assert.InRange(incident.Severity, 1, 10);
            Assert.Equal(2, incident.Injuries);
            Assert.Equal(1, incident.Fatalities);
        }

        [Theory]
        [InlineData(1, true)]    // Valid
        [InlineData(5, true)]    // Valid
        [InlineData(10, true)]   // Valid
        [InlineData(0, false)]   // Invalid - too low
        [InlineData(11, false)]  // Invalid - too high
        [InlineData(-1, false)]  // Invalid - negative
        public void SeverityValidation_CorrectRange_ReturnsExpected(int severity, bool expectedIsValid)
        {
            // Arrange
            var incident = new IncidentReport { Severity = severity };

            // Act
            bool isValid = severity >= 1 && severity <= 10;

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }

        [Fact]
        public void IncidentReport_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var incident = new IncidentReport();

            // Assert
            Assert.True(incident.ReportDate <= DateTime.Now);
            Assert.True(incident.ReportDate > DateTime.Now.AddMinutes(-1));
        }

        [Theory]
        [InlineData("Earthquake", 8, true)]
        [InlineData("Flood", 6, true)]
        [InlineData("Fire", 9, true)]
        public void DifferentIncidentTypes_CreateSuccessfully(string incidentType, int severity, bool expectedValid)
        {
            // Arrange
            var incident = new IncidentReport
            {
                ReportedBy = "Test User",
                IncidentType = incidentType,
                Location = "test location",
                Severity = severity
            };

            // Act & Assert
            Assert.Equal(incidentType, incident.IncidentType);
            Assert.Equal(severity, incident.Severity);
            Assert.True(incident.Severity >= 1 && incident.Severity <= 10);
        }
    }
}