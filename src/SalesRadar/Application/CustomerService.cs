﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneNumbers;
using SalesRadar.Domain;
using SalesRadar.Infrastruture;
using SalesRadar.Infrastruture.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Application;
public class CustomerService : ICustomerService
{
    private PhoneNumberUtil phoneNumberUtil;
    private readonly ILogger<CustomerService> _logger;
    private readonly SalesRadarDbContext _db;
    public CustomerService(SalesRadarDbContext db)
    {
        phoneNumberUtil = PhoneNumberUtil.GetInstance();
        _db = db;
    }

    // Create a new customer
    public Customer CreateCustomer(CustomerCreateDto customerDto)
    {
        if (customerDto == null)
        {
            throw new ArgumentNullException(nameof(customerDto));
        }

        // Check if the customer is unique before creating
        if (!IsCustomerUnique(customerDto) || !IsEmailUnique(customerDto.Email))
        {
            throw new InvalidOperationException("Customer or email is not unique.");
        }
        TypeAdapterConfig<CustomerCreateDto, Customer>.NewConfig()
    .Ignore(destination => destination.DateOfBirth);

        var customer = new Customer
        {
            BankAccountNumber = customerDto.BankAccountNumber,
            Email = customerDto.Email,
            FirstName= customerDto.FirstName,
            LastName= customerDto.LastName,
            PhoneNumber = customerDto.PhoneNumber,
            DateOfBirth = new Domain.Values.DateOfBirth(customerDto.DateOfBirth)
        };


        _db.Customers.Add(customer.Adapt<CustomerData>());
        _db.SaveChanges();
        return customer;
    }

    // Read a customer by ID
    public Customer? GetCustomerById(int customerId)
    {
        return _db.Customers.Find(customerId)?.Adapt<Customer>();
    }

    public List<Customer> GetAllCustomers()
    {
        return _db.Customers.ProjectToType<Customer>().ToList();
    }
    // Update an existing customer
    public Customer UpdateCustomer(Customer updatedCustomer)
    {
        if (updatedCustomer == null)
        {
            throw new ArgumentNullException(nameof(updatedCustomer));
        }

        // Check if the customer is unique before updating
        if (!IsCustomerUnique(updatedCustomer.Adapt<CustomerCreateDto>()) || !IsEmailUnique(updatedCustomer.Email))
        {
            throw new InvalidOperationException("Customer or email is not unique.");
        }

        _db.Entry(updatedCustomer).State = EntityState.Modified;
        _db.SaveChanges();
        return updatedCustomer;
    }

    // Delete a customer by ID
    public void DeleteCustomer(int customerId)
    {
        var customer = _db.Customers.Find(customerId);
        if (customer != null)
        {
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }
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

    public bool IsCustomerUnique(CustomerCreateDto customer)
    {
        // Check for uniqueness based on FirstName, LastName, and DateOfBirth in your data store.
        bool isUnique = !_db.Customers.Any(c =>
            c.FirstName == customer.FirstName &&
            c.LastName == customer.LastName &&
            c.DateOfBirth == customer.DateOfBirth);

        return isUnique;
    }

    public bool IsEmailUnique(string email)
    {
        // Check for email uniqueness in your data store.
        bool isUnique = !_db.Customers.Any(c => c.Email == email);
        return isUnique;
    }

}
