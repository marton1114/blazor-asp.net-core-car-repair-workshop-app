using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CarRepairWorkshop.UI;
using CarRepairWorkshop.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5093") });

// builder.Services.AddScoped<ICustomerService, CustomerService>();
// builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();

await builder.Build().RunAsync();