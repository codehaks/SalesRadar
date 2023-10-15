using SalesRadar.Domain;

namespace SalesRadar.Application;
public interface ICustomerService
{
    Customer CreateCustomer(Customer customer);
    void DeleteCustomer(int customerId);
    List<Customer> GetAllCustomers();
    Customer GetCustomerById(int customerId);
    bool IsCustomerUnique(Customer customer);
    bool IsEmailUnique(string email);
    bool IsPhoneNumberValid(string phoneNumber, string countryCode);
    Customer UpdateCustomer(Customer updatedCustomer);
}