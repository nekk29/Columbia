DECLARE @Scope VARCHAR(250)
DECLARE @ClientCode VARCHAR(200) = 'product'
DECLARE @ClientId INT = (SELECT TOP 1 [Id] FROM [dbo].[Clients] WHERE [ClientId] = @ClientCode)

IF @ClientId IS NOT NULL
BEGIN
	SET @Scope = 'openid'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientScopes] WHERE [ClientId] = @ClientId AND [Scope] = @Scope)
	BEGIN
		INSERT INTO [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@ClientId, @Scope)
	END

	SET @Scope = 'profile'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientScopes] WHERE [ClientId] = @ClientId AND [Scope] = @Scope)
	BEGIN
		INSERT INTO [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@ClientId, @Scope)
	END

	SET @Scope = 'email'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientScopes] WHERE [ClientId] = @ClientId AND [Scope] = @Scope)
	BEGIN
		INSERT INTO [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@ClientId, @Scope)
	END

	SET @Scope = 'role'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientScopes] WHERE [ClientId] = @ClientId AND [Scope] = @Scope)
	BEGIN
		INSERT INTO [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@ClientId, @Scope)
	END

	SET @Scope = 'product.apis'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientScopes] WHERE [ClientId] = @ClientId AND [Scope] = @Scope)
	BEGIN
		INSERT INTO [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@ClientId, @Scope)
	END
END
