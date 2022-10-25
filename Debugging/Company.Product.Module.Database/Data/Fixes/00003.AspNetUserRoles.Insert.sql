DECLARE @UserName NVARCHAR(256) = 'administrator';
DECLARE @UserId UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [dbo].[AspNetUsers] WHERE [UserName] = @UserName);

DECLARE @RoleName NVARCHAR(256) = 'Administrator';
DECLARE @RoleId UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [dbo].[AspNetRoles] WHERE [Name] = @RoleName);

IF (@UserId IS NOT NULL AND @RoleId IS NOT NULL)
BEGIN
    INSERT INTO [dbo].[AspNetUserRoles] (
        [UserId],
        [RoleId]
    ) 
    SELECT
        @UserId,
        @RoleId
    WHERE NOT EXISTS (
        SELECT TOP 1 1
        FROM [dbo].[AspNetUserRoles] [ur]
        WHERE 1 = 1
            AND [ur].[UserId] = @UserId
            AND [ur].[RoleId] = @RoleId
    );
END
