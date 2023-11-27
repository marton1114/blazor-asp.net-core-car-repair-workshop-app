using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRepairWorkshop.Contracts.Models;

public class Job
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    [ForeignKey("CustomerId")]
    public long CustomerId { get; set; }
    
    [Required]
    [ForeignKey("VehicleModelId")]
    public long VehicleModelId { get; set; }
    
    [Required]
    [RegularExpression(@"^[A-Z]{3}-\d{3}$")]
    public string? LicensePlate { get; set; }
    
    [MaxLength(150)]
    // [RegularExpression(@"\S")]
    public string? Description { get; set; }
    
    public JobCategory JobCategory { get; set; }
    
    [Required]
    [Range(1, 10)]
    public int Severity { get; set; }
    
    [Required]
    public JobStatus JobStatus { get; set; }
}