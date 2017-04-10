namespace Testbatterij.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestToTestScenario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestScenarios", "Request", c => c.String(nullable: false, storeType: "xml"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestScenarios", "Request");
        }
    }
}
