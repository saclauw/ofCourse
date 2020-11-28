namespace ofCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        { 
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8e11e190-6351-4c23-b80f-cfe5b7b07150', N'admin@ofCourse.com', 0, N'AOWY2MIS1ZNaS5Q/QemJzYrrGGdZ6TSlzdL4qNg0IMGDO80mINE3098Lep32JYVNHw==', N'adbed9c8-e5d5-43cb-a836-9f5856101be7', NULL, 0, 0, NULL, 1, 0, N'admin@ofCourse.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aef3d0a5-ce59-4aa9-8b75-049e678c2110', N'guest@ofCourse.com', 0, N'ABzG+qjJFHyN6zMXciTY783yU13/FCdPazovAhmWwLm/7lg1x4SLVyibl/W9suZTCQ==', N'4cbb2492-38ac-4d84-b2d0-99d575bab424', NULL, 0, 0, NULL, 1, 0, N'guest@ofCourse.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'92204531-c15e-484a-988b-01ef0e9d956a', N'CanManageStudents')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8e11e190-6351-4c23-b80f-cfe5b7b07150', N'92204531-c15e-484a-988b-01ef0e9d956a')


");

        }
        
        public override void Down()
        {
        }
    }
}
