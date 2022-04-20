CREATE TABLE [dbo].[Deliverables]
(
	[DeliverableId] INT IDENTITY (1, 1) NOT NULL, 
	[ContractId] INT NOT NULL,
	[MethodOfPaymentId] INT NULL, --should this be not null?

	[MajorDeliverable] [varchar](1000) NULL,
	[DeliverablePrices] [numeric](13, 2) NULL,
	[NonPriceJustification] [int] NULL,
	[PerformanceMatrix] [varchar](1000) NULL,
	[FinancialConsequences] [varchar](1000) NULL,
	[DocumentationPageReference] [varchar](200) NULL,
	[CommodityCode] [varchar](10) NULL,
	[MarkedForDeletion] [bit] NULL,
	[Archive] [bit] NULL,

		--//hm? If we have audits do we need this?
	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	LastUpdateByUserId int NULL,
	LastUpdateDate [datetime] NULL,

	[ContractAppDeliverableId] INT NULL,

	
	CONSTRAINT [PK_Deliverables] PRIMARY KEY CLUSTERED ([DeliverableId] ASC),
	CONSTRAINT [FK_ContractDeliverables_Contracts] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]),
	CONSTRAINT [FK_ContractDeliverables_MethodOfPayments] FOREIGN KEY ([MethodOfPaymentId]) REFERENCES MethodOfPayments ([MethodOfPaymentId]),
	--TODO users
)
