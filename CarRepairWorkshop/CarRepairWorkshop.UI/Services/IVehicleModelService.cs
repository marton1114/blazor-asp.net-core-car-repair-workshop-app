using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.UI.Services;

public interface IVehicleModelService
{
    Task<IEnumerable<VehicleModel>?> GetVehicleModelsAsync();

    Task<VehicleModel?> GetVehicleModelByIdAsync(long id);

    Task UpdateVehicleModelAsync(long id, VehicleModel vehicleModel);

    Task DeleteVehicleModelAsync(long id);

    Task AddVehicleModelAsync(VehicleModel vehicleModel);
}