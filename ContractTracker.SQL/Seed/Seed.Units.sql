PRINT 'Populating Units'

SET IDENTITY_INSERT [dbo].[Units] ON
GO


MERGE INTO [dbo].[Units] as Env
	USING ( VALUES
	(1,'OSCA','ISS GEN.','INFORMATION SUPPORT SERVICES','SC',	1,	1)
	,(2,'OSCA','DSCA-DEPUT','DEPUTY STATE COURT ADMINISTRATOR','SC',	1,	1)
	,(3,'OSCA','SC CRT ED.','COURT EDUCATION','SC',	1,	1)
	,(4,'OSCA','SUPCT-BUDG','BUDGET ADMINISTRATION','SC',	1,	1)
	,(5,'OSCA','CRT SRV SU','COURT SERVICE & SUPPORT','SC',	1,	1)
	,(6,'OSCA','F&A SRVCS','FINANCE AND ACCOUNTING SERVICES','SC',	1,	1)
	,(7,'OSCA','DRC	DISPUTE','RESOLUTION CENTER','SC',	1,	1)
	,(8,'OSCA','RESOURCE P','RESOURCE PLANNING & SUPPORT SERVICES','SC',	1,	1)
	,(9,'OSCA','GENCOUNSEL','GENERAL COUNSELS OFFICE','SC',1,	1)

,(10,'OSCA','CRT ADMIN','EXECUTIVE DIRECTION - COURT ADMINISTRATOR','SC',	1,	1)
,(11,'OSCA','CRT IMPRV','OFFICE OF COURT IMPROVEMENT','SC',	1,	1)
,(12,'OSCA','GEN. SRVCS','GENERAL SERVICES','SC',	1,	1)
,(13,'OSCA','PUBLICATIO','PUBLICATIONS','SC',	1,	1)
,(14,'OSCA','PERSN SRVC','PERSONNEL SERVICES','SC',	1,	1)
,(15,'OSCA','PLANNING','STRATEGIC PLANNING','SC',	1,	1)
,(16,'OSCA','LEGISLATIV','LEGISLATIVE RELATIONS','SC',	1,	1)
,(17,'OSCA','DSCA-DEPUT','DEPUTY STATE COURT ADMINISTRATOR','SC',	1,	1)
,(18,'Circuit 1','1ST CIRC','First Circuit','01',	1,	0)
,(19,'Circuit 2','2ND CIRC','Second Circuit','02',	1,	0)
,(20,'Circuit 3','3RD CIRC','Third Circuit','03',	1,	0)
,(21,'Circuit 4','4TH CIRC','Fourth Circuit','04',	1,	0)
,(22,'Circuit 5','5TH CIRC','Fifth Circuit','05',	1,	0)
,(23,'Circuit 6','6TH CIRC','Sixth Circuit','06',	1,	0)
,(24,'Circuit 7','7TH CIRC','Seventh Circuit','07',	1,	0)
,(25,'Circuit 8','8TH CIRC','Eighth Circuit','08',	1,	0)
,(26,'Circuit 9','9TH CIRC','Ninth Circuit','09',	1,	0)
,(27,'Circuit 10','10TH CIRC','Tenth Circuit','10',	1,	0)
,(28,'Circuit 11','11TH CIRC','Eleventh Circuit','11',	1,	0)
,(29,'Circuit 12','12TH CIRC','Twelfth Circuit','12',	1,	0)
,(30,'Circuit 13','13TH CIRC','Thirteenth Circuit','13',	1,	0)
,(31,'Circuit 14','14TH CIRC','Fourteenth Circuit','14',	1,	0)
,(32,'Circuit 15','15TH CIRC','Fifteenth Circuit','15',	1,	0)
,(33,'Circuit 16','16TH CIRC','Sixteenth Circuit','16',	1,	0)
,(34,'Circuit 17','17TH CIRC','Seventieth Circuit','17',	1,	0)
,(35,'Circuit 18','18TH CIRC','Eighteenth Circuit','18',	1,	0)
,(36,'Circuit 19','19TH CIRC','Ninetieth Circuit','19',	1,	0)
,(37,'Circuit 20','20TH CIRC','Twentieth Circuit','20',	1,	0)
,(38,'DCA 1','1ST DCA','First DCA','D1',	1,	0)
,(39,'DCA 2','2ND DCA','Second DCA','D2',	1,	0)
,(40,'DCA 3','3RD DCA','Third DCA','D3',	1,	0)
,(41,'DCA 4','4TH DCA','Fourth DCA','D4',	1,	0)
,(42,'DCA 5','5TH DCA','Fifth DCA','D5',	1,	0)
,(43,'Supreme Court','SUPRM CRT','Supreme Court','SC',	1,	1)
,(44,'OSCA','INSP GENER','INSPECTOR GENERAL','SC',	1,	1)
,(45,'Judicial Qualifications Commission','SUPRM CRT','Judicial Qualifications Commission','JQ',	1,	0)
	 

	) seed ([UnitId], [Bureau], [SectionDesc],[Section],[UnitCode],[AllUsersCanSubmit],[PurchaseRequiresSpecialRouting] )
		ON Env.[UnitId] = seed.[UnitId]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([UnitId], [Bureau], [SectionDesc],[Section],[UnitCode],[AllUsersCanSubmit],[PurchaseRequiresSpecialRouting])
	VALUES ([UnitId], [Bureau], [SectionDesc],[Section],[UnitCode],[AllUsersCanSubmit],[PurchaseRequiresSpecialRouting]);
GO 

SET IDENTITY_INSERT [dbo].[Units] OFF
GO