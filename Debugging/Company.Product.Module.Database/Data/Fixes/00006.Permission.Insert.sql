DECLARE @DateTime DATETIME = GETDATE();
DECLARE @UserName NVARCHAR(256) = 'administrator';

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[RoleName] NVARCHAR(256),
	[ActionCode] NVARCHAR(64)
);

INSERT INTO @DataTable([RoleName], [ActionCode])
-- Administrator
		  SELECT 'Administrator', 'users.create'
UNION ALL SELECT 'Administrator', 'users.edit'
UNION ALL SELECT 'Administrator', 'users.delete'
UNION ALL SELECT 'Administrator', 'users.search'


INSERT INTO [dbo].[Permissions] (
	[Id],
	[RoleId],
	[ActionId],
    [CreationUser],
    [CreationDate],
    [UpdateUser],
    [UpdateDate],
    [IsActive]
)
SELECT
	NEWID(),
	[r].[Id],
	[a].[Id],
    @UserName,
    @DateTime,
    @UserName,
    @DateTime,
    1
FROM @DataTable [dt]
INNER JOIN [dbo].[AspNetRoles] [r] ON [dt].[RoleName] = [r].[Name]
INNER JOIN [dbo].[Actions] [a] ON [dt].[ActionCode] = [a].[Code]
WHERE 1 = 1
	AND [r].[Id] IS NOT NULL
	AND [a].[Id] IS NOT NULL
	AND NOT EXISTS (
		SELECT 1 FROM [dbo].[Permissions] [p]
		WHERE 1 = 1
			AND [p].[RoleId] = [r].[Id]
			AND [p].[ActionId] = [a].[Id]
	);
