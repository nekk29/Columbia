DECLARE @ClientCode VARCHAR(200) = '$safeproductname_lower$'
DECLARE @ClientId INT = (SELECT TOP 1 [Id] FROM [dbo].[Clients] WHERE [ClientId] = @ClientCode)

DECLARE @Value VARCHAR(250) = '[SECURITY_SECRET]'
DECLARE @Description VARCHAR(250) = '$safeproductname$ Secret'

IF @ClientId IS NOT NULL
BEGIN
	IF NOT EXISTS (SELECT 1 FROM [dbo].[ClientSecrets] WHERE [ClientId] = @ClientId AND [Description] = @Description)
	BEGIN
		INSERT INTO [dbo].[ClientSecrets] (
			[ClientId],
			[Description],
			[Value],
			[Expiration],
			[Type],
			[Created]
		)
		VALUES (
			@ClientId,
			@Description,
			@Value,
			NULL,
			'SharedSecret',
			GETDATE()
		)
	END
END
