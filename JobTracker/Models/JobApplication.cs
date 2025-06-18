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
        public int Status { get; set; } // Applied, Interview, Rejected, etc.
        public static List<SelectListItem>? Statuses { get; } = new()
        {
            new SelectListItem { Value = "1", Text = "Not Applied" },
            new SelectListItem {Value = "2", Text = "Applied"},
            new SelectListItem {Value = "3", Text = "Interview"},
            new SelectListItem {Value = "4", Text = "Rejected" },
            new SelectListItem {Value = "5", Text = "Accepted"}
        };
        public string? Notes { get; set; }
    }
}