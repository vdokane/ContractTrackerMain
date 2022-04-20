﻿CREATE TABLE [dbo].[UserUnits]
(
	[UserUnitId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[UnitId] INT NOT NULL,
	[EndDate] DATETIME NULL,
	CONSTRAINT [PK_UserUnits] PRIMARY KEY CLUSTERED ([UserUnitId] ASC),
	CONSTRAINT [FK_UserUnits_Units] FOREIGN KEY (UnitId) REFERENCES Units ([UnitId]),
	CONSTRAINT [FK_UserUnits_Users] FOREIGN KEY (UserId) REFERENCES Users ([UserId])
)
