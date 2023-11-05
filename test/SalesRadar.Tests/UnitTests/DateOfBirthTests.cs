using SalesRadar.Domain.Values;
using System;
using Xunit;

namespace SalesRadar.Tests.UnitTests;


public class DateOfBirthTests
{
   

    [Fact]
    public void DateOfBirth_WithCurrentDate_ShouldNotThrowException()
    {
        // Arrange
        DateTime currentDate = DateTime.UtcNow.Date;

        // Act & Assert
        var ex = Record.Exception(() => new DateOfBirth(currentDate));
         Assert.Null(ex);
    }
}
