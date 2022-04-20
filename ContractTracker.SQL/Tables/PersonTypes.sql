CREATE TABLE [dbo].[PersonTypes]
(
	PersonTypeId [int] IDENTITY(1,1) NOT NULL,
	PersonTypeDescription [varchar](500) NOT NULL,
	IsActive BIT NOT NULL,
	CONSTRAINT [PK_PersonTypes] PRIMARY KEY CLUSTERED ([PersonTypeId] ASC)
)
