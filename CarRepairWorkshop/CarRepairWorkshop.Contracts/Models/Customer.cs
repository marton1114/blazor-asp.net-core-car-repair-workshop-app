using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRepairWorkshop.Contracts.Models;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Address { get; set; }
    
    [Required]
    [EmailAddress]
    public string? EmailAddress { get; set; }
    
    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }
}