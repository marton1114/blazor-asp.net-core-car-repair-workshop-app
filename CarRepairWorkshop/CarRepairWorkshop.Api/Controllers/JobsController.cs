using CarRepairWorkshop.Api.Model;
using CarRepairWorkshop.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairWorkshop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Job Job)
    {
        var existingJob = await _jobService.Get(Job.Id);

        if (existingJob is not null)
        {
            return Conflict();
        }

        await _jobService.Add(Job);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingJob = await _jobService.Get(id);

        if (existingJob is null)
        {
            return NotFound();
        }

        await _jobService.Delete(existingJob);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> Get(int id)
    {
        var existingJob = await _jobService.Get(id);

        if (existingJob is null)
        {
            return NotFound();
        }

        return Ok(existingJob);
    }

    [HttpGet]
    public async Task<ActionResult<List<Job>>> GetAll()
    {
        var jobs = await _jobService.Get();
        return Ok(jobs.ToList());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Job Job)
    {
        if (id != Job.Id)
        {
            return BadRequest();
        }

        var existingJob = await _jobService.Get(id);

        if (existingJob is null)
        {
            return NotFound();
        }

        await _jobService.Update(Job);

        return Ok();
    }
}