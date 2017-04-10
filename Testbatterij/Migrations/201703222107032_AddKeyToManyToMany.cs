namespace Testbatterij.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyToManyToMany : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TestSetTestScenarios");
            AddPrimaryKey("dbo.TestSetTestScenarios", new[] { "TestSetId", "TestScenarioId", "Order" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TestSetTestScenarios");
            AddPrimaryKey("dbo.TestSetTestScenarios", new[] { "TestSetId", "TestScenarioId" });
        }
    }
}
