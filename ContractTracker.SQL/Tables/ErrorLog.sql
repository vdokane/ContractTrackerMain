--What was this used for?
CREATE TABLE [dbo].[ErrorLogs]
(
	ErrorLogId [int] IDENTITY(1,1) NOT NULL,
	[ErrorDescription] [varchar](2000) NULL,
	[UserId] [int] NULL,
	[InsertDate] [datetime] NOT NULL,
	[TableAbbrv] [char](10) NULL,
	[TablePK] [varchar](50) NULL,
	[ProcedureName] [varchar](50) NULL,
	[ProcedureStage] [varchar](50) NULL,
	[Severity] [int] NULL,
	CONSTRAINT [PK_ErrorLogs] PRIMARY KEY CLUSTERED ([ErrorLogId] ASC)
	--TODO user id fk
)
