CREATE TABLE [dbo].[ApplicationSettings]
(
	[ApplicationSettingsId] INT IDENTITY(1,1) NOT NULL,
	Setting VARCHAR(256) NOT NULL,
	SettingValue VARCHAR(256) NOT NULL,
	CONSTRAINT [PK_ApplicationSettings] PRIMARY KEY CLUSTERED ([ApplicationSettingsId] ASC)
)
