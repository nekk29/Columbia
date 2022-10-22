DECLARE @DateTime DATETIME = GETDATE();
DECLARE @UserName NVARCHAR(256) = 'administrator';

DECLARE @Name NVARCHAR(256) = 'Administrator';
DECLARE @ConcurrencyStamp NVARCHAR(MAX) = NEWID();

IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[AspNetRoles] WHERE [Name] = @Name)
BEGIN
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
    ) VALUES (
        NEWID(),
        @Name,
        UPPER(@Name),
        @ConcurrencyStamp,
        @UserName,
        @DateTime,
        @UserName,
        @DateTime,
        1
    );
END
