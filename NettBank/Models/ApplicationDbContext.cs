using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NettBank.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<LoanCompany> LoanCompanies { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        //public DbSet<LoanTypeTypeCompany> TypeCompanies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}