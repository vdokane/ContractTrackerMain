﻿CREATE TABLE [dbo].[Vendors]
(
	VendorId INT IDENTITY (1, 1) NOT NULL, 
	VendorType varchar(1) NULL,
	VendorNumber varchar(255) NULL,
	SequenceNumber varchar(255) NULL,
	
	
	[PurchasingNameLine1] [varchar](255) NULL,
	[PurchasingNameLine2] [varchar](255) NULL,
	[ShortName] [varchar](255) NULL,
	[PurchasingAddressLine1] [varchar](255) NULL,
	[PurchasingAddressLine2] [varchar](255) NULL,
	[PurchasingAddressLine3] [varchar](255) NULL,
	[PurchasingCity] [varchar](255) NULL,
	[PurchasingState] [varchar](255) NULL,
	[PurchasingZipCode] [varchar](255) NULL,
	[PurchasingCountry] [varchar](255) NULL,
	[RemittanceAddressLine1] [varchar](255) NULL,
	[RemittanceAddressLine2] [varchar](255) NULL,
	[RemittanceAddressLine3] [varchar](255) NULL,
	[RemittanceCity] [varchar](255) NULL,
	[RemittanceState] [varchar](255) NULL,
	[RemittanceZipCode] [varchar](255) NULL,
	[RemittanceCountry] [varchar](255) NULL,
	[MinorityCode] [varchar](255) NULL,
	[StatusCode] [varchar](255) NULL,
	[PhoneNumberAreaCode] [varchar](255) NULL,
	[PhoneNumberPrefix] [varchar](255) NULL,
	[PhoneNumberSuffix] [varchar](255) NULL,
	[DateLastUsed] [varchar](255) NULL,
	[VendorEnterIndicator] [varchar](255) NULL,
	[W9Indicator] [varchar](255) NULL,
	[InactiveReasonCode] [varchar](255) NULL,
	[PersonalIdentificationNumber] [varchar](255) NULL,
	[W9UpdateDate] [varchar](255) NULL,
	[ConfidentialVendorIndicator] [varchar](255) NULL,
	[TaxLevyIndicator] [varchar](255) NULL,
	[W9Name] [varchar](255) NULL,
	[PayeeIndicator] [varchar](255) NULL,
	[ForeignIndicator] [varchar](255) NULL,
	[EFTAuthorizationIndicator] [varchar](255) NULL,
	[AddUserIdentifier] [varchar](255) NULL,
	[AddDate] [varchar](255) NULL,
	[AddOperatingLevelOrganization] [varchar](255) NULL,
	[UpdateOperatingLevelOrganization] [varchar](255) NULL,
	[UpdateUserIdentifier] [varchar](255) NULL,
	[UpdateDate] [datetime] NULL

	[VendorIDLegacy] INT NULL,
	--todo better audit fields

	CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorId] ASC)
)
