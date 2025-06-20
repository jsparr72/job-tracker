using Microsoft.EntityFrameworkCore;
namespace JobTracker.Models
{

    /*This class serves as the bridge between the app and the database.
    */
    public class ApplicationDbContext : DbContext
    {
        // Empty table of job applications
        public DbSet<JobApplication> Job_Applications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options)
        {

        }
    }
}