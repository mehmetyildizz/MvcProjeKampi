namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        TalentName = c.String(maxLength: 25),
                        TalentValue = c.Byte(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentID)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Talents", new[] { "WriterID" });
            DropTable("dbo.Talents");
        }
    }
}
