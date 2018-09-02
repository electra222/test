namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45703df2-b4ba-4aa0-9d0e-ac6f63293297', N'admin@autoseller.com', 0, N'AKmgIIYxBsCBVKBZzqOVciJXYlxhQG/+HDeWBJ38SL6LtD1DTIld8CEG8AQGwzfHlg==', N'66ffe6c0-9b6f-415b-aac3-44e53d02736c', NULL, 0, 0, NULL, 1, 0, N'admin@autoseller.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec4af8be-63e1-4a0d-8319-351a97bd7a23', N'guest@autoseller.com', 0, N'AD2Yn4sllDqsH8y9pAYNpBs/MVD0r0CSQwd9VcmfolilODo3BNYc9l43Z8mRlE6c5Q==', N'25b3e986-2112-4e3d-9690-f8c6c58d8c76', NULL, 0, 0, NULL, 1, 0, N'guest@autoseller.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'59e0a2d6-fa0c-461b-8813-f74d2efa72a4', N'CanManageAutomobiles')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'45703df2-b4ba-4aa0-9d0e-ac6f63293297', N'59e0a2d6-fa0c-461b-8813-f74d2efa72a4')

");
        }
        
        public override void Down()
        {
        }
    }
}
