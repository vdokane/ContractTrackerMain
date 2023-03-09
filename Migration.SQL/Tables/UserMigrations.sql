CREATE TABLE [Migration].[Users]
(
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogInName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Start] [datetime] NULL,
	[Stop] [datetime] NULL,
	[TimeStamp] [datetime] NOT NULL,
	[PositionTitle] [varchar](50) NULL,
	[UserEmail] [varchar](60) NOT NULL,
	[UserRoleID] [int] NULL,
	[OfficeTelephone] [varchar](20) NULL,
	[ContactLKID] [int] NULL,
	[UserRoleDescription] varchar(50) NULL,
	[NewUserRoleId] INT NULL
)
