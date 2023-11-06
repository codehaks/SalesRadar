using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesRadar.Application.Contracts;
using SalesRadar.Domain;
using System;
using System.Collections.Generic;

namespace SalesRadar.WebApi.Controllers;



[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        try
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting customers.");
            return StatusCode(500, "An error occurred while getting customers.");
        }
    }

    [HttpGet("{customerId}")]
    public ActionResult<Customer> GetCustomer(int customerId)
    {
        var customer = _customerService.GetCustomerById(customerId);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer([FromBody] CustomerCreateDto customer)
    {
        try
        {
            var createdCustomer = _customerService.CreateCustomer(customer);
            return CreatedAtAction("GetCustomer", new { customerId = createdCustomer.Id }, createdCustomer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating a customer.");
            return StatusCode(500, "An error occurred while creating a customer.");
        }
    }

    [HttpPut("{customerId}")]
    public ActionResult<Customer> UpdateCustomer(int customerId, [FromBody] Customer customer)
    {
        if (customerId != customer.Id)
        {
            return BadRequest("Customer ID in the URL does not match the customer ID in the request body.");
        }

        try
        {
            var updatedCustomer = _customerService.UpdateCustomer(customer);
            return Ok(updatedCustomer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while updating a customer.");
            return StatusCode(500, "An error occurred while updating a customer.");
        }
    }

    [HttpDelete("{customerId}")]
    public ActionResult DeleteCustomer(int customerId)
    {
        _customerService.DeleteCustomer(customerId);
        return NoContent();
    }
}
