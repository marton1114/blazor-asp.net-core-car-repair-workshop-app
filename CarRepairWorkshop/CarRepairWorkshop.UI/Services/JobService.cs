using System.Net.Http.Json;
using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.UI.Services;

public class JobService : IJobService
{
    private readonly HttpClient _httpClient;

    public JobService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<Job>?> GetJobsAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<Job>>("Jobs");

    public Task<Job?> GetJobByIdAsync(long id) =>
        _httpClient.GetFromJsonAsync<Job>($"Jobs/{id}");

    public Task UpdateJobAsync(long id, Job job) =>
        _httpClient.PutAsJsonAsync($"Jobs/{id}", job);

    public Task DeleteJobAsync(long id) =>
        _httpClient.DeleteAsync($"Jobs/{id}");

    public Task AddJobAsync(Job job) =>
        _httpClient.PostAsJsonAsync("Jobs", job);
}