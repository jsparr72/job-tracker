using System.ComponentModel.DataAnnotations;

namespace JobTracker.ViewModels
{
    public class CreateApplicationViewModel
    {

        [Required(ErrorMessage = "Company/Organization name required.")]
        [Display(Name = "Company/Organization")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Position title required.")]
        [Display(Name = "Position Title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Status required.")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Applied (Optional)")]
        public DateOnly? ApplicationDate { get; set; }

        [Display(Name = "Salary/Wage (Optional)")]
        public string? Salary { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }
    }
}