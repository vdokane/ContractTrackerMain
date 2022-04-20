CREATE TABLE [dbo].[AttachmentTypes]
(
	[AttachmentTypeId] INT IDENTITY (1, 1) NOT NULL, 
	[AttachmentTypeDescription] [varchar](50) NOT NULL,
	[IsActive] bit NULL,
	[OSCAOnly] [bit] NULL,
	CONSTRAINT [PK_AttachmentTypes] PRIMARY KEY CLUSTERED ([AttachmentTypeId] ASC)
)
