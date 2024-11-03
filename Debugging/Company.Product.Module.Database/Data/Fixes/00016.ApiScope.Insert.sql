DECLARE @ApiScope VARCHAR(200) = 'product.apis'

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
		'Product Apis',
		'Product Apis Scope',
		1,
		1,
		1
	)
END
