using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.Api.Model;

public interface IJobService
{
    Task Add(Job job);

    Task Delete(Job job);

    Task<Job> Get(long id);

    Task<IEnumerable<Job>> Get();

    Task Update(Job newJob);
}