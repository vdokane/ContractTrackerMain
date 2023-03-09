PRINT 'Populating UserRoles'

SET IDENTITY_INSERT [dbo].[UserRoles] ON
GO


MERGE INTO [dbo].[UserRoles] as usrRls
	USING ( VALUES
			(1, 'Admin'),
			(2, 'User'),
			(3, 'ReadOnly')
		  ) seed (UserRoleId,UserRoleDescription)
	ON usrRls.UserRoleId = seed.UserRoleId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (UserRoleId,UserRoleDescription)
	VALUES (UserRoleId,UserRoleDescription);
GO 

SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO