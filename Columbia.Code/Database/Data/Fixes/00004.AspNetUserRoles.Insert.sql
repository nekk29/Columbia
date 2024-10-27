﻿DECLARE @User NVARCHAR(256) = 'administrator';

DECLARE @RoleName NVARCHAR(256);
DECLARE @RoleId UNIQUEIDENTIFIER;

DECLARE @UserName NVARCHAR(256);
DECLARE @UserId UNIQUEIDENTIFIER;

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[RoleName] VARCHAR(256),
    [UserName] VARCHAR(256)
);

INSERT INTO @DataTable([RoleName], [UserName])
		  SELECT 'Administrator', 'system@administrator'
UNION ALL SELECT 'User', 'system@user'


DECLARE @Index INT = 1
DECLARE @Count INT = (SELECT COUNT(1) FROM @DataTable)

WHILE @Index <= @Count
BEGIN
    SELECT
		@RoleName = [RoleName],
		@UserName = [UserName]
	FROM @DataTable WHERE [Id] = @Index;

    SET @RoleId = (SELECT TOP 1 [Id] FROM [dbo].[AspNetRoles] WHERE [Name] = @RoleName);
    SET @UserId = (SELECT TOP 1 [Id] FROM [dbo].[AspNetUsers] WHERE [UserName] = @UserName);

    IF (@RoleId IS NOT NULL AND @UserId IS NOT NULL)
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

	SET @Index = @Index + 1
END
