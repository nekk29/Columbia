DECLARE @DateTime DATETIME = GETDATE();
DECLARE @UserName NVARCHAR(256) = 'administrator';

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[ModuleCode] VARCHAR(64),
	[Code] VARCHAR(64),
	[Name] VARCHAR(256),
	[Description] VARCHAR(1024)
);

INSERT INTO @DataTable([ModuleCode], [Code], [Name], [Description])
-- Users
		  SELECT 'users', 'users.create', 'Create User', 'Allows you to create new users'
UNION ALL SELECT 'users', 'users.edit', 'Edit User', 'Allows you to edit existing users'
UNION ALL SELECT 'users', 'users.delete', 'Delete User', 'Allows you to delete existing users'
UNION ALL SELECT 'users', 'users.search', 'Search Users', 'Allows you to search users by criteria'


INSERT INTO [dbo].[Actions] (
	[Id],
	[ModuleId],
	[Code],
	[Name],
	[Description],
    [CreationUser],
    [CreationDate],
    [UpdateUser],
    [UpdateDate],
    [IsActive]
)
SELECT
	NEWID(),
	[m].[Id],
	[dt].[Code],
	[dt].[Name],
	[dt].[Description],
    @UserName,
    @DateTime,
    @UserName,
    @DateTime,
    1
FROM @DataTable [dt]
INNER JOIN [dbo].[Modules] [m] ON [dt].[ModuleCode] = [m].[Code]
WHERE 1 = 1
	AND [m].[Id] IS NOT NULL
	AND NOT EXISTS (
		SELECT 1 FROM [dbo].[Actions] [a]
		WHERE 1 = 1
			AND [a].[Code] = [dt].[Code]
	);
