using CarRepairWorkshop.Api.Context;
using CarRepairWorkshop.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairWorkshop.Api.Model;

public class JobService : IJobService
{
    private readonly ILogger<JobService> _logger;
    private readonly CarRepairWorkshopContext _workshopContext;

    public JobService(CarRepairWorkshopContext demoContext, ILogger<JobService> logger)
    {
        _workshopContext = demoContext;
        _logger = logger;
    }

    public async Task Add(Job job)
    {
        _workshopContext.Jobs.Add(job);

        await _workshopContext.SaveChangesAsync();
        _logger.LogInformation("Job added. Job: {@Job}", job);
    }

    public async Task Delete(Job job)
    {
        _workshopContext.Jobs.Remove(job);
        await _workshopContext.SaveChangesAsync();

        _logger.LogInformation("Job deleted. Job: {@Job}", job);
    }

    public async Task<Job> Get(long id)
    {
        var job = await _workshopContext.Jobs.FindAsync(id);
            
        _logger.LogInformation("Job retrieved. Job: {@Job}", job);
        return job;
    }

    public async Task<IEnumerable<Job>> Get()
    {
        _logger.LogInformation("Jobs retrieved");

        var jobs = await _workshopContext.Jobs.ToListAsync();
        return jobs;
    }

    public async Task Update(Job newJob)
    {
        var existingJob = await Get(newJob.Id);
        existingJob.CustomerId = newJob.CustomerId;
        existingJob.VehicleModelId = newJob.VehicleModelId;
        existingJob.LicensePlate = newJob.LicensePlate;
        existingJob.Description = newJob.Description;
        existingJob.JobCategory = newJob.JobCategory;
        existingJob.Severity = newJob.Severity;
        existingJob.JobStatus = newJob.JobStatus;

        _logger.LogInformation("Job updated. Job: {@Job}", existingJob);
        await _workshopContext.SaveChangesAsync();
    }
}