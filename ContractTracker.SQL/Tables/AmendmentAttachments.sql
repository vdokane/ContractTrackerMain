CREATE TABLE [dbo].[AmendmentAttachments]
(
	[AmendmentAttachmentId] INT IDENTITY (1, 1) NOT NULL, 
	[AttachmentTypeId] INT NOT NULL,
	[Attachment] [varbinary](max) NOT NULL,
	[AttachmentFilename] [varchar](2000) NOT NULL,
	[InsertDate] DATETIME NOT NULL,
	[UserId] INT NOT NULL,
	
	[FACTSDocumentID] [int] NULL,
	[MarkedForDeletion] [bit] NULL,
	CONSTRAINT [PK_AmendmentAttachments] PRIMARY KEY CLUSTERED ([AmendmentAttachmentId] ASC),
	CONSTRAINT [FK_AmendmentAttachments_AttachmentTypes] FOREIGN KEY (AttachmentTypeId) REFERENCES [AttachmentTypes] (AttachmentTypeId)
)
