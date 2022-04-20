CREATE TABLE [dbo].[Contracts]
(
	ContractId INT IDENTITY (1, 1) NOT NULL, 
	ContractNumber varchar(11) NULL,
	ContractTypeId INT NULL,
	VendorId INT NULL,
	ContractApplicationId INT NULL,
	FLAIRContractId varchar(10) NULL, --What was this used for? This is the contract number with the first two bytes missing. Why?
	ProcurementMethodId INT NULL,
	--RoutingStatusId INT NULL,
	/* Document fields that need to be transfered over
		[DocumentID] [int] IDENTITY(1,1) NOT NULL,
	[CostCenterId] [int] NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[DocumentStatusTypeID] [int] NOT NULL,
	[UnitID] [int] NULL,
*/


	--TypeCode] [varchar](2) NULL, --?
	StartDate datetime NULL,
	ExecuteDate datetime NULL,
	EndDate datetime NULL,
	Amount money NULL,
	HourlyRate numeric(18, 4) NULL,
	[Recurring] [bit] NULL,
	[ServiceType] [varchar](60) NULL,
	[AuthorizedADPayment] [bit] NULL,
	[StateTermContractIdentifier] [varchar](50) NULL,
	[ExemptionExplanation] [varchar](1000) NULL,
	[ContractStatutoryAuthority] [varchar](60) NULL,
	[GeneralComments] [varchar](1000) NULL,
	[InternalComments] [varchar](2000) NULL,
	[ContractInvolveFinancialAid] [bit] NULL,
	[RecipientTypeCode] [char](1) NULL,
	[IndirectCostInd] [bit] NULL,
	[AdministrativeCostPercentage] [char](6) NULL,
	[ProvidePeriodicIncrease] [bit] NULL,
	[PeriodicIncreasePercentage] [numeric](5, 2) NULL,
	[BusinessCaseStudyDone] [bit] NULL,
	[BusinessCaseDate] [datetime] NULL,
	[LegalChallengesProcurement] [bit] NULL,
	[LegalChallengeDescription] [varchar](1000) NULL,
	[PreviouslyDoneByTheState] [bit] NULL,
	[ConsideredBackToTheState] [bit] NULL,
	[CapitalImprovementsOnStateProperty] [bit] NULL,
	[CapitalImprovementDescription] [varchar](1000) NULL,
	[ValueCapitalImprovements] [numeric](13, 2) NULL,
	[ValueUnamortizedCapitalImprovements] [numeric](13, 2) NULL,
	[CSFA] [varchar](6) NULL,
	[CFDA] [varchar](6) NULL,
	[ContractStatus] [char](1) NULL,
	[RejectionMessage] [varchar](2000) NULL,
	[SweepStatus] [char](1) NULL,
	[ExistingContract] [bit] NULL,
	[ExportDate] [datetime] NULL,
	[MarkedForDeletion] [bit] NULL,
	[Confidential] [bit] NULL,

	--//hm? If we have audits do we need this?
	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	LastUpdateByUserId int NULL,
	LastUpdateDate [datetime] NULL,

	ContractAppContractId INT NULL,
	
	CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED ([ContractId] ASC),
	CONSTRAINT [FK_Contracts_ContractTypes] FOREIGN KEY ([ContractTypeId]) REFERENCES [ContractTypes] ([ContractTypeId]),
	CONSTRAINT [FK_Contracts_ProcurementMethods] FOREIGN KEY ([ProcurementMethodId]) REFERENCES [ProcurementMethods] ([ProcurementMethodId]),
	CONSTRAINT [FK_Contracts_Vendors] FOREIGN KEY (VendorId) REFERENCES [Vendors] (VendorId)
	--TODO users
	  
)

/*
	 
	 

	
	[Agency] [varchar](50) NULL,
	
	[Contract
	
	[DocumentId] [int] NULL,
	[FACTSResubmittedDate] [datetime] NULL,
	[VendorNumber] [varchar](255) NULL,
	[VendorNumberSequence] [varchar](255) NULL,

) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[Contracts] ADD  NULL
ALTER TABLE [dbo].[Contracts] ADD [ ] [int] NULL
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]

GO

*/