DECLARE @GrantType VARCHAR(250)
DECLARE @ClientCode VARCHAR(200) = '$safeproductname_lower$'
DECLARE @ClientId INT = (SELECT TOP 1 [Id] FROM [dbo].[Clients] WHERE [ClientId] = @ClientCode)

IF @ClientId IS NOT NULL
BEGIN
	SET @GrantType = 'code'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientGrantTypes] WHERE [ClientId] = @ClientId AND [GrantType] = @GrantType)
	BEGIN
		INSERT INTO [dbo].[ClientGrantTypes] ([ClientId], [GrantType]) VALUES (@ClientId, @GrantType)
	END

	SET @GrantType = 'implicit'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientGrantTypes] WHERE [ClientId] = @ClientId AND [GrantType] = @GrantType)
	BEGIN
		INSERT INTO [dbo].[ClientGrantTypes] ([ClientId], [GrantType]) VALUES (@ClientId, @GrantType)
	END

	SET @GrantType = 'client_credentials'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientGrantTypes] WHERE [ClientId] = @ClientId AND [GrantType] = @GrantType)
	BEGIN
		INSERT INTO [dbo].[ClientGrantTypes] ([ClientId], [GrantType]) VALUES (@ClientId, @GrantType)
	END
END
