namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanDabase2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies1", "LoanCompanyId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies1", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes");
            DropIndex("dbo.LoanTypeLoanCompanies1", new[] { "LoanTypeId" });
            DropIndex("dbo.LoanTypeLoanCompanies1", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropTable("dbo.LoanCompanies");
            DropTable("dbo.LoanTypeLoanCompanies1");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoanTypeLoanCompanies",
                c => new
                    {
                        LoanCompanyId = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanCompanyId, t.LoanTypeId });
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanTypeLoanCompanies1",
                c => new
                    {
                        LoanTypeId = c.Int(nullable: false),
                        LoanCompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanTypeId, t.LoanCompanyId });
            
            CreateTable(
                "dbo.LoanCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        ComparisonRate = c.Double(nullable: false),
                        RepaymentFrequency = c.String(nullable: false),
                        MaxDuration = c.Int(nullable: false),
                        MaxAmount = c.Long(nullable: false),
                        MinAmount = c.Long(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Catch = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.LoanTypeLoanCompanies", "LoanTypeId");
            CreateIndex("dbo.LoanTypeLoanCompanies", "LoanCompanyId");
            CreateIndex("dbo.LoanTypeLoanCompanies1", "LoanCompanyId");
            CreateIndex("dbo.LoanTypeLoanCompanies1", "LoanTypeId");
            AddForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompanies1", "LoanTypeId", "dbo.LoanTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompanies1", "LoanCompanyId", "dbo.LoanCompanies", "Id", cascadeDelete: true);
        }
    }
}
