using System.Net.Http.Json;
using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.UI.Services;

public class VehicleModelService : IVehicleModelService
{
    private readonly HttpClient _httpClient;

    public VehicleModelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<VehicleModel>?> GetVehicleModelsAsync() =>
        _httpClient.GetFromJsonAsync<IEnumerable<VehicleModel>>("VehicleModels");

    public Task<VehicleModel?> GetVehicleModelByIdAsync(long id) =>
        _httpClient.GetFromJsonAsync<VehicleModel>($"VehicleModels/{id}");

    public Task UpdateVehicleModelAsync(long id, VehicleModel vehicleModel) =>
        _httpClient.PutAsJsonAsync($"VehicleModels/{id}", vehicleModel);

    public Task DeleteVehicleModelAsync(long id) =>
        _httpClient.DeleteAsync($"VehicleModels/{id}");

    public Task AddVehicleModelAsync(VehicleModel vehicleModel) =>
        _httpClient.PostAsJsonAsync("VehicleModels", vehicleModel);
}