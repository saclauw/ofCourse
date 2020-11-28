namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseRatingToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseRating");
        }
    }
}
