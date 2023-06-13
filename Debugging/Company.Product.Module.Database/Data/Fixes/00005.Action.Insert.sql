DECLARE @User NVARCHAR(256) = 'administrator';
DECLARE @Date DATETIME = GETDATE();

DECLARE @ParentId UNIQUEIDENTIFIER
DECLARE @ParentCode VARCHAR(64)

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[ParentCode] VARCHAR(64),
	[ModuleCode] VARCHAR(64),
	[Code] VARCHAR(64),
	[Name] VARCHAR(256),
	[Description] VARCHAR(1024)
);

INSERT INTO @DataTable([ParentCode], [ModuleCode], [Code], [Name], [Description])
-- Users
		  SELECT NULL, 'users', 'users.create', 'Create User', 'Allows you to create new users'
UNION ALL SELECT NULL, 'users', 'users.edit', 'Edit User', 'Allows you to edit existing users'
UNION ALL SELECT NULL, 'users', 'users.delete', 'Delete User', 'Allows you to delete existing users'
UNION ALL SELECT NULL, 'users', 'users.search', 'Search Users', 'Allows you to search users by criteria'
-- Roles
UNION ALL SELECT NULL, 'roles', 'roles.create', 'Create Roles', 'Allows you to create new roles'
UNION ALL SELECT NULL, 'roles', 'roles.edit', 'Edit Roles', 'Allows you to edit existing roles'
UNION ALL SELECT NULL, 'roles', 'roles.delete', 'Delete Roles', 'Allows you to delete existing roles'
UNION ALL SELECT NULL, 'roles', 'roles.search', 'Search Roles', 'Allows you to search roles by criteria'
-- Settings
UNION ALL SELECT NULL, 'settings', 'settings.edit', 'Edit Settings', 'Allows you to edit existing settings'
UNION ALL SELECT NULL, 'settings', 'settings.search', 'Search Settings', 'Allows you to search settings by criteria'

DECLARE @Index INT = 1
DECLARE @Count INT = (SELECT COUNT(1) FROM @DataTable)

WHILE @Index <= @Count
BEGIN
	SET @ParentId = NULL;

	SELECT TOP 1
		@ParentCode	= [ParentCode]
	FROM @DataTable WHERE [Id] = @Index;
	
	SELECT TOP 1
		@ParentId	= [a].[Id]
	FROM [dbo].[Actions] [a]
	WHERE 1 = 1
		AND @ParentCode IS NOT NULL
		AND [a].[Code] = @ParentCode;

	INSERT INTO [dbo].[Actions] (
		[Id],
		[ParentActionId],
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
		@ParentId,
		[m].[Id],
		[dt].[Code],
		[dt].[Name],
		[dt].[Description],
		@User,
		@Date,
		@User,
		@Date,
		1
	FROM @DataTable [dt]
	INNER JOIN [dbo].[Modules] [m] ON [dt].[ModuleCode] = [m].[Code]
	WHERE 1 = 1
		AND [dt].[Id] = @Index
		AND [m].[Id] IS NOT NULL
		AND NOT EXISTS (
			SELECT 1 FROM [dbo].[Actions] [a]
			WHERE 1 = 1
				AND [a].[Code] = [dt].[Code]
		);

	SET @Index = @Index + 1
END
