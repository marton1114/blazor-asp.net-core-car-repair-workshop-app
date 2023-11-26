using CarRepairWorkshop.Api.Model;
using CarRepairWorkshop.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairWorkshop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleModelsController : ControllerBase
{
    private readonly IVehicleModelService _vehicleModelService;

    public VehicleModelsController(IVehicleModelService vehicleModelService)
    {
        _vehicleModelService = vehicleModelService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] VehicleModel VehicleModel)
    {
        var existingVehicleModel = await _vehicleModelService.Get(VehicleModel.Id);

        if (existingVehicleModel is not null)
        {
            return Conflict();
        }

        await _vehicleModelService.Add(VehicleModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingVehicleModel = await _vehicleModelService.Get(id);

        if (existingVehicleModel is null)
        {
            return NotFound();
        }

        await _vehicleModelService.Delete(existingVehicleModel);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleModel>> Get(int id)
    {
        var existingVehicleModel = await _vehicleModelService.Get(id);

        if (existingVehicleModel is null)
        {
            return NotFound();
        }

        return Ok(existingVehicleModel);
    }

    [HttpGet]
    public async Task<ActionResult<List<VehicleModel>>> GetAll()
    {
        var vehicleModels = await _vehicleModelService.Get();
        return Ok(vehicleModels.ToList());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] VehicleModel VehicleModel)
    {
        if (id != VehicleModel.Id)
        {
            return BadRequest();
        }

        var existingVehicleModel = await _vehicleModelService.Get(id);

        if (existingVehicleModel is null)
        {
            return NotFound();
        }

        await _vehicleModelService.Update(VehicleModel);

        return Ok();
    }
}