CREATE TABLE [dbo].[ContractAmendments]
(
	[ContractAmendmentId] INT IDENTITY (1, 1) NOT NULL, 
	[ContractId] INT  NOT NULL, 
	[ChangeType] [char](1) NOT NULL,
	[AmendmentAmount] [numeric](13, 2) NOT NULL,
	[AmendmentReference] [varchar](8) NOT NULL,
	[AmendmentEffectiveDate] [datetime] NOT NULL,
	[ChangeDateExecuted] [datetime] NOT NULL,
	[NewEndingDate] [datetime] NULL,
	[ChangeDescription] [varchar](60) NOT NULL,
	[Action] [varchar](200) NULL,
	
	[MarkedForDeletion] [bit] NULL,

	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	LastUpdateByUserId int NULL,
	LastUpdateDate [datetime] NULL,
	
	[ContractAppChangeId] [int] NULL,

	CONSTRAINT [PK_ContractAmendments] PRIMARY KEY CLUSTERED ([ContractAmendmentId] ASC),
	CONSTRAINT [FK_ContractAmendments_Contracts] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]),

	CONSTRAINT [FK_ContractAmendments_InsertUser] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([UserId]),
	CONSTRAINT [FK_ContractAmendments_UpdateUser] FOREIGN KEY ([LastUpdateByUserId]) REFERENCES [Users] ([UserId])

	
	 
	 
)

