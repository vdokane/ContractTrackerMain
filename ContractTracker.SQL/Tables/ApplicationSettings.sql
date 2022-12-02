CREATE TABLE [dbo].[ApplicationSettings]
(
	Setting VARCHAR(256) NOT NULL,
	SettingValue VARCHAR(256) NOT NULL,
	CONSTRAINT [PK_ApplicationSettings] PRIMARY KEY CLUSTERED ([Setting] ASC)
)
