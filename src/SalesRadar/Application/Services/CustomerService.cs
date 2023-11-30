using Mapster;
using Microsoft.Extensions.Logging;
using PhoneNumbers;
using SalesRadar.Application.Contracts;
using SalesRadar.Domain;
using SalesRadar.Domain.Contracts;

namespace SalesRadar.Application.Services;
public class CustomerService : ICustomerService
{
    private PhoneNumberUtil phoneNumberUtil;
    private readonly ILogger<CustomerService> _logger;
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        phoneNumberUtil = PhoneNumberUtil.GetInstance();
        _customerRepository = customerRepository;
    }

    // Create a new customer
    public Customer CreateCustomer(CustomerCreateDto customerDto)
    {
        TypeAdapterConfig<CustomerCreateDto, Customer>
            .NewConfig()
            .Ignore(destination => destination.DateOfBirth);

        var customer = new Customer
        {
            Email = customerDto.Email,
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            PhoneNumber = customerDto.PhoneNumber,
            DateOfBirth = new Domain.Values.DateOfBirth(customerDto.DateOfBirth)
        };


        _customerRepository.Create(customer);
        return customer;
    }

    // Read a customer by ID
    public Customer? GetCustomerById(int customerId)
    {
        return _customerRepository.Get(customerId);
    }

    public List<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }
    // Update an existing customer
    public Customer UpdateCustomer(Customer updatedCustomer)
    {
        _customerRepository.Update(updatedCustomer);
        return updatedCustomer;
    }

    // Delete a customer by ID
    public void DeleteCustomer(int customerId)
    {
        _customerRepository.Delete(customerId);
    }

    public bool IsPhoneNumberValid(string phoneNumber, string countryCode)
    {
        try
        {
            PhoneNumber parsedNumber = phoneNumberUtil.Parse(phoneNumber, countryCode);
            return phoneNumberUtil.IsValidNumber(parsedNumber);
        }
        catch (NumberParseException ex)
        {
            _logger.LogError(ex.Message, ex);

            return false;
        }
    }



}
