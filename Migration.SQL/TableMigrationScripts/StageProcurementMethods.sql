/* THIS IS MOOT, THIS TABLE IS LOADED WITH SEED SCRIPT
PRINT 'Running Migration for ProcurementMethods'


SET NOCOUNT ON;  
GO 

SET IDENTITY_INSERT [Migration].[ProcurementMethods] ON

MERGE INTO  [$DestinationDbName].[dbo].[ProcurementMethods] as procMethods
USING (SELECT Code, [Description], Exemption, ProcurementDocumentRequired, Active, SoleSourceApplicable
	FROM [$SourceServer].[$SourceDbName].[dbo].MethodOfProcurementCodes
) seedData (Code, [Description], Exemption, ProcurementDocumentRequired, Active, SoleSourceApplicable) 
ON procMethods.ProcurementMethodId = seedData.ProcurementMethodID

WHEN MATCHED THEN 
UPDATE 
	SET ProcurementMethodId = seedData.ProcurementMethodID, 

When not matched By Target Then 
INSERT ([CoeAccessLevelId], [CoeAccessLevelName])  VALUES ([CoeAccessLevelId], [CoeAccessLevelName])
When not matched By Source then DELETE;
GO

SET IDENTITY_INSERT  [User].[CoeAccessLevels] OFF;
GO
*/