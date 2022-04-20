PRINT 'Populating Method of Payments'

SET IDENTITY_INSERT [dbo].[MethodOfPayments] ON
GO


MERGE INTO [dbo].[MethodOfPayments] as Env
	USING ( VALUES
	(1,'Fixed Price - Lump Sum')
	,(2,'Fixed Fee / Unit Rate')
	,(3,'Advanced - 100% Advance')
	,(4,'Advanced - Fixed Price Unit Cost')
	,(5,'Advanced with Fixed Fee Schedule')
	,(6,'Advanced with Cost Reimbursement')
	,(7,'Cost Reimbursement')
	,(8,'Cost Reimbursement Plus Fixed Fee(s)')
	,(9,'Cost Reimbursement Plus Percentage of Cost')
	,(10,'Cost Reimbursement Plus Incentive Fee')
	,(11,'Cost Reimbursement Plus Award Fee')
	,(12,'Revenue Generating')
	,(13,'No Cost')

	) seed (MethodOfPaymentId, PaymentDescription)
		ON Env.MethodOfPaymentId = seed.MethodOfPaymentId

WHEN NOT MATCHED BY TARGET THEN
	INSERT (MethodOfPaymentId, PaymentDescription)
	VALUES (MethodOfPaymentId, PaymentDescription);
GO 

SET IDENTITY_INSERT [dbo].[MethodOfPayments] OFF
GO