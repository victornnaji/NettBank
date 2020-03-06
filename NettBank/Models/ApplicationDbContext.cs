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
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanType>()
                .HasMany(lt => lt.LoanCompanies)
                .WithMany(lc => lc.LoanTypes)
                .Map(m =>
               {
                   m.ToTable("LoanTypeLoanCompanies");
                   m.MapLeftKey("LoanTypeId");
                   m.MapRightKey("LoanCompanyId");
               });

            base.OnModelCreating(modelBuilder);
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}