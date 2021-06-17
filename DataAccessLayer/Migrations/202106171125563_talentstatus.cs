namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talentstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talents", "TalentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talents", "TalentStatus");
        }
    }
}
