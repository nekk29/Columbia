DECLARE @ApiScope VARCHAR(200) = '$safeproductname_lower$.apis'

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
		'$safeproductname$ Apis',
		'$safeproductname$ Apis Scope',
		1,
		1,
		1
	)
END
