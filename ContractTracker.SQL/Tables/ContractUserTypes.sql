CREATE TABLE [dbo].[ContractUserTypes]
(
	ContractUserTypeId [int] IDENTITY(1,1) NOT NULL,
	ContractUserDescription [varchar](500) NOT NULL,
	IsActive BIT NOT NULL,
	CONSTRAINT [PK_ContractUserTypes] PRIMARY KEY CLUSTERED ([ContractUserTypeId] ASC)
)
