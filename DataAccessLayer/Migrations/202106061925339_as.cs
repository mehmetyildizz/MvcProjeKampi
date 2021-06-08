namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatusSender", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatusReceiver", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatusDraft", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageStatusSerder");
            DropColumn("dbo.Messages", "MessageStatusReciver");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageStatusReciver", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatusSerder", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageStatusDraft");
            DropColumn("dbo.Messages", "MessageStatusReceiver");
            DropColumn("dbo.Messages", "MessageStatusSender");
        }
    }
}
