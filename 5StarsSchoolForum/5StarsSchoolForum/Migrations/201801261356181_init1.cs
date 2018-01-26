namespace _5StarsSchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "EnrollmentDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
