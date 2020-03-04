namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase2 : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.LoanTypeLoanCompanies",
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
                "dbo.LoanCompanyLoanTypes",
                c => new
                    {
                        LoanCompanyId = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanCompanyId, t.LoanTypeId })
                .ForeignKey("dbo.LoanCompanies", t => t.LoanCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .Index(t => t.LoanCompanyId)
                .Index(t => t.LoanTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanCompanyLoanTypes", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanCompanyLoanTypes", "LoanCompanyId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies");
            DropIndex("dbo.LoanCompanyLoanTypes", new[] { "LoanTypeId" });
            DropIndex("dbo.LoanCompanyLoanTypes", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropTable("dbo.LoanCompanyLoanTypes");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompanies");
            DropTable("dbo.LoanCompanies");
        }
    }
}
