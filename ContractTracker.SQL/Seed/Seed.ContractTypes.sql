PRINT 'Populating ContractTypes'

SET IDENTITY_INSERT [dbo].[ContractTypes] ON
GO


MERGE INTO [dbo].[ContractTypes] as Env
	USING ( VALUES
	 (1,'Grant Award Agreements','GA',NULL)
	,(2,'Grant Disbursement Agreement','GD',NULL)
	,(3,'Master Agreement','MA',NULL)
	,(4,'Memorandum of Agreement/Understanding or Interagency Agreement','IA',NULL)
	,(5,'Multi-Agency Participation Agreement','MP',NULL)
	,(6,'No Ceiling/Rate Agreement','NO',NULL)
	,(7,'Purchase Order','PO',NULL)
	,(8,'Revenue Agreement','RA',NULL)
	,(9,'Standard Two Party Agreement by Statute','SC',NULL)
	,(10,'Three or More Party Agreement','TP',NULL)
	,(11,'Settlement Agreements','SA',NULL)
	
	) seed ([ContractTypeId], [ContractTypeDescription],[FactsCode],[EndDate])
		ON Env.[ContractTypeId] = seed.[ContractTypeId]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([ContractTypeId], [ContractTypeDescription],[FactsCode],[EndDate])
	VALUES ([ContractTypeId], [ContractTypeDescription],[FactsCode],[EndDate]);
GO 

SET IDENTITY_INSERT [dbo].[ContractTypes] OFF
GO


/* TODO environments at some point

SET IDENTITY_INSERT [dbo].[ContractTypes] ON
GO

DECLARE @Local uniqueidentifier; SET @Local='0BB3D7A8-4BAC-40E2-BE54-BA7878D6C4E9'
DECLARE @Staging uniqueidentifier; SET @Staging='C6638192-C3AC-41BD-983F-A2F840940368'
DECLARE @Production uniqueidentifier; SET @Production='87CAA300-8E2E-4C67-86CB-A5A8167F3701'

MERGE INTO [dbo].[Environments] as Env
	USING ( VALUES
    (1,'Development',@Local)
   ,(2,'Staging',@Staging)
	,(3,'Production',@Production)
	
	) seed ([EnvironmentId], [EnvironmentName],[EnvironmentGuid])
		ON Env.[EnvironmentId] = seed.[EnvironmentId]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([EnvironmentId], [EnvironmentName],[EnvironmentGuid])
	VALUES ([EnvironmentId], [EnvironmentName],[EnvironmentGuid]);
GO 

SET IDENTITY_INSERT [dbo].[Environments] OFF
GO
*/
	
	