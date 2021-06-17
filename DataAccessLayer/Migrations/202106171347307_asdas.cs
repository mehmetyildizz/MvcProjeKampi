namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Talents", "TalentValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Talents", "TalentValue", c => c.Byte(nullable: false));
        }
    }
}
