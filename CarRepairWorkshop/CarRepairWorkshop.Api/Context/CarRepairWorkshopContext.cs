using CarRepairWorkshop.Contracts.Models;

namespace CarRepairWorkshop.Api.Context;
using Microsoft.EntityFrameworkCore;

public class CarRepairWorkshopContext : DbContext
{
    protected CarRepairWorkshopContext(DbContextOptions options) : base(options)
    {
    }
    
    public virtual DbSet<Job> Jobs { get; set; }
    
    public virtual DbSet<Customer> Customers { get; set; }
}