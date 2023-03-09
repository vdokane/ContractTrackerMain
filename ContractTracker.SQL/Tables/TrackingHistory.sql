CREATE TABLE [dbo].[TrackingHistory]
(
	[TrackingHistoryId] INT IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	TrackingStepId [int] NOT NULL,
	ContractAmmendmentId INT NULL,
	[Message] [varchar](2000) NULL,
	[UserID] [int] NOT NULL,
	[InsertDate] Date NOT NULL,
	CONSTRAINT [PK_TrackingHistory] PRIMARY KEY CLUSTERED ([TrackingHistoryId] ASC),
	CONSTRAINT [FK_TrackingHistory_Contracts] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]),
	CONSTRAINT [FK_TrackingHistory_TrackingSteps] FOREIGN KEY ([TrackingStepId]) REFERENCES TrackingSteps (TrackingStepId),
	CONSTRAINT [FK_TrackingHistory_ContractAmendments] FOREIGN KEY (ContractAmmendmentId) REFERENCES ContractAmendments (ContractAmendmentId)
	--TODO users

)
