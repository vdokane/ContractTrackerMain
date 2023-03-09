CREATE TABLE [dbo].[ContractAmendmentAttachments]
(
	[ContractAmendmentAttachmentId] INT IDENTITY (1, 1) NOT NULL, 
	[AmendmentId] INT NOT NULL,
	[RedactedForAmendmentAttachmentId] INT NOT NULL,
	[AttachmentTypeId] INT NOT NULL,
	[Attachment] [varbinary](max) NOT NULL,
	[AttachmentFilename] [varchar](2000) NOT NULL,
	[CreateDate] DATETIME NOT NULL,
	[CreateByUserId] INT NOT NULL,
	[FACTSDocumentID] [int] NULL,
	[MarkedForDeletion] [bit] NULL,
	CONSTRAINT [PK_ContractAmendmentAttachments] PRIMARY KEY CLUSTERED ([ContractAmendmentAttachmentId] ASC),
	CONSTRAINT [FK_ContractAmendmentAttachments_Amendments] FOREIGN KEY (AmendmentId) REFERENCES [ContractAmendments] ([ContractAmendmentId]),
	CONSTRAINT [FK_ContractAmendmentAttachments_AmendmentAttachments] FOREIGN KEY  (RedactedForAmendmentAttachmentId) REFERENCES [ContractAmendmentAttachments] (ContractAmendmentAttachmentId), --self referencing key to establish changed contract document to redacted document
	CONSTRAINT [FK_ContractAmendmentAttachments_Users] FOREIGN KEY (CreateByUserId) REFERENCES [Users] (UserId),
	CONSTRAINT [FK_ContractAmendmentAttachments_AttachmentTypes] FOREIGN KEY (AttachmentTypeId) REFERENCES [AttachmentTypes] (AttachmentTypeId)
)

 
