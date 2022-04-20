CREATE TABLE [dbo].[Announcements]
(
	[AnnouncementId] [int] IDENTITY(1,1) NOT NULL,
	[AnnouncementMessage] [varchar](7000) NOT NULL,
	[UserId] [int] NOT NULL,
	[InsertDate] date null
)
