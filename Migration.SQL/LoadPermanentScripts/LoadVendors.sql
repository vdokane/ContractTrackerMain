﻿ PRINT 'LOADING Vendors!'


SET NOCOUNT ON;  
GO 


SET IDENTITY_INSERT [dbo].[Vendors] ON;
GO

MERGE INTO  [dbo].[Vendors] as destinationTable
USING (
		SELECT [VendorMigrationId]
                ,[VendorType]
              ,[VendorNumber]
              ,[SequenceNumber]
              ,[PurchasingNameLine1]
              ,[PurchasingNameLine2]
              ,[ShortName]
              ,[PurchasingAddressLine1]
              ,[PurchasingAddressLine2]
              ,[PurchasingAddressLine3]
              ,[PurchasingCity]
              ,[PurchasingState]
              ,[PurchasingZipCode]
              ,[PurchasingCountry]
              ,[RemittanceAddressLine1]
              ,[RemittanceAddressLine2]
              ,[RemittanceAddressLine3]
              ,[RemittanceCity]
              ,[RemittanceState]
              ,[RemittanceZipCode]
              ,[RemittanceCountry]
              ,[MinorityCode]
              ,[StatusCode]
              ,[PhoneNumberAreaCode]
              ,[PhoneNumberPrefix]
              ,[PhoneNumberSuffix]
              ,[DateLastUsed]
              ,[VendorEnterIndicator]
              ,[AddUserIdentifier]
              ,[AddDate]
              ,[AddOperatingLevelOrganization]
              ,[UpdateUserIdentifier]
              ,[UpdateDate]
              ,[UpdateOperatingLevelOrganization]
              ,[W9Indicator]
              ,[InactiveReasonCode]
              ,[PersonalIdentificationNumber]
              ,[W9UpdateDate]
              ,[ConfidentialVendorIndicator]
              ,[TaxLevyIndicator]
              ,[W9Name]
              ,[PayeeIndicator]
              ,[ForeignIndicator]
              ,[EFTAuthorizationIndicator]
              
              ,[VendorId] --Legacy Vendor ID
              --TODO any new audit fields? I need to save UserId and timestamp!!!!

		FROM [Migration].VendorMigration
        ) sourceTable
        (      [VendorMigrationId]
              ,[VendorType]
              ,[VendorNumber]
              ,[SequenceNumber]
              ,[PurchasingNameLine1]
              ,[PurchasingNameLine2]
              ,[ShortName]
              ,[PurchasingAddressLine1]
              ,[PurchasingAddressLine2]
              ,[PurchasingAddressLine3]
              ,[PurchasingCity]
              ,[PurchasingState]
              ,[PurchasingZipCode]
              ,[PurchasingCountry]
              ,[RemittanceAddressLine1]
              ,[RemittanceAddressLine2]
              ,[RemittanceAddressLine3]
              ,[RemittanceCity]
              ,[RemittanceState]
              ,[RemittanceZipCode]
              ,[RemittanceCountry]
              ,[MinorityCode]
              ,[StatusCode]
              ,[PhoneNumberAreaCode]
              ,[PhoneNumberPrefix]
              ,[PhoneNumberSuffix]
              ,[DateLastUsed]
              ,[VendorEnterIndicator]
              ,[AddUserIdentifier]
              ,[AddDate]
              ,[AddOperatingLevelOrganization]
              ,[UpdateUserIdentifier]
              ,[UpdateDate]
              ,[UpdateOperatingLevelOrganization]
              ,[W9Indicator]
              ,[InactiveReasonCode]
              ,[PersonalIdentificationNumber]
              ,[W9UpdateDate]
              ,[ConfidentialVendorIndicator]
              ,[TaxLevyIndicator]
              ,[W9Name]
              ,[PayeeIndicator]
              ,[ForeignIndicator]
              ,[EFTAuthorizationIndicator]
              ,[VendorID]
            ) 
ON destinationTable.VendorId = sourceTable.[VendorMigrationId]  

