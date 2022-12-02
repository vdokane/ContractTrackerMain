CREATE TABLE [dbo].[AmendmentAttachments]
(
	[AmendmentAttachmentId] INT IDENTITY (1, 1) NOT NULL, 
	[AmendmentId] INT NOT NULL,
	[RedactedForAmendmentAttachmentId] INT NOT NULL,
	[AttachmentTypeId] INT NOT NULL,
	[Attachment] [varbinary](max) NOT NULL,
	[AttachmentFilename] [varchar](2000) NOT NULL,
	[CreateDate] DATETIME NOT NULL,
	[CreateByUserId] INT NOT NULL,
	[FACTSDocumentID] [int] NULL,
	[MarkedForDeletion] [bit] NULL,
	CONSTRAINT [PK_AmendmentAttachments] PRIMARY KEY CLUSTERED ([AmendmentAttachmentId] ASC),
	CONSTRAINT [FK_AmendmentAttachments_Amendments] FOREIGN KEY (AmendmentId) REFERENCES [Amendments] ([AmendmentId]),
	CONSTRAINT [FK_AmendmentAttachments_AmendmentAttachments] FOREIGN KEY  (RedactedForAmendmentAttachmentId) REFERENCES [AmendmentAttachments] (AmendmentAttachmentId), --self referencing key to establish changed contract document to redacted document
	CONSTRAINT [FK_AmendmentAttachments_Users] FOREIGN KEY (CreateByUserId) REFERENCES [Users] (UserId),
	CONSTRAINT [FK_AmendmentAttachments_AttachmentTypes] FOREIGN KEY (AttachmentTypeId) REFERENCES [AttachmentTypes] (AttachmentTypeId)
)

 
