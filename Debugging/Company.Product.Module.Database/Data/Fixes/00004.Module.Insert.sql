DECLARE @User NVARCHAR(256) = 'administrator';
DECLARE @Date DATETIME = GETDATE();

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
    @User,
    @Date,
    @User,
    @Date,
    1
FROM @DataTable [dt]
WHERE NOT EXISTS (
	SELECT 1 FROM [dbo].[Modules] [m]
	WHERE 1 = 1
		AND [m].[Code] = [dt].[Code]
);
