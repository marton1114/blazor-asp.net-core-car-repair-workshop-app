using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.UI.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>?> GetCustomersAsync();

    Task<Customer?> GetCustomerByIdAsync(long id);

    Task UpdateCustomerAsync(long id, Customer customer);

    Task DeleteCustomerAsync(long id);

    Task AddCustomerAsync(Customer customer);
}