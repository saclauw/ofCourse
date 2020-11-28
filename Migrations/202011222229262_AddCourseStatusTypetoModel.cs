namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseStatusTypetoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseStatusTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        CourseStatusTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "CourseStatusTypeId", c => c.Byte(nullable: true));
            CreateIndex("dbo.Students", "CourseStatusTypeId");
            AddForeignKey("dbo.Students", "CourseStatusTypeId", "dbo.CourseStatusTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseStatusTypeId", "dbo.CourseStatusTypes");
            DropIndex("dbo.Students", new[] { "CourseStatusTypeId" });
            DropColumn("dbo.Students", "CourseStatusTypeId");
            DropTable("dbo.CourseStatusTypes");
        }
    }
}
