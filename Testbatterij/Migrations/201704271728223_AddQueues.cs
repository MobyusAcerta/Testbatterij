namespace Testbatterij.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddQueues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestScenarios", "SendQueue", c => c.String(nullable: false));
            AddColumn("dbo.TestScenarios", "ReceiveQueue", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestScenarios", "ReceiveQueue");
            DropColumn("dbo.TestScenarios", "SendQueue");
        }
    }
}
