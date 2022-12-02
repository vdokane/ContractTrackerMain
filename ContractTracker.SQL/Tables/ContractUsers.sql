CREATE TABLE [dbo].[ContractUsers]
(
	[ContractUserId] INT IDENTITY(1,1) NOT NULL,
	[ContractId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[ContractUserTypeId] INT NOT NULL,
	CreateByUserId int NOT NULL,
	CreatedDate datetime NOT NULL,
	CONSTRAINT [PK_ContractUsers] PRIMARY KEY CLUSTERED ([ContractUserId] ASC),
	CONSTRAINT [FK_ContractUsers_Contracts] FOREIGN KEY (ContractId) REFERENCES [ContractTypes] ([ContractTypeId]),
	CONSTRAINT [FK_ContractUsers_User] FOREIGN KEY (UserId) REFERENCES [Users] ([UserId]),
	CONSTRAINT [FK_ContractUsers_UserCreated] FOREIGN KEY (CreateByUserId) REFERENCES [Users] ([UserId]),
	CONSTRAINT [FK_ContractUsers_ContractUserType] FOREIGN KEY (ContractUserTypeId) REFERENCES [ContractUserTypes] (ContractUserTypeId)

)
