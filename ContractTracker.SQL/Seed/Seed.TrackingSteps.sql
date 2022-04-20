PRINT 'Populating Tracking Steps (and contract status)'

SET IDENTITY_INSERT [dbo].[TrackingSteps] ON
GO


MERGE INTO [dbo].[TrackingSteps] as Env
	USING ( VALUES
	(1,	'Created', 'I',	1)
	,(2,	'Submitted to GS', '2',	1)
	,(3,	'Approved by Gen Svcs', '?',	1)
	,(4,	'Resubmitted to General Services', '?',	1)
	,(5,	'Sent Back to User for Resubmission', '3',	1)
	,(6,	'Exported to FACTS', '?',	1)
	,(7,	'Contract Changed', '?',	1)
	,(8,	'On Hold', '?',	1)
	,(9,	'Under Review', '?',	1)
	,(10,	'SS Checks', '?',	1)

	) seed (TrackingStepId, StepDescription, StatusCode,IsActive )
		ON Env.TrackingStepId = seed.TrackingStepId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (TrackingStepId, StepDescription, StatusCode,IsActive )
	VALUES (TrackingStepId, StepDescription, StatusCode,IsActive );
GO 

SET IDENTITY_INSERT [dbo].[TrackingSteps] OFF
GO

/*
1	I	Initial	NULL	0
4	F	Finalized/Active	NULL	0
5	E	Executed	NULL	0
6	A	Ammended	NULL	0
12	C	Copied From Gen Svcs System	NULL	0
13	1	Preparing	NULL	0
14	2	Awaiting approval by General Services	NULL	0
15	3	Sent back to user for resubmission	NULL	0
16	4	Approved by Gen Svcs	NULL	0
17	5	Resubmitted to General Services	NULL	0
18	6	Exported to FACTS	NULL	0
19	7	On Hold	NULL	1
20	8	Under Review	NULL	1
21	9	SS Checks	NULL	1


--How can I combine the two?
ContractTrackingStepsID	StepDescription	Active
1	Created	1
2	Submitted to GS	1
3	Approved by Gen Svcs	1
4	Resubmitted to General Services	1
5	Sent Back to User for Resubmission	1
6	Exported to FACTS	1
7	Contract Changed	1 */