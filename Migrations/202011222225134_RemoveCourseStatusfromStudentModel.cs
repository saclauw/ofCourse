namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCourseStatusfromStudentModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "CourseStatusId");
            DropColumn("dbo.Students", "CourseStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "CourseStatus", c => c.String());
            AddColumn("dbo.Students", "CourseStatusId", c => c.Byte(nullable: false));
        }
    }
}
