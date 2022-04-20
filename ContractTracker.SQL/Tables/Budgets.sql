CREATE TABLE [dbo].[Budgets]
(
	BudgetId INT IDENTITY(1,1) NOT NULL,
	ContractId INT NOT NULL,
	FlairCodeId INT NULL,

	--//Are these going to be needed? TODO
	[OrgCode] [varchar](11) NULL,
	[EO] [varchar](3) NULL,
	[Category] [varchar](10) NULL,
	
	
	[AgencyAmendmentReference] [varchar](8) NULL,
	[BudgetaryAmount] [numeric](13, 2) NOT NULL,
	[BudgetaryAmountType] [char](2) NOT NULL,
	[BudgetaryAmountAccountCode] [varchar](29) NULL,
	[OtherCostAccumulater] [varchar](200) NULL,
	[FiscalYearEffectiveDate] [datetime] NULL,
	[EffectiveBeginDate] [datetime] NULL,
	[EffectiveEndDate] [datetime] NULL,
	[BudgetaryRate] [numeric](13, 2) NULL,
	[MarkedForDeletion] [bit] NULL,

	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	LastUpdateByUserId int NULL,
	LastUpdateDate [datetime] NULL,

	ContractAppBudgetId INT NULL,
	ExportDate DATETIME NULL, --do we care?? TODO confirm

	CONSTRAINT [PK_Budgets] PRIMARY KEY CLUSTERED ([BudgetId] ASC),
	CONSTRAINT [FK_Budget_Contracts] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]),
	CONSTRAINT [FK_Budget_FlairCodes] FOREIGN KEY (FlairCodeId) REFERENCES FlairCodes (FlairCodeId),
	--TODO users
)
