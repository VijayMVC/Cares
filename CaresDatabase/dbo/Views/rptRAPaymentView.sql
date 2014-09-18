create view [dbo].[rptRAPaymentView]
as
SELECT     
		P.RAPaymentID, P.PaymentModeID, P.RAMainID, P.RAPaymentDt, P.RAPaymentAmount, P.ChequeNumber, P.CreditCardNumber, P.IssueDate, P.ClearanceDate, 
        P.CreditCardType, P.Bank, P.CreditCardExpiryDt, P.PaidBy, P.IsActive, P.IsDeleted, P.IsPrivate, P.IsReadOnly, P.RowVersion, P.RecCreatedDt, P.RecLastUpdatedDt, 
        P.RecCreatedBy, P.RecLastUpdatedBy,
		PM.PaymentModeCode,PM.PaymentModeName
from
RAPayment P
inner join PaymentMode PM on PM.PaymentModeID = P.PaymentModeID