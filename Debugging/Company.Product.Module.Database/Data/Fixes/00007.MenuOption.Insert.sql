DECLARE @DateTime DATETIME = GETDATE();
DECLARE @UserName NVARCHAR(256) = 'administrator';

DECLARE @ActionId UNIQUEIDENTIFIER
DECLARE @ActionCode VARCHAR(64)

DECLARE @ParentId UNIQUEIDENTIFIER
DECLARE @ParentCode VARCHAR(64)

DECLARE @Code VARCHAR(64)
DECLARE @Name VARCHAR(256)
DECLARE @Description VARCHAR(1024)
DECLARE @MenuUri VARCHAR(MAX)
DECLARE @MenuIcon VARCHAR(MAX)
DECLARE @SortOrder INT

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[ActionCode] VARCHAR(64),
	[ParentCode] VARCHAR(64),
	[Code] VARCHAR(64),
	[Name] VARCHAR(256),
	[Description] VARCHAR(1024),
	[MenuUri] VARCHAR(MAX),
	[MenuIcon] VARCHAR(MAX),
	[SortOrder] INT
);

INSERT INTO @DataTable([ActionCode], [ParentCode], [Code], [Name], [Description], [MenuUri], [MenuIcon], [SortOrder])
-- Users
		  SELECT 'users.search', NULL, 'users.search', 'Users', 'Users Search', '/users', 'flaticon2-user', 0


DECLARE @Index INT = 1
DECLARE @Count INT = (SELECT COUNT(1) FROM @DataTable)

WHILE @Index <= @Count
BEGIN
	SELECT TOP 1
		@ActionCode		= [ActionCode],
		@ParentCode		= [ParentCode],
		@Code			= [Code],
		@Name			= [Name],
		@Description	= [Description],
		@MenuUri		= [MenuUri],
		@MenuIcon		= [MenuIcon],
		@SortOrder		= [SortOrder]
	FROM @DataTable WHERE [Id] = @Index
	
	SET @ActionId = (SELECT TOP 1 [Id] FROM [Actions]		WHERE [Code] = @ActionCode)
	SET @ParentId = (SELECT TOP 1 [Id] FROM [MenuOptions]	WHERE [Code] = @ParentCode)

	IF @ActionId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[MenuOptions] WHERE [Code] = @Code)
	BEGIN
		INSERT INTO [dbo].[MenuOptions] (
			[Id],
			[ParentMenuOptionId],
			[ActionId],
			[Code],
			[Name],
			[Description],
			[MenuUri],
			[MenuIcon],
			[SortOrder],
			[CreationUser],
			[CreationDate],
			[UpdateUser],
			[UpdateDate],
			[IsActive]
		) VALUES (
			NEWID(),
			@ParentId,
			@ActionId,
			@Code,
			@Name,
			@Description,
			@MenuUri,
			@MenuIcon,
			@SortOrder,
			@UserName,
			@DateTime,
			@UserName,
			@DateTime,
			1
		)
	END

	SET @Index = @Index + 1
END
