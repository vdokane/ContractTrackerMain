CREATE TABLE [dbo].[ContractTypes]
(
	[ContractTypeId] INT IDENTITY (1, 1) NOT NULL, 
	[ContractTypeDescription] VARCHAR(100) NOT NULL,
	[FactsCode] VARCHAR(2) NOT NULL,
	[EndDate] DATETIME NULL,
	CONSTRAINT [PK_ContractTypes] PRIMARY KEY CLUSTERED ([ContractTypeId] ASC)
)

