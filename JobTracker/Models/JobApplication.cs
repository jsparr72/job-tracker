using Microsoft.AspNetCore.Mvc.Rendering;
namespace JobTracker.Models
{
    public class JobApplication
    {
        public int ID { get; set; } // Primary key
        public string? UserId { get; set; } // For ASP.NET Identity
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? Status { get; set; } // Applied, Interview, Rejected, etc.
        public static List<SelectListItem>? Statuses { get; } =
        [
            new SelectListItem { Value = "Not Yet Applied"},
            new SelectListItem {Value = "Applied"},
            new SelectListItem {Value = "Interview"},
            new SelectListItem {Value = "Rejected"},
            new SelectListItem {Value = "Accepted" }
        ];
        public string? Notes { get; set; }
    }
}