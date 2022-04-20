CREATE TABLE [dbo].[Users]
(
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleId] int NOT NULL,
	[UserLogInName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserEmail] [varchar](60) NOT NULL,
	[PositionTitle] [varchar](50) NULL,

	AddDate [datetime] NULL,
	EndDate [datetime] NULL,

	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	LastUpdateByUserId int NULL,
	LastUpdateDate [datetime] NULL,
	
	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC),
	CONSTRAINT [FK_User_UserRoles] FOREIGN KEY ([UserRoleId]) REFERENCES UserRoles ([UserRoleId])
	
)
