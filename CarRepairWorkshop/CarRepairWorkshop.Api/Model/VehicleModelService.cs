using CarRepairWorkshop.Api.Context;
using CarRepairWorkshop.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairWorkshop.Api.Model;

public class VehicleModelService : IVehicleModelService
{
    private readonly ILogger<VehicleModelService> _logger;
    private readonly CarRepairWorkshopContext _workshopContext;

    public VehicleModelService(CarRepairWorkshopContext demoContext, ILogger<VehicleModelService> logger)
    {
        _workshopContext = demoContext;
        _logger = logger;
    }

    public async Task Add(VehicleModel vehicleModel)
    {
        _workshopContext.VehicleModels.Add(vehicleModel);

        await _workshopContext.SaveChangesAsync();
        _logger.LogInformation("VehicleModel added. VehicleModel: {@VehicleModel}", vehicleModel);
    }

    public async Task Delete(VehicleModel vehicleModel)
    {
        _workshopContext.VehicleModels.Remove(vehicleModel);
        await _workshopContext.SaveChangesAsync();

        _logger.LogInformation("VehicleModel deleted. VehicleModel: {@VehicleModel}", vehicleModel);
    }

    public async Task<VehicleModel> Get(long id)
    {
        var vehicleModel = await _workshopContext.VehicleModels.FindAsync(id);
            
        _logger.LogInformation("VehicleModel retrieved. VehicleModel: {@VehicleModel}", vehicleModel);
        return vehicleModel;
    }

    public async Task<IEnumerable<VehicleModel>> Get()
    {
        _logger.LogInformation("VehicleModels retrieved");

        var vehicleModels = await _workshopContext.VehicleModels.ToListAsync();
        return vehicleModels;
    }

    public async Task Update(VehicleModel newVehicleModel)
    {
        var existingVehicleModel = await Get(newVehicleModel.Id);
        existingVehicleModel.ModelName = newVehicleModel.ModelName;
        existingVehicleModel.Make = newVehicleModel.Make;
        existingVehicleModel.Year = newVehicleModel.Year;

        _logger.LogInformation("VehicleModel updated. VehicleModel: {@VehicleModel}", existingVehicleModel);
        await _workshopContext.SaveChangesAsync();
    }
}