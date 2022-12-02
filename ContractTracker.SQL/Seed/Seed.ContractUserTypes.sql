PRINT 'Populating Contract User Types'

SET IDENTITY_INSERT [dbo].[ContractUserTypes] ON
GO

MERGE INTO [dbo].[ContractUserTypes] as Env
	USING ( VALUES
	 (1,'Contract Manager', 1)
	,(2,'Fiscal Contact Person', 1)
	) seed (ContractUserTypeId, ContractUserDescription, IsActive)
		ON Env.ContractUserTypeId = seed.ContractUserTypeId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (ContractUserTypeId, ContractUserDescription, IsActive )
	VALUES (ContractUserTypeId, ContractUserDescription, IsActive );
GO 

SET IDENTITY_INSERT [dbo].[ContractUserTypes] OFF
GO


 