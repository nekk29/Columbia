﻿DECLARE @User NVARCHAR(256) = 'administrator';
DECLARE @Date DATETIME = GETDATE();

DECLARE @DataTable TABLE (
	[Id] INT IDENTITY(1, 1),
	[RoleName] NVARCHAR(256),
	[ActionCode] NVARCHAR(64)
);

INSERT INTO @DataTable([RoleName], [ActionCode])
-- Administrator
SELECT
	'Administrator',
	[Code]
FROM [dbo].[Actions]
-- User
UNION ALL
SELECT
	'User',
	[Code]
FROM [dbo].[Actions]
WHERE 1 = 1
	AND [Code] like 'xxxxx.%'


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
    @User,
    @Date,
    @User,
    @Date,
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
	)
ORDER BY
	[dt].[RoleName],
	[dt].[ActionCode];
