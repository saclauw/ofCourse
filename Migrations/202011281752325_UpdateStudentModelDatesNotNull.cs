namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentModelDatesNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "EnrolledInCourseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Grade", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Grade", c => c.String());
            AlterColumn("dbo.Students", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Students", "EnrolledInCourseDate", c => c.DateTime());
        }
    }
}
