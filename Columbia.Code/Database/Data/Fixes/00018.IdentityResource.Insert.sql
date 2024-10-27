DECLARE @Name VARCHAR(250)
DECLARE @Description VARCHAR(250)

SET @Name = 'openid'
SET @Description = 'Your user identifier'
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[IdentityResources] WHERE [Name] = @Name)
BEGIN
	INSERT INTO [dbo].[IdentityResources] ([Enabled], [Name], [DisplayName], [Description], [Required], [Emphasize], [ShowInDiscoveryDocument], [Created], [NonEditable])
	VALUES (1, @Name, NULL, @Description, 1, 1, 1, GETDATE(), 1)
END

SET @Name = 'profile'
SET @Description = 'User profile'
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[IdentityResources] WHERE [Name] = @Name)
BEGIN
	INSERT INTO [dbo].[IdentityResources] ([Enabled], [Name], [DisplayName], [Description], [Required], [Emphasize], [ShowInDiscoveryDocument], [Created], [NonEditable])
	VALUES (1, @Name, NULL, @Description, 1, 1, 1, GETDATE(), 1)
END

SET @Name = 'email'
SET @Description = 'Your email address'
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[IdentityResources] WHERE [Name] = @Name)
BEGIN
	INSERT INTO [dbo].[IdentityResources] ([Enabled], [Name], [DisplayName], [Description], [Required], [Emphasize], [ShowInDiscoveryDocument], [Created], [NonEditable])
	VALUES (1, @Name, NULL, @Description, 1, 1, 1, GETDATE(), 1)
END

SET @Name = 'role'
SET @Description = 'Your role(s)'
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[IdentityResources] WHERE [Name] = @Name)
BEGIN
	INSERT INTO [dbo].[IdentityResources] ([Enabled], [Name], [DisplayName], [Description], [Required], [Emphasize], [ShowInDiscoveryDocument], [Created], [NonEditable])
	VALUES (1, @Name, NULL, @Description, 1, 1, 1, GETDATE(), 1)
END
