namespace _5StarsSchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "PostingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "PostingDate", c => c.DateTime());
        }
    }
}
