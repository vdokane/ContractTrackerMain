CREATE TABLE [dbo].[UserRoles]
(
	UserRoleId INT IDENTITY (1, 1) NOT NULL, 
	UserRoleDescription varchar(50) NOT NULL,
	CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserRoleId] ASC)
)
