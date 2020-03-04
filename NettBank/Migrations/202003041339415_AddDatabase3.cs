namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase3 : DbMigration
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
                .ForeignKey("dbo.LoanCompanies", t => t.LoanCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .Index(t => t.LoanTypeId)
                .Index(t => t.LoanCompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies1", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies1", "LoanCompanyId", "dbo.LoanCompanies");
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropIndex("dbo.LoanTypeLoanCompanies1", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies1", new[] { "LoanTypeId" });
            DropTable("dbo.LoanTypeLoanCompanies");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompanies1");
            DropTable("dbo.LoanCompanies");
        }
    }
}
