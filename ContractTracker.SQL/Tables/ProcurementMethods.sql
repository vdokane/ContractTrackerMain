CREATE TABLE [dbo].[ProcurementMethods]
(
	ProcurementMethodId INT IDENTITY (1, 1) NOT NULL, 
	Code varchar(3) NOT NULL,
	ProcurementMethodDescription varchar(400) NOT NULL,
	Exemption varchar(1) NOT NULL,
	ProcurementDocumentRequired bit NOT NULL,
	Active bit NOT NULL,
	SoleSourceApplicable bit NULL,
	CONSTRAINT [PK_ProcurementMethods] PRIMARY KEY CLUSTERED ([ProcurementMethodId] ASC)
)
