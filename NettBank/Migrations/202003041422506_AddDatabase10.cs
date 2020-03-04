namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies1", "LoanCompanyId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies1", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanTypes");
            DropIndex("dbo.LoanTypeLoanCompanies1", new[] { "LoanTypeId" });
            DropIndex("dbo.LoanTypeLoanCompanies1", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropTable("dbo.LoanCompanies");
            DropTable("dbo.LoanTypeLoanCompanies1");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompanies");
        }
        
        public override void Down()
        {
        }
    }
}
