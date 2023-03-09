CREATE TABLE [dbo].[ServiceTypes]
(
	[ServiceTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceTypeName] [varchar](60) NOT NULL,
	[ShortTitle] [varchar](10) NULL,
	CONSTRAINT [PK_ServiceTypes] PRIMARY KEY CLUSTERED ([ServiceTypeId] ASC)
)
