using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyClaimsApi.Shared;

namespace CompanyClaimsApi.Tests.Shared
{
    public class DaysBetweenDatesTests
    {
        [Fact]
        public void GivenIhaveADate50DaysOld_WhenCalculatingDaysBetweenDates_ThenResultShouldBe50()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(-50);
            DateTime endDate = DateTime.Now;

            // Act
            int daysBetweenDates = DaysBetweenDates.Get(startDate, endDate);

            // Assert
            Assert.Equal(50, daysBetweenDates);
        }

        [Fact]
        public void GivenIhaveADate100DaysOld_WhenCalculatingDaysBetweenDates_ThenResultShouldBe100()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(-100);
            DateTime endDate = DateTime.Now;

            // Act
            int daysBetweenDates = DaysBetweenDates.Get(startDate, endDate);

            // Assert
            Assert.Equal(100, daysBetweenDates);
        }
    }
}