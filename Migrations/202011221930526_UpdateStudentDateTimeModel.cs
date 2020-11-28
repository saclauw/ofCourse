namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentDateTimeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "EnrolledInCourseDate", c => c.DateTime());
            AlterColumn("dbo.Students", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "EnrolledInCourseDate", c => c.DateTime(nullable: false));
        }
    }
}
