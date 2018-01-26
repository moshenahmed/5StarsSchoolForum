namespace _5StarsSchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "EnrollmentDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Messages", "PostTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Messages", "LastEditTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Replies", "ReplyTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Replies", "LastEditTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Replies", "LastEditTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Replies", "ReplyTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Messages", "LastEditTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Messages", "PostTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
    }
}
