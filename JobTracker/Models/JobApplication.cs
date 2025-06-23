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
            new SelectListItem("Not Applied", "Not Applied"),
            new SelectListItem("Applied", "Applied"),
            new SelectListItem("Interview", "Interview"),
            new SelectListItem("Rejected", "Rejected"),
            new SelectListItem("Accepted", "Accepted")
        ];
        public string? Notes { get; set; }
    }
}