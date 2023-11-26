using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.Api.Model;

public interface IVehicleModelService
{
    Task Add(VehicleModel vehicleModel);

    Task Delete(VehicleModel vehicleModel);

    Task<VehicleModel> Get(long id);

    Task<IEnumerable<VehicleModel>> Get();

    Task Update(VehicleModel newVehicleModel);
}