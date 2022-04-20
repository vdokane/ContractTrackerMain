CREATE TABLE [dbo].[Amendments]
(
	[AmendmentId] INT IDENTITY (1, 1) NOT NULL, 
	[ContractId] INT  NOT NULL, 
	[ChangeType] [char](1) NOT NULL,
	[AmendmentAmount] [numeric](13, 2) NOT NULL,
	[AmendmentReference] [varchar](8) NOT NULL,
	[AmendmentEffectiveDate] [datetime] NOT NULL,
	[ChangeDateExecuted] [datetime] NOT NULL,
	[NewEndingDate] [datetime] NULL,
	[ChangeDescription] [varchar](60) NOT NULL,
	[Action] [varchar](200) NULL,
	
	[AmendedAttachmentId] [int] NULL,
	[RedactedAttachmentId] [int] NULL,
	[MarkedForDeletion] [bit] NULL,

	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	LastUpdateByUserId int NULL,
	LastUpdateDate [datetime] NULL,
	
	[ContractAppChangeId] [int] NULL,
	

	CONSTRAINT [PK_ContractChanges] PRIMARY KEY CLUSTERED ([AmendmentId] ASC),
	CONSTRAINT [FK_ContractChanges_Contracts] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]),
	CONSTRAINT [FK_ContractChanges_AttachmentAmendment] FOREIGN KEY (AmendedAttachmentId) REFERENCES [AmendmentAttachments] ([AmendmentAttachmentId]),
	CONSTRAINT [FK_ContractChanges_AttachmentRedacted]  FOREIGN KEY (RedactedAttachmentId) REFERENCES [AmendmentAttachments] ([AmendmentAttachmentId])
	--TODO users
	 
	 
)

