CREATE TABLE [dbo].[TrackingSteps]  
(
	TrackingStepId INT IDENTITY (1, 1) NOT NULL, 
	StepDescription VARCHAR(50) NOT NULL,
	StatusCode VARCHAR(1) NOT NULL,
	IsActive BIT NOT NULL,
	CONSTRAINT [PK_TrackingSteps] PRIMARY KEY CLUSTERED (TrackingStepId ASC)
)
