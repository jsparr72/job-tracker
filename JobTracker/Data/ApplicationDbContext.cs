using Microsoft.EntityFrameworkCore;
namespace JobTracker.Models;

/*This class serves as the bridge between the app and the database.
*/
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
    options) : base(options)
    {
    }

/*Creates an empty table to be filled with JobApplication entities.
*/
    //public DbSet<JobTracker.Models.JobApplication> Job_Applications { get; set; }

}
