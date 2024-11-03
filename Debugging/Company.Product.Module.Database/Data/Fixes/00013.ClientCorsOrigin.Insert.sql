DECLARE @Origin VARCHAR(250)
DECLARE @ClientCode VARCHAR(200) = 'product'
DECLARE @ClientId INT = (SELECT TOP 1 [Id] FROM [dbo].[Clients] WHERE [ClientId] = @ClientCode)

IF @ClientId IS NOT NULL
BEGIN
	-- Front Application
	SET @Origin = 'https://localhost:3000'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientCorsOrigins] WHERE [ClientId] = @ClientId AND [Origin] = @Origin)
	BEGIN
		INSERT INTO [dbo].[ClientCorsOrigins] ([ClientId], [Origin]) VALUES (@ClientId, @Origin)
	END
	
	-- Back Application
	SET @Origin = 'https://localhost:7202'
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[ClientCorsOrigins] WHERE [ClientId] = @ClientId AND [Origin] = @Origin)
	BEGIN
		INSERT INTO [dbo].[ClientCorsOrigins] ([ClientId], [Origin]) VALUES (@ClientId, @Origin)
	END
END
