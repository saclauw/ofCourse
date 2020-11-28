namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEnrollmentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EnrollmentTypes (Id, RegistrationCost, DurationInDays) VALUES (1, 0, 30)");
            Sql("INSERT INTO EnrollmentTypes (Id, RegistrationCost, DurationInDays) VALUES (2, 100, 90)");
            Sql("INSERT INTO EnrollmentTypes (Id, RegistrationCost, DurationInDays) VALUES (3, 150, 120)");
            Sql("INSERT INTO EnrollmentTypes (Id, RegistrationCost, DurationInDays) VALUES (4, 175, 180)");
        }
        
        public override void Down()
        {
        }
    }
}
