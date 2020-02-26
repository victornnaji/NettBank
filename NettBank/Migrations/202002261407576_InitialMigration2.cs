namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanType_Id", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompany_Id", "dbo.LoanCompanies");
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanType_Id" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompany_Id" });
            DropTable("dbo.LoanCompanies");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoanTypeLoanCompanies",
                c => new
                    {
                        LoanType_Id = c.Int(nullable: false),
                        LoanCompany_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanType_Id, t.LoanCompany_Id });
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateIndex("dbo.LoanTypeLoanCompanies", "LoanCompany_Id");
            CreateIndex("dbo.LoanTypeLoanCompanies", "LoanType_Id");
            AddForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompany_Id", "dbo.LoanCompanies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompanies", "LoanType_Id", "dbo.LoanTypes", "Id", cascadeDelete: true);
        }
    }
}
