using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRepairWorkshop.Contracts.Validation;

namespace CarRepairWorkshop.Contracts.Models;

public class VehicleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    public string? ModelName { get; set; }
    
    [Required]
    public string? Make { get; set; }
    
    [Required]
    [YearRange(Minimum = 1900)]
    public int Year { get; set; }
}