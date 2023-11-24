using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRepairWorkshop.Contracts;

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
    public int Year { get; set; }
}