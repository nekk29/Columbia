DECLARE @DateTime DATETIME = GETDATE();
DECLARE @UserName NVARCHAR(256) = 'administrator';

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[Code] VARCHAR(64),
	[Name] VARCHAR(256),
	[Description] VARCHAR(1024)
);

INSERT INTO @DataTable([Code], [Name], [Description])
-- Users
		  SELECT 'users', 'Users', 'Users management module'


INSERT INTO [dbo].[Modules] (
	[Id],
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
	[Code],
	[Name],
	[Description],
    @UserName,
    @DateTime,
    @UserName,
    @DateTime,
    1
FROM @DataTable [dt]
WHERE NOT EXISTS (
	SELECT 1 FROM [dbo].[Modules] [m]
	WHERE 1 = 1
		AND [m].[Code] = [dt].[Code]
);
