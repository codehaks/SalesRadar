using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Tests;

using Microsoft.Extensions.Logging;
using Moq;
using PhoneNumbers;
using SalesRadar.Application;
using SalesRadar.Infrastruture.DataModels;
using SalesRadar.Infrastruture;
using Xunit;

public class CustomerServiceTests
{
    [Fact]
    public void CreateCustomer_WithValidInput_ShouldCreateCustomer()
    {
        // Arrange
        var customerDto = new CustomerCreateDto
        {
            BankAccountNumber = "1122",
            DateOfBirth = DateTime.UtcNow,
            Email = "demo@gmail.com",
            FirstName = "Omid",
            LastName = "Ahmadi",
            PhoneNumber = "989123334444"

        };

        var dbContext = new Mock<SalesRadarDbContext>();
        var customerService = new CustomerService(dbContext.Object);

        // Act
        var createdCustomer = customerService.CreateCustomer(customerDto);

        // Assert
        Assert.NotNull(createdCustomer);
        // Add additional assertions based on your business logic
    }

    [Fact]
    public void CreateCustomer_WithNullCustomerDto_ShouldThrowArgumentNullException()
    {
        // Arrange
        var dbContext = new Mock<SalesRadarDbContext>();
        var customerService = new CustomerService(dbContext.Object);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => customerService.CreateCustomer(null));
    }

   

    [Fact]
    public void IsPhoneNumberValid_WithValidPhoneNumber_ShouldReturnTrue()
    {
        // Arrange
        var phoneNumber = "+1234567890"; // Replace with a valid phone number
        var countryCode = "US"; // Replace with a valid country code
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        PhoneNumber parsedNumber = phoneNumberUtil.Parse(phoneNumber, countryCode);
        var dbContext = new Mock<SalesRadarDbContext>();
        var logger = new Mock<ILogger<CustomerService>>();
        var customerService = new CustomerService(dbContext.Object);

        // Act
        var isValid = customerService.IsPhoneNumberValid(phoneNumber, countryCode);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void IsCustomerUnique_WithUniqueCustomer_ShouldReturnTrue()
    {
        // Arrange
        var customerDto = new CustomerCreateDto
        {
            BankAccountNumber = "1122",
            DateOfBirth = DateTime.UtcNow,
            Email = "demo@gmail.com",
            FirstName = "Omid",
            LastName = "Ahmadi",
            PhoneNumber = "989123334444"

        };

        var dbContext = new Mock<SalesRadarDbContext>();
        dbContext.Setup(d => d.Customers.Any(It.IsAny<Func<CustomerData, bool>>())).Returns(false);

        var customerService = new CustomerService(dbContext.Object);

        // Act
        var isUnique = customerService.IsCustomerUnique(customerDto);

        // Assert
        Assert.True(isUnique);
    }

    // Similar tests for IsCustomerUnique with a non-unique customer, IsEmailUnique, and other methods.
}
