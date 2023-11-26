using CarRepairWorkshop.Api.Context;
using CarRepairWorkshop.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairWorkshop.Api.Model;

public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly CarRepairWorkshopContext _workshopContext;

    public CustomerService(CarRepairWorkshopContext demoContext, ILogger<CustomerService> logger)
    {
        _workshopContext = demoContext;
        _logger = logger;
    }

    public async Task Add(Customer customer)
    {
        _workshopContext.Customers.Add(customer);

        await _workshopContext.SaveChangesAsync();
        _logger.LogInformation("Customer added. Customer: {@Customer}", customer);
    }

    public async Task Delete(Customer customer)
    {
        _workshopContext.Customers.Remove(customer);
        await _workshopContext.SaveChangesAsync();

        _logger.LogInformation("Customer deleted. Customer: {@Customer}", customer);
    }

    public async Task<Customer> Get(long id)
    {
        var customer = await _workshopContext.Customers.FindAsync(id);
            
        _logger.LogInformation("Customer retrieved. Customer: {@Customer}", customer);
        return customer;
    }

    public async Task<IEnumerable<Customer>> Get()
    {
        _logger.LogInformation("Customers retrieved");

        var customers = await _workshopContext.Customers.ToListAsync();
        return customers;
    }

    public async Task Update(Customer newCustomer)
    {
        var existingCustomer = await Get(newCustomer.Id);
        existingCustomer.Address = newCustomer.Address;
        existingCustomer.EmailAddress = newCustomer.EmailAddress;
        existingCustomer.PhoneNumber = newCustomer.PhoneNumber;

        _logger.LogInformation("Customer updated. Customer: {@Customer}", existingCustomer);
        await _workshopContext.SaveChangesAsync();
    }
}