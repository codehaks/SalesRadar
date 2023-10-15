using SalesRadar.Domain;
using SalesRadar.Domain.Values;

namespace SalesRadar.Application;
public interface ICustomerService
{
    Customer CreateCustomer(CustomerCreateDto customer);
    void DeleteCustomer(int customerId);
    List<Customer> GetAllCustomers();
    Customer? GetCustomerById(int customerId);
    bool IsCustomerUnique(CustomerCreateDto customer);
    bool IsEmailUnique(string email);
    bool IsPhoneNumberValid(string phoneNumber, string countryCode);
    Customer UpdateCustomer(Customer updatedCustomer);
}

public record CustomerCreateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required DateOnly DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string BankAccountNumber { get; set; }
}