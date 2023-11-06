using SalesRadar.Domain;
using SalesRadar.Domain.Values;
using System.ComponentModel.DataAnnotations;

namespace SalesRadar.Application.Contracts;
public interface ICustomerService
{
    Customer CreateCustomer(CustomerCreateDto customer);
    void DeleteCustomer(int customerId);
    List<Customer> GetAllCustomers();
    Customer? GetCustomerById(int customerId);
    Customer UpdateCustomer(Customer updatedCustomer);
}

public record CustomerCreateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    [DataType(DataType.Date)]
    public required DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
}