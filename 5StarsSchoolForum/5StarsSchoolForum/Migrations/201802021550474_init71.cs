namespace _5StarsSchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init71 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "user", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "user");
        }
    }
}
