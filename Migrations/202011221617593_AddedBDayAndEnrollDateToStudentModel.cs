namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBDayAndEnrollDateToStudentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "EnrolledInCourseDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.Students", "Birthdate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Birthdate");
            DropColumn("dbo.Students", "EnrolledInCourseDate");
        }
    }
}
                