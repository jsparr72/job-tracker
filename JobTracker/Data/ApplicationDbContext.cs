using Microsoft.EntityFrameworkCore;
using JobTracker.Models; // For entity classes

namespace JobTracker;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
    options) : base(options)
    {
    }

    public DbSet<JobApplication> JobApplications { get; set; }

}
