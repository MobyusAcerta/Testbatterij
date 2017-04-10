namespace Testbatterij.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateManyToManyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestSetTestScenarios", "TestSet_Id", "dbo.TestSets");
            DropForeignKey("dbo.TestSetTestScenarios", "TestScenario_Id", "dbo.TestScenarios");
            DropIndex("dbo.TestSetTestScenarios", new[] { "TestSet_Id" });
            DropIndex("dbo.TestSetTestScenarios", new[] { "TestScenario_Id" });

            DropTable("dbo.TestSetTestScenarios");

            CreateTable(
                "dbo.TestSetTestScenarios",
                c => new
                    {
                        TestSetId = c.Int(nullable: false),
                        TestScenarioId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestSetId, t.TestScenarioId })
                .ForeignKey("dbo.TestScenarios", t => t.TestScenarioId, cascadeDelete: true)
                .ForeignKey("dbo.TestSets", t => t.TestSetId, cascadeDelete: true)
                .Index(t => t.TestSetId)
                .Index(t => t.TestScenarioId);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestSetTestScenarios",
                c => new
                    {
                        TestSet_Id = c.Int(nullable: false),
                        TestScenario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestSet_Id, t.TestScenario_Id });
            
            DropForeignKey("dbo.TestSetTestScenarios", "TestSetId", "dbo.TestSets");
            DropForeignKey("dbo.TestSetTestScenarios", "TestScenarioId", "dbo.TestScenarios");
            DropIndex("dbo.TestSetTestScenarios", new[] { "TestScenarioId" });
            DropIndex("dbo.TestSetTestScenarios", new[] { "TestSetId" });
            DropTable("dbo.TestSetTestScenarios");
            CreateIndex("dbo.TestSetTestScenarios", "TestScenario_Id");
            CreateIndex("dbo.TestSetTestScenarios", "TestSet_Id");
            AddForeignKey("dbo.TestSetTestScenarios", "TestScenario_Id", "dbo.TestScenarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestSetTestScenarios", "TestSet_Id", "dbo.TestSets", "Id", cascadeDelete: true);
        }
    }
}
