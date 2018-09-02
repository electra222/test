namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b2abfda-f7b9-47f1-bc45-1b6de3f3328f', N'guest@autoseller.com', 0, N'ABQ9h9+0NqV9eBGPgJ4MvsaxscriyR6gsaOM8rLzTfSMxOjOMCkr6avG5ftZcDmgdg==', N'8cd7c199-b6ca-46db-8e9c-a986d6f90ca1', NULL, 0, 0, NULL, 1, 0, N'guest@autoseller.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7eb7b8d8-401d-4f95-9685-df1bbf0a3632', N'admin@autoseller.com', 0, N'ANAYkpJNUkp8BV3zcDtgvTjIhciBiBnCtdgC4tKQWYMaBd1oz44q7RxaZ8WnMDKoww==', N'8319a51f-8e4f-49a3-87cf-63a34fe606ab', NULL, 0, 0, NULL, 1, 0, N'admin@autoseller.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'60744cc2-a1c2-4805-8151-21d5a41174eb', N'CanManageAutomobiles')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7eb7b8d8-401d-4f95-9685-df1bbf0a3632', N'60744cc2-a1c2-4805-8151-21d5a41174eb')

");
        }
        
        public override void Down()
        {
        }
    }
}
