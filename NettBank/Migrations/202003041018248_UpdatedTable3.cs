namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTable3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.LoanTypeLoanCompanies1",
               c => new
               {
                   LoanTypeId = c.Int(nullable: false),
                   LoanCompanyId = c.Int(nullable: false),
               })
               .PrimaryKey(t => new { t.LoanTypeId, t.LoanCompanyId })
               .ForeignKey("dbo.LoanCompanies", t => t.LoanCompanyId, cascadeDelete: true)
               .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
               .Index(t => t.LoanTypeId)
               .Index(t => t.LoanCompanyId);
        }
        
        public override void Down()
        {
        }
    }
}
