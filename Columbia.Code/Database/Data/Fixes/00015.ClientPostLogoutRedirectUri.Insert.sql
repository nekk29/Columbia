DECLARE @PostLogoutRedirectUri VARCHAR(250)
DECLARE @ClientCode VARCHAR(200) = '$safeproductname_lower$'
DECLARE @ClientId INT = (SELECT TOP 1 [Id] FROM [dbo].[Clients] WHERE [ClientId] = @ClientCode)

IF @ClientId IS NOT NULL
BEGIN
	-- Front Application
	SET @PostLogoutRedirectUri = 'https://localhost:3000/#/auth/signout#'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientPostLogoutRedirectUris] WHERE [ClientId] = @ClientId AND [PostLogoutRedirectUri] = @PostLogoutRedirectUri)
	BEGIN
		INSERT INTO [dbo].[ClientPostLogoutRedirectUris] ([ClientId], [PostLogoutRedirectUri]) VALUES (@ClientId, @PostLogoutRedirectUri)
	END
END
