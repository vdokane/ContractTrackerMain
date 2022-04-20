CREATE TABLE [dbo].[MethodOfPayments]
(
	MethodOfPaymentId INT IDENTITY (1, 1) NOT NULL, 
	PaymentDescription varchar(100) NOT NULL,
	CONSTRAINT [PK_MethodOfPayments] PRIMARY KEY CLUSTERED ([MethodOfPaymentId] ASC)
)
