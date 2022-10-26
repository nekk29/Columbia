DECLARE @User NVARCHAR(256) = 'administrator';
DECLARE @Date DATETIME = GETDATE();

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[Name] VARCHAR(256)
);

INSERT INTO @DataTable([Name])
		  SELECT 'Administrator'


INSERT INTO [dbo].[AspNetRoles] (
    [Id],
    [Name],
    [NormalizedName],
    [ConcurrencyStamp],
    [CreationUser],
    [CreationDate],
    [UpdateUser],
    [UpdateDate],
    [IsActive]
)
SELECT
    NEWID(),
    [dt].[Name],
    UPPER([dt].[Name]),
    NEWID(),
    @User,
    @Date,
    @User,
    @Date,
    1
FROM @DataTable [dt]
WHERE NOT EXISTS (
    SELECT TOP 1 1 FROM [dbo].[AspNetRoles] WHERE [Name] = [dt].[Name]
);
