namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanTypeLoanCompanies",
                c => new
                    {
                        LoanType_Id = c.Int(nullable: false),
                        LoanCompany_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanType_Id, t.LoanCompany_Id })
                .ForeignKey("dbo.LoanTypes", t => t.LoanType_Id, cascadeDelete: true)
                .ForeignKey("dbo.LoanCompanies", t => t.LoanCompany_Id, cascadeDelete: true)
                .Index(t => t.LoanType_Id)
                .Index(t => t.LoanCompany_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompany_Id", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanType_Id", "dbo.LoanTypes");
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompany_Id" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanType_Id" });
            DropTable("dbo.LoanTypeLoanCompanies");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanCompanies");
        }
    }
}
