using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisasterReliefApp.Models;
using DisasterReliefApp.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DisasterRelief.UnitTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithIncidentReports()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var mockLogger = new Mock<ILogger<HomeController>>();

            var testData = new List<IncidentReport>
            {
                new IncidentReport { ReportedBy = "TJ", IncidentType = "Death", Location = "midcity", Severity = 7 },
                new IncidentReport { ReportedBy = "Alice", IncidentType = "Flood", Location = "downtown", Severity = 5 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<IncidentReport>>();
            mockSet.As<IQueryable<IncidentReport>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockSet.As<IQueryable<IncidentReport>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockSet.As<IQueryable<IncidentReport>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockSet.As<IQueryable<IncidentReport>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

            mockContext.Setup(c => c.IncidentReports).Returns(mockSet.Object);

            var controller = new HomeController(mockLogger.Object, mockContext.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<IncidentReport>>(viewResult.Model);
            Assert.NotNull(model);
        }
    }
}