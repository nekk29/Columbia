DECLARE @DateTime DATETIME = GETDATE();
DECLARE @UserName NVARCHAR(256) = 'administrator';
DECLARE @Email NVARCHAR(256) = 'njose29@outlook.com';
DECLARE @PasswordHash NVARCHAR(MAX) = '';
DECLARE @SecurityStamp NVARCHAR(MAX) = '';
DECLARE @ConcurrencyStamp NVARCHAR(MAX) = NEWID();

IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[AspNetUsers] WHERE [UserName] = @UserName AND [Email] = @Email)
BEGIN
    INSERT INTO [dbo].[AspNetUsers] (
        [Id],
        [FirstName],
        [LastName],
        [UserName],
        [NormalizedUserName],
        [Email],
        [NormalizedEmail],
        [EmailConfirmed],
        [PasswordHash],
        [SecurityStamp],
        [ConcurrencyStamp],
        [PhoneNumber],
        [PhoneNumberConfirmed],
        [TwoFactorEnabled],
        [LockoutEnd],
        [LockoutEnabled],
        [AccessFailedCount],
        [CreationUser],
        [CreationDate],
        [UpdateUser],
        [UpdateDate],
        [IsActive]
    ) VALUES (
        NEWID(),
        'Administrator',
        '',
        @UserName,
        UPPER(@UserName),
        @Email,
        UPPER(@Email),
        1,
        @PasswordHash,
        @SecurityStamp,
        @ConcurrencyStamp,
        NULL,
        0,
        0,
        NULL,
        1,
        0,
        @UserName,
        @DateTime,
        @UserName,
        @DateTime,
        1
    );
END
