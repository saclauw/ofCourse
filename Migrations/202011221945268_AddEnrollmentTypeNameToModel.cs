namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentTypeNameToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnrollmentTypes", "EnrollmentTypeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnrollmentTypes", "EnrollmentTypeName");
        }
    }
}
