namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTable1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LoanTypeLoanCompanies", name: "LoanTypeId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.LoanTypeLoanCompanies", name: "LoanCompanyId", newName: "LoanTypeId");
            RenameColumn(table: "dbo.LoanTypeLoanCompanies", name: "__mig_tmp__0", newName: "LoanCompanyId");
            RenameIndex(table: "dbo.LoanTypeLoanCompanies", name: "IX_LoanTypeId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.LoanTypeLoanCompanies", name: "IX_LoanCompanyId", newName: "IX_LoanTypeId");
            RenameIndex(table: "dbo.LoanTypeLoanCompanies", name: "__mig_tmp__0", newName: "IX_LoanCompanyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LoanTypeLoanCompanies", name: "IX_LoanCompanyId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.LoanTypeLoanCompanies", name: "IX_LoanTypeId", newName: "IX_LoanCompanyId");
            RenameIndex(table: "dbo.LoanTypeLoanCompanies", name: "__mig_tmp__0", newName: "IX_LoanTypeId");
            RenameColumn(table: "dbo.LoanTypeLoanCompanies", name: "LoanCompanyId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.LoanTypeLoanCompanies", name: "LoanTypeId", newName: "LoanCompanyId");
            RenameColumn(table: "dbo.LoanTypeLoanCompanies", name: "__mig_tmp__0", newName: "LoanTypeId");
        }
    }
}
