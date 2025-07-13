using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace JobTracker.Models
{

    /*This class serves as the bridge between the app and the database.
    */
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options)
        {

        }

        public DbSet<JobApplication> Job_Applications { get; set; } // Job Application Table
        public DbSet<User> User_Accounts { get; set; } // Table holding user account info
    }
}