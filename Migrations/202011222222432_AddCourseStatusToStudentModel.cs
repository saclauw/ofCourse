namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseStatusToStudentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CourseStatusId", c => c.Byte(nullable: true));
            AddColumn("dbo.Students", "CourseStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "CourseStatus");
            DropColumn("dbo.Students", "CourseStatusId");
        }
    }
}
