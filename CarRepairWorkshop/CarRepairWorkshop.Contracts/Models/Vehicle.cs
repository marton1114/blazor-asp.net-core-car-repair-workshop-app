using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRepairWorkshop.Contracts.Models;

public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    public string? VIN { get; set; }
    
    [Required]
    public VehicleModel? VehicleModel { get; set; }
    
    [Required]
    [RegularExpression(@"^[A-Z]{3}-\d{3}$")]
    public string? LicensePlate { get; set; }

    public override string ToString()
    {
        return "Vehicle: " + VIN;
    }
}