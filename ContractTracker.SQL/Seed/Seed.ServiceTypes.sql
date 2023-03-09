PRINT 'Populating ServiceTypes'

SET IDENTITY_INSERT [dbo].[ServiceTypes] ON
GO


MERGE INTO [dbo].[ServiceTypes] as Env
	USING ( VALUES
		 (1	,'Court Reporting Services','CRS')
		,(2	,'Court Interpreting Services','CIS')
		,(3	,'Expert Witness-Psych','EW-PSY')
		,(4	,'Mediaton Services','Mediator	')
		,(5	,'Custody Evaluator','CE')
		,(6	,'Hearing Officer-Civil Traffic','CTHO')
		,(7	,'Hearing Officer-Child Support','CSHO')
		,(12	,'Consulting Services','ConsultS')
		,(13	,'Copier/Fax Equipment Purchase','COPY/FAX P')
		,(14	,'Staffing-Administrative Assistant','Staff-AA')
		,(15	,'Training/Education','TRN/EDU')
		,(16	,'Contracted Services','CONTSVSC')
		,(17	,'Legal Services-Research','LEG-R')
		,(18	,'Case Management-Probate','CM-PROBT')
		,(19	,'Professional Contracted Services','PContract')
		,(20	,'Case Management-Family Court','CM-FAM')
		,(21	,'Legal Services-Consulting','LEG-Cons')
		,(22	,'Digital Court Reporting Equipment','DCRE')
		,(23	,'Interlocal Agreement','IA')
		,(24	,'Magistrate Services','MAG')
		,(25	,'Professional Consulting Services','PConsult')
		,(26	,'Hotel/Meeting Rooms','Hotel')
		,(27	,'Warranty Service Contracts','Warranty')
		,(28	,'Postage','Postage')
		,(29	,'Lease of Space','Lease')
		,(30	,'Grant Disbursement','GRNTDISB')
		,(31	,'Financial Assistance-Private Donation','PFA')
		,(32	,'Grant in Aid Disbursement','GIA-DISB')
		,(33	,'Memorandum of Understanding','MOU')
		,(34	,'Subscriptions-Reference Materials','SUB-REF')
		,(35	,'Staffing-General Labor','Staff-GL')
		,(36	,'Financial Assistance-State','SFA')
		,(38	,'Maintenance-Equipment','Maint-E')
		,(40	,'Maintanance-Building','Maint-B')
		,(41	,'Maintenance-Grounds','Maint-G')
		,(43	,'Accounting/Auditing Services','Acct-Aud')
		,(44	,'Investigative Services','INV-S')
		,(45	,'Expert Witness-Medical','EW-MED')
		,(46	,'Case Management-Criminal Court','CM-CRIM')
		,(47	,'Case Manage-Prob Solving Court','CM-PROBS')
		,(48	,'Hearing Officer Services','HOS')
		,(49	,'Maintenance/Service Contracts','Maint-A')
		,(50	,'Staffing-Prof Svcs Augmentation','Staff-Aug')
		,(51	,'Court Interpreting Equipment','CIE')
		,(52	,'Court Reporting Equipment','CRE')
		,(53	,'Digital Court Reporting Services','DCRS')
		,(54	,'Copier/FAX Equipment Lease','COPY/FAX L')
		,(55	,'Expert Witness-Other','EW-O')
		,(56	,'Shredding/Records Destruction','ShredRD')
		,(57	,'Subscriptions-Software','SUB-SOFT')
		,(58	,'Subscriptions-Online Data Services','SUB-OLD')
		,(59	,'Shipping-Express Courier Services','SHIP-C')
		,(60	,'Shipping-Freight','SHIP-F')
		,(61	,'Financial Assistance-Federal','FFA')
		,(62	,'Reference Materials','REF')
		,(65	,'IT-Software Licenses','IT-SOFT-L')
		,(67	,'IT-Software-Media','IT-SOFT-M')
		,(68	,'Comminucations Services','Comm')
		,(69	,'Substance Abuse Treatment-Outpat','SATS-Out')
		,(70	,'Substance Abuse Treatment-Inpati','SATS-In')
		,(71	,'Substance Abuse Treatment-TransH','SATS-TRH')
		,(72	,'IT-Software-Comm Off The Shelf','IT-STFT-CO')
		,(73	,'IT-Database Services','ITDB')
		,(74	,'IT-Programming Services','IT-PROG')
		,(75	,'IT-Software Install/Config Svcs','IT-SICS')
		,(76	,'IT-Hardware Install/Config Svcs','IT-HWICS')
		,(77	,'IT-Consulting Services','IT-Consult')
		,(78	,'Legal Services-Attorney Rep','LEG-Rep')
		,(79	,'Audio/Visual Equipment-Purchase','AV-P')
		,(80	,'Audio Visual Equipment-Rental','AV-R')
		,(81	,'Audio Visual Services','AV-S')
		,(82	,'First Aid Supplies','FAS')
		,(83	,'First Aid Equipment','FAE')
		,(84	,'Veteran Treatment Program-Outpat','VETS-Out')
		,(85	,'Veteran Treatment Program-Inpati','VETS-In')
		,(86	,'Veteran Treatment Program-TransH','VETS-TRH')
		,(87	,'Substance Abuse Treatment-PROG','SATS-PGM')
		,(88	,'Settlement Agreement','SA')
	
	) seed ([ServiceTypeId],[ServiceTypeName],[ShortTitle])
		ON Env.[ServiceTypeId] = seed.[ServiceTypeId]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([ServiceTypeId],[ServiceTypeName],[ShortTitle])
	VALUES ([ServiceTypeId],[ServiceTypeName],[ShortTitle]);
GO 

SET IDENTITY_INSERT [dbo].[ServiceTypes] OFF
GO

 