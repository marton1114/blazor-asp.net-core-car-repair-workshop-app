using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.Api.Model;

public interface ICustomerService
{
    Task Add(Customer customer);

    Task Delete(Customer customer);

    Task<Customer> Get(long id);

    Task<IEnumerable<Customer>> Get();

    Task Update(Customer newCustomer);
}