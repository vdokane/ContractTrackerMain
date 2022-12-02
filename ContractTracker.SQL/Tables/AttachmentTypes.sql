CREATE TABLE [dbo].[AttachmentTypes]
(
	[AttachmentTypeId] INT IDENTITY (1, 1) NOT NULL, 
	[AttachmentTypeDescription] [varchar](100) NOT NULL,
	[IsActive] BIT NOT NULL,
	[ForChangeRecordsOnly] BIT NOT NULL,
	[IsOscaOnly] BIT NOT NULL,
	[AllowMultiple] BIT NOT NULL,
	[IsOnlyPdfAllowed] [bit] NOT NULL,
	CONSTRAINT [PK_AttachmentTypes] PRIMARY KEY CLUSTERED ([AttachmentTypeId] ASC)
)
 