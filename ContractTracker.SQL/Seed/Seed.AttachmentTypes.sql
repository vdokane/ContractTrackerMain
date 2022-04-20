PRINT 'Populating Attachment Types'

SET IDENTITY_INSERT [dbo].[AttachmentTypes] ON
GO


MERGE INTO [dbo].[AttachmentTypes] as Env
	USING ( VALUES
	(1,	'Original Contract', 1,	0)
	,(2,'Original Redacted Contract', 1,	0)
	,(4,'General Services Approval', 1,	1)
	,(5,'Amendment Contract', 1,	0)
	,(6,'Original Redacted Contract', 1,	0)
	,(7,'Procurement Document', 1,	0)
	,(8,'Procurement Redacted Document', 1,	0)
	,(9,'Amendment Redacted Contract', 1,	0)

	) seed (AttachmentTypeId, AttachmentTypeDescription, IsActive,OSCAOnly )
		ON Env.AttachmentTypeId = seed.AttachmentTypeId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (AttachmentTypeId, AttachmentTypeDescription, IsActive,OSCAOnly )
	VALUES (AttachmentTypeId, AttachmentTypeDescription, IsActive,OSCAOnly );
GO 

SET IDENTITY_INSERT [dbo].[AttachmentTypes] OFF
GO



 
 
 