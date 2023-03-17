CREATE TABLE [dbo].[ExportLog]
(
	[ExportLogId] [int] IDENTITY(1,1) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[ContractNumber] [varchar](15) NOT NULL,
	[Step] [varchar](20) NOT NULL,
	[ExportDescription] [varchar](2000) NULL,
	CONSTRAINT [PK_ExportLog] PRIMARY KEY CLUSTERED ([ExportLogId] ASC)
)
