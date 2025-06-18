namespace JobTracker;

public class JobApplication
{
    public int Id { get; set; } // Primary key
    public string UserId { get; set; } // For ASP.NET Identity
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string? Status { get; set; } // Applied, Interview, Rejected, etc.
    public string? Notes { get; set; }

    public JobApplication(int Id, string UserId, string Company,
            string JobTitle, DateTime ApplicationDate, string Status,
            string Notes=null)
    {
        this.Id = Id;
        this.UserId = UserId;
        this.Company = Company;
        this.JobTitle = JobTitle;
        this.ApplicationDate = ApplicationDate;
        this.Status = Status;
        this.Notes = Notes;
    }
}