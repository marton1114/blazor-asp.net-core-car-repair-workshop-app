using CarRepairWorkshop.Contracts.Models;
using Microsoft.Extensions.Options;

namespace CarRepairWorkshop.Api.Context;
using Microsoft.EntityFrameworkCore;

public class CarRepairWorkshopContext : DbContext
{
    public CarRepairWorkshopContext(DbContextOptions options) : base(options)
    {
    }
    
    public virtual DbSet<Job> Jobs { get; set; }
    
    public virtual DbSet<Customer> Customers { get; set; }
}