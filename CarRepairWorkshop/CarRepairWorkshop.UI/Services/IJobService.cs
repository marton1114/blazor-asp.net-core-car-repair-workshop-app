using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.UI.Services;

public interface IJobService
{
    Task<IEnumerable<Job>?> GetJobsAsync();

    Task<Job?> GetJobByIdAsync(long id);

    Task UpdateJobAsync(long id, Job job);

    Task DeleteJobAsync(long id);

    Task AddJobAsync(Job job);
}