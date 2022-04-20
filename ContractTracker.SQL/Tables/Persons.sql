CREATE TABLE [dbo].[Persons]
(
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NULL,
	[PersonName] [varchar](100) NOT NULL,
	[PersonEmail] [varchar](50) NOT NULL,
	[PersonPhoneNumber] [varchar](20) NOT NULL,
	
	[Active] [bit] NOT NULL,
	[ContactLKID] [int] NOT NULL,
	CreatedByUserId int NOT NULL,
	CreatedDate [datetime] NOT NULL,
	CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([PersonId] ASC),
	CONSTRAINT [FK_Persons_Units] FOREIGN KEY (UnitId) REFERENCES [Units] (UnitId)
	--todo, user id FK
	
)
