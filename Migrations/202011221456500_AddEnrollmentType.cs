namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollmentTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        RegistrationCost = c.Short(nullable: false),
                        DurationInDays = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "EnrollmentTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Students", "EnrollmentTypeId");
            AddForeignKey("dbo.Students", "EnrollmentTypeId", "dbo.EnrollmentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "EnrollmentTypeId", "dbo.EnrollmentTypes");
            DropIndex("dbo.Students", new[] { "EnrollmentTypeId" });
            DropColumn("dbo.Students", "EnrollmentTypeId");
            DropTable("dbo.EnrollmentTypes");
        }
    }
}
