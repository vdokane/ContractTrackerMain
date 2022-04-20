PRINT 'Populating Person Types'

SET IDENTITY_INSERT [dbo].[PersonTypes] ON
GO


MERGE INTO [dbo].PersonTypes as Env
	USING ( VALUES
	(1,	'Contract Manager', 1)
	,(2,	'Fiscal Contact Person', 1)
	) seed (PersonTypeId, PersonTypeDescription, IsActive)
		ON Env.PersonTypeId = seed.PersonTypeId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (PersonTypeId, PersonTypeDescription, IsActive )
	VALUES (PersonTypeId, PersonTypeDescription, IsActive );
GO 

SET IDENTITY_INSERT [dbo].PersonTypes OFF
GO


 