CREATE TABLE [dbo].[ApplicationErrorLogs]
(
	ApplicationErrorLogId INT IDENTITY(1,1) NOT NULL,
	ClientUrl varchar(2000) NULL,
	ErrorMessage varchar(max) NULL,
	UserId INT NULL,
	UserName varchar(100) NULL,
	InsertDate Datetime NULL,
	CONSTRAINT [PK_ApplicationErrorLogs] PRIMARY KEY CLUSTERED ([ApplicationErrorLogId] ASC)
)
