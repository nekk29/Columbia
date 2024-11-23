DECLARE @RedirectUri VARCHAR(250)
DECLARE @ClientCode VARCHAR(200) = 'product'
DECLARE @ClientId INT = (SELECT TOP 1 [Id] FROM [dbo].[Clients] WHERE [ClientId] = @ClientCode)

IF @ClientId IS NOT NULL
BEGIN
	-- Front Application
	SET @RedirectUri = 'https://localhost:4200/auth/signin'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientRedirectUris] WHERE [ClientId] = @ClientId AND [RedirectUri] = @RedirectUri)
	BEGIN
		INSERT INTO [dbo].[ClientRedirectUris] ([ClientId], [RedirectUri]) VALUES (@ClientId, @RedirectUri)
	END
	
	SET @RedirectUri = 'https://localhost:4200/silent-refresh.html'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientRedirectUris] WHERE [ClientId] = @ClientId AND [RedirectUri] = @RedirectUri)
	BEGIN
		INSERT INTO [dbo].[ClientRedirectUris] ([ClientId], [RedirectUri]) VALUES (@ClientId, @RedirectUri)
	END
	
	-- Back Application
	SET @RedirectUri = 'https://localhost:7202/oauth2-redirect.html'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientRedirectUris] WHERE [ClientId] = @ClientId AND [RedirectUri] = @RedirectUri)
	BEGIN
		INSERT INTO [dbo].[ClientRedirectUris] ([ClientId], [RedirectUri]) VALUES (@ClientId, @RedirectUri)
	END
END
