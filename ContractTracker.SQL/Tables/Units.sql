CREATE TABLE [dbo].[Units]
(
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[Bureau] [varchar](100) NULL,
	[SectionDesc] [varchar](100) NULL,
	[Section] [varchar](200) NULL,
	[UnitCode] [varchar](5) NULL,
	[AllUsersCanSubmit] [bit] NULL,
	[PurchaseRequiresSpecialRouting] [bit] NULL,
	[EndDate] [datetime] NULL,
	CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED ([UnitId] ASC),
)
