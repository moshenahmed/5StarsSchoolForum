namespace _5StarsSchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "PostingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "PostingDate", c => c.DateTime(nullable: false));
        }
    }
}
