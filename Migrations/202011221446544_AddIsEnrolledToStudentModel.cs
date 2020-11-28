namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsEnrolledToStudentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "isEnrolled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "isEnrolled");
        }
    }
}