WHEN MATCHED THEN 
UPDATE 
	SET        [VendorType] = sourceTable.[VendorType]
              ,[VendorNumber] = sourceTable.[VendorNumber]
              ,[SequenceNumber] = sourceTable.[SequenceNumber]
              ,[PurchasingNameLine1] = sourceTable.[PurchasingNameLine1]
              ,[PurchasingNameLine2] = sourceTable.[PurchasingNameLine2]
              ,[ShortName] = sourceTable.[ShortName]
              ,[PurchasingAddressLine1] = sourceTable.[PurchasingAddressLine1]
              ,[PurchasingAddressLine2] = sourceTable.[PurchasingAddressLine2]
              ,[PurchasingAddressLine3]  = sourceTable.[PurchasingAddressLine3]
              ,[PurchasingCity] = sourceTable.[PurchasingCity]
              ,[PurchasingState] = sourceTable.[PurchasingState]
              ,[PurchasingZipCode] = sourceTable.[PurchasingZipCode]
              ,[PurchasingCountry] = sourceTable.[PurchasingCountry]
              ,[RemittanceAddressLine1] = sourceTable.[RemittanceAddressLine1]
              ,[RemittanceAddressLine2] = sourceTable.[RemittanceAddressLine2]
              ,[RemittanceAddressLine3] = sourceTable.[RemittanceAddressLine3]
              ,[RemittanceCity] = sourceTable.[RemittanceCity]
              ,[RemittanceState] = sourceTable.[RemittanceState]
              ,[RemittanceZipCode] = sourceTable.[RemittanceZipCode]
              ,[RemittanceCountry] = sourceTable.[RemittanceCountry]
              ,[MinorityCode] = sourceTable.[MinorityCode]
              ,[StatusCode] = sourceTable.[StatusCode]
              ,[PhoneNumberAreaCode] = sourceTable.[PhoneNumberAreaCode]
              ,[PhoneNumberPrefix] = sourceTable.[PhoneNumberPrefix]
              ,[PhoneNumberSuffix] = sourceTable.[PhoneNumberSuffix]
              ,[DateLastUsed] = sourceTable.[DateLastUsed]
              ,[VendorEnterIndicator] = sourceTable.[VendorEnterIndicator]
              ,[AddUserIdentifier] = sourceTable.[AddUserIdentifier]
              ,[AddDate] = sourceTable.[AddDate]
              ,[AddOperatingLevelOrganization] = sourceTable.[AddOperatingLevelOrganization]
              ,[UpdateUserIdentifier] = sourceTable.[UpdateUserIdentifier]
              ,[UpdateDate] = sourceTable.[UpdateDate]
              ,[UpdateOperatingLevelOrganization] = sourceTable.[UpdateDate]
              ,[W9Indicator] = sourceTable.[W9Indicator]
              ,[InactiveReasonCode] = sourceTable.[InactiveReasonCode]
              ,[PersonalIdentificationNumber] = sourceTable.[PersonalIdentificationNumber]
              ,[W9UpdateDate] = sourceTable.[W9UpdateDate]
              ,[ConfidentialVendorIndicator] = sourceTable.[ConfidentialVendorIndicator]
              ,[TaxLevyIndicator] = sourceTable.[TaxLevyIndicator]
              ,[W9Name] = sourceTable.[W9Name]
              ,[PayeeIndicator] = sourceTable.[PayeeIndicator]
              ,[ForeignIndicator] = sourceTable.[ForeignIndicator]
              ,[EFTAuthorizationIndicator] = sourceTable.[EFTAuthorizationIndicator]
              ,VendorIDLegacy = sourceTable.VendorID

WHEN NOT MATCHED BY TARGET THEN
INSERT
(
               [VendorId]
              ,[VendorType]
              ,[VendorNumber]
              ,[SequenceNumber]
              ,[PurchasingNameLine1]
              ,[PurchasingNameLine2]
              ,[ShortName]
              ,[PurchasingAddressLine1]
              ,[PurchasingAddressLine2]
              ,[PurchasingAddressLine3]
              ,[PurchasingCity]
              ,[PurchasingState]
              ,[PurchasingZipCode]
              ,[PurchasingCountry]
              ,[RemittanceAddressLine1]
              ,[RemittanceAddressLine2]
              ,[RemittanceAddressLine3]
              ,[RemittanceCity]
              ,[RemittanceState]
              ,[RemittanceZipCode]
              ,[RemittanceCountry]
              ,[MinorityCode]
              ,[StatusCode]
              ,[PhoneNumberAreaCode]
              ,[PhoneNumberPrefix]
              ,[PhoneNumberSuffix]
              ,[DateLastUsed]
              ,[VendorEnterIndicator]
              ,[AddUserIdentifier]
              ,[AddDate]
              ,[AddOperatingLevelOrganization]
              ,[UpdateUserIdentifier]
              ,[UpdateDate]
              ,[UpdateOperatingLevelOrganization]
              ,[W9Indicator]
              ,[InactiveReasonCode]
              ,[PersonalIdentificationNumber]
              ,[W9UpdateDate]
              ,[ConfidentialVendorIndicator]
              ,[TaxLevyIndicator]
              ,[W9Name]
              ,[PayeeIndicator]
              ,[ForeignIndicator]
              ,[EFTAuthorizationIndicator]
              ,[VendorIDLegacy]
)
VALUES
(
               [VendorMigrationId]
              ,[VendorType]
              ,[VendorNumber]
              ,[SequenceNumber]
              ,[PurchasingNameLine1]
              ,[PurchasingNameLine2]
              ,[ShortName]
              ,[PurchasingAddressLine1]
              ,[PurchasingAddressLine2]
              ,[PurchasingAddressLine3]
              ,[PurchasingCity]
              ,[PurchasingState]
              ,[PurchasingZipCode]
              ,[PurchasingCountry]
              ,[RemittanceAddressLine1]
              ,[RemittanceAddressLine2]
              ,[RemittanceAddressLine3]
              ,[RemittanceCity]
              ,[RemittanceState]
              ,[RemittanceZipCode]
              ,[RemittanceCountry]
              ,[MinorityCode]
              ,[StatusCode]
              ,[PhoneNumberAreaCode]
              ,[PhoneNumberPrefix]
              ,[PhoneNumberSuffix]
              ,[DateLastUsed]
              ,[VendorEnterIndicator]
              ,[AddUserIdentifier]
              ,[AddDate]
              ,[AddOperatingLevelOrganization]
              ,[UpdateUserIdentifier]
              ,[UpdateDate]
              ,[UpdateOperatingLevelOrganization]
              ,[W9Indicator]
              ,[InactiveReasonCode]
              ,[PersonalIdentificationNumber]
              ,[W9UpdateDate]
              ,[ConfidentialVendorIndicator]
              ,[TaxLevyIndicator]
              ,[W9Name]
              ,[PayeeIndicator]
              ,[ForeignIndicator]
              ,[EFTAuthorizationIndicator]
              ,[VendorID]
);
GO
--When not matched By Source then DELETE;
--GO

SET IDENTITY_INSERT [dbo].[Vendors] OFF;
GO


SET NOCOUNT OFF;  
GO 

PRINT 'COMPLETE Vendors!'