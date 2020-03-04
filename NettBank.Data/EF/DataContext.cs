namespace NettBank.Data.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<LoanCompany> LoanCompanies { get; set; }
        public virtual DbSet<LoanTypeLoanCompany> LoanTypeLoanCompanies { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<LoanCompany>()
                .HasMany(e => e.LoanTypeLoanCompanies)
                .WithRequired(e => e.LoanCompany)
                .HasForeignKey(e => e.LoanCompany_Id);

            modelBuilder.Entity<LoanType>()
                .HasMany(e => e.LoanTypeLoanCompanies)
                .WithRequired(e => e.LoanType)
                .HasForeignKey(e => e.LoanType_Id);
        }
    }
}
