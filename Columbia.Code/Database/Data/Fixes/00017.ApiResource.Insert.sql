﻿DECLARE @ApiResource VARCHAR(200) = 'security.apis'

IF NOT EXISTS (SELECT 1 FROM [dbo].[ApiResources] WHERE [Name] = @ApiResource)
BEGIN
	INSERT INTO [dbo].[ApiResources] (
		[Enabled],
		[Name],
		[DisplayName],
		[Description],
		[AllowedAccessTokenSigningAlgorithms],
		[ShowInDiscoveryDocument],
		[Created],
		[Updated],
		[LastAccessed],
		[NonEditable]
	)
	VALUES (
		1,
		@ApiResource,
		'Security Apis',
		'Security Apis Resource',
		1,
		1,
		GETDATE(),
		NULL,
		NULL,
		1
	)
END