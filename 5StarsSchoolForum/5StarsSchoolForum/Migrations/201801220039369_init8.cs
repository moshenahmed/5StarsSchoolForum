namespace _5StarsSchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "MessageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Replies", "MessageId");
            AddForeignKey("dbo.Replies", "MessageId", "dbo.Messages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "MessageId", "dbo.Messages");
            DropIndex("dbo.Replies", new[] { "MessageId" });
            DropColumn("dbo.Replies", "MessageId");
        }
    }
}
