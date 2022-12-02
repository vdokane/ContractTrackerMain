PRINT 'Populating Attachment Types'

SET IDENTITY_INSERT [dbo].[AttachmentTypes] ON
GO

DECLARE @AllowMultiple bit; SET @AllowMultiple=1
DECLARE @IsOnlyPdfAllowed bit; SET @IsOnlyPdfAllowed=1

MERGE INTO [dbo].[AttachmentTypes] as Env
	USING ( VALUES
	(1,	'Original Contract', 1,	0,0,0, @IsOnlyPdfAllowed)
	,(2,'Original Redacted Contract', 1,0,0,0, @IsOnlyPdfAllowed)
	,(4,'General Services Approval', 1,	1,0,0,0)
	,(5,'Amendment Contract', 1,1,0,0, @IsOnlyPdfAllowed)
	,(6,'Original Redacted Contract', 1,0,0,0,0)
	,(7,'Procurement Document', 1,0,0,0,0)
	,(8,'Procurement Redacted Document', 1,	0,0,0,0)
	,(9,'Amendment Redacted Contract', 1,1,0,0, @IsOnlyPdfAllowed)
	,(10,'Approval Memo',	1,0,0, @AllowMultiple,0)
	,(11,'Additional Procurement Document-Vendor Response',1,	0,0, @AllowMultiple,0)
	,(12,'Additional Procurement Document-Evaluation Summary',1,	0,0, @AllowMultiple,0)
	,(13,'Additional Procurement Document-Award Justification',1,	0,0, @AllowMultiple,0)
	,(14,'Additional Contract Document-Attachments', 1,	0,0 ,@AllowMultiple,0)
	,(15,'Additional Contract Document-Exhibits', 1,	0,0 ,@AllowMultiple,0)
	,(16,'Additional Contract Document-E-Verify Documents', 1,	0,0 ,@AllowMultiple,0)
	,(17,'Additional Contract Document-SSN Check Documents', 1,	0,0 ,@AllowMultiple,0)
	,(18,'Additional Contract Document-Correspondence', 1,	0,0 ,@AllowMultiple,0)
	,(19,'Additional Contract Change Document-Attachments', 1,	1,0 ,@AllowMultiple,0)
	,(20,'Additional Contract Change Document-Exhibits', 1,	1,0,@AllowMultiple,0)
	,(21,'Additional Contract Change Documents-Correspondence', 1,	1,0,@AllowMultiple,0)
	,(22,'Additional Settlement Agreement Document-Invoices',1,	0,0,@AllowMultiple,0)
	,(23,'Additional Settlement Agreement Document-Supporting Documents',1,	0,0,@AllowMultiple,0)
	,(24,'Additional Settlement Agreement Document-Original Contract',1,	0,0,@AllowMultiple,0)
	,(25,'Additional Settlement Agreement Document-Replacement Contract',1,	0,0,@AllowMultiple,0)
	,(26,'Routing Form',1,	0,0,0,0)
	,(27,'Approval Documents',1,0,0,@AllowMultiple,0)
	,(28,'Misc.',1,0,0,@AllowMultiple,0)

	) seed (AttachmentTypeId, AttachmentTypeDescription, IsActive,[ForChangeRecordsOnly],[IsOscaOnly],[AllowMultiple],[IsOnlyPdfAllowed] )
		ON Env.AttachmentTypeId = seed.AttachmentTypeId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (AttachmentTypeId, AttachmentTypeDescription, IsActive,[ForChangeRecordsOnly],[IsOscaOnly],[AllowMultiple],[IsOnlyPdfAllowed])
	VALUES (AttachmentTypeId, AttachmentTypeDescription, IsActive,[ForChangeRecordsOnly],[IsOscaOnly],[AllowMultiple],[IsOnlyPdfAllowed]);
GO 

SET IDENTITY_INSERT [dbo].[AttachmentTypes] OFF
GO



 
 
 