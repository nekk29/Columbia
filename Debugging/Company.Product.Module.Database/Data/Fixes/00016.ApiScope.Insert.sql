DECLARE @ApiScope VARCHAR(200) = 'security.apis'

IF NOT EXISTS (SELECT 1 FROM [dbo].[ApiScopes] WHERE [Name] = @ApiScope)
BEGIN
	INSERT INTO [dbo].[ApiScopes] (
		[Enabled],
		[Name],
		[DisplayName],
		[Description],
		[Required],
		[Emphasize],
		[ShowInDiscoveryDocument]
	)
	VALUES (
		1,
		@ApiScope,
		'Security Apis',
		'Security Apis Scope',
		1,
		1,
		1
	)
END
