CREATE TABLE [dbo].[FundTypes]
(
	[FundTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FundTypeDescription] [varchar](100) NOT NULL,
	CONSTRAINT [PK_FundTypes] PRIMARY KEY CLUSTERED ([FundTypeId] ASC)
)
