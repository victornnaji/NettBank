namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase15 : DbMigration
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
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(nullable: false),
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
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .ForeignKey("dbo.LoanCompanies", t => t.LoanCompanyId, cascadeDelete: true)
                .Index(t => t.LoanTypeId)
                .Index(t => t.LoanCompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes");
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropTable("dbo.LoanTypeLoanCompanies");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanCompanies");
        }
    }
}
