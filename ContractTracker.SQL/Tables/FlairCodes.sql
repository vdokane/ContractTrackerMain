CREATE TABLE [dbo].[FlairCodes]
(
	[FlairCodeId] INT IDENTITY(1,1) NOT NULL,
	[Org] [varchar](11) NULL,
	[EO] [varchar](2) NULL,
	[Category] [varchar](10) NULL,
	[FlairAccountCode] [varchar](29) NULL,
	CONSTRAINT [PK_FlairCodes] PRIMARY KEY CLUSTERED ([FlairCodeId] ASC),
)
