namespace Testbatterij.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestScenarioTestSetRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestSetTestScenarios",
                c => new
                    {
                        TestSet_Id = c.Int(nullable: false),
                        TestScenario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestSet_Id, t.TestScenario_Id })
                .ForeignKey("dbo.TestSets", t => t.TestSet_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestScenarios", t => t.TestScenario_Id, cascadeDelete: true)
                .Index(t => t.TestSet_Id)
                .Index(t => t.TestScenario_Id);
            
            AlterColumn("dbo.TestScenarios", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TestSets", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestSetTestScenarios", "TestScenario_Id", "dbo.TestScenarios");
            DropForeignKey("dbo.TestSetTestScenarios", "TestSet_Id", "dbo.TestSets");
            DropIndex("dbo.TestSetTestScenarios", new[] { "TestScenario_Id" });
            DropIndex("dbo.TestSetTestScenarios", new[] { "TestSet_Id" });
            AlterColumn("dbo.TestSets", "Name", c => c.String());
            AlterColumn("dbo.TestScenarios", "Name", c => c.String());
            DropTable("dbo.TestSetTestScenarios");
        }
    }
}
