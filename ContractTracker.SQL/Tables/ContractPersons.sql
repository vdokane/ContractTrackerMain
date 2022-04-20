CREATE TABLE [dbo].[ContractPersons]
(
	[ContractPersonId] INT IDENTITY(1,1) NOT NULL,
	[ContractId] INT NOT NULL,
	[PersonId] INT NOT NULL,
	[PersonTypeId] INT NOT NULL,
	CreatedByUserId int NOT NULL,
	CreatedDate datetime NOT NULL,
	CONSTRAINT [PK_ContractPersons] PRIMARY KEY CLUSTERED ([ContractPersonId] ASC),
	CONSTRAINT [FK_ContractPersons_Contracts] FOREIGN KEY ([ContractId]) REFERENCES [ContractTypes] ([ContractTypeId]),
	CONSTRAINT [FK_ContractPersons_Person] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([PersonId]),
	CONSTRAINT [FK_ContractPersons_PersonType] FOREIGN KEY (PersonTypeId) REFERENCES [PersonTypes] (PersonTypeId)

)
