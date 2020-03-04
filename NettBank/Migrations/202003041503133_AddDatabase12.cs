namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompany1", "LoanType_Id", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompany1", "LoanCompany_Id", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes");
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompany1", new[] { "LoanType_Id" });
            DropIndex("dbo.LoanTypeLoanCompany1", new[] { "LoanCompany_Id" });
            DropTable("dbo.LoanCompanies");
            DropTable("dbo.LoanTypeLoanCompanies");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompany1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoanTypeLoanCompany1",
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
            
            CreateIndex("dbo.LoanTypeLoanCompany1", "LoanCompany_Id");
            CreateIndex("dbo.LoanTypeLoanCompany1", "LoanType_Id");
            CreateIndex("dbo.LoanTypeLoanCompanies", "LoanCompanyId");
            CreateIndex("dbo.LoanTypeLoanCompanies", "LoanTypeId");
            AddForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompany1", "LoanCompany_Id", "dbo.LoanCompanies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompany1", "LoanType_Id", "dbo.LoanTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies", "Id", cascadeDelete: true);
        }
    }
}
