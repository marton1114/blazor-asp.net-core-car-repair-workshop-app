using System.Net.Http.Json;
using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.UI.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<Customer>?> GetCustomersAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("Customers");

    public Task<Customer?> GetCustomerByIdAsync(long id) =>
        _httpClient.GetFromJsonAsync<Customer>($"Customers/{id}");

    public Task UpdateCustomerAsync(long id, Customer customer) =>
        _httpClient.PutAsJsonAsync($"Customers/{id}", customer);

    public Task DeleteCustomerAsync(long id) =>
        _httpClient.DeleteAsync($"Customers/{id}");

    public Task AddCustomerAsync(Customer customer) =>
        _httpClient.PostAsJsonAsync("Customers", customer);
}