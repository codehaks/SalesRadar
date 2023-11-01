using SalesRadar.Domain.Values;
using System;
using Xunit;

namespace SalesRadar.Tests.UnitTests;


public class DateOfBirthTests
{
    [Fact]
    public void DateOfBirth_Value_ShouldBeSetCorrectly()
    {
        // Arrange
        DateTime expectedDate = new DateTime(2000, 1, 1);

        // Act
        DateOfBirth dateOfBirth = new DateOfBirth(expectedDate);

        // Assert
        Assert.Equal(expectedDate, dateOfBirth.Value);
    }

    [Fact]
    public void DateOfBirth_WithValidDate_ShouldNotThrowException()
    {
        // Arrange
        DateTime validDate = DateTime.UtcNow.Date.AddYears(-30);

        // Act & Assert
        var ex=Record.Exception(() => new DateOfBirth(validDate));
        Assert.Null(ex);
    }

    [Fact]
    public void DateOfBirth_WithFutureDate_ShouldThrowException()
    {
        // Arrange
        DateTime futureDate = DateTime.UtcNow.Date.AddYears(1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new DateOfBirth(futureDate));
    }

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
