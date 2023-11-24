using System.ComponentModel.DataAnnotations;

namespace CarRepairWorkshop.Contracts.Validation;

public class YearRangeAttribute : ValidationAttribute
{
    public int Minimum { get; set; }

    public override bool IsValid(object value)
    {
        if (value is not int date) return true;
        
        var currentYear = DateTime.Now.Year;
        
        return date > Minimum && date <= currentYear;
    }
}