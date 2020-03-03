namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLoantype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoanTypes", "Icon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoanTypes", "Icon", c => c.String());
        }
    }
}
