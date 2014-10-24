CREATE TABLE [dbo].[BookingPayment] (
    [BookingPaymentID]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [PaymentModeID]        SMALLINT       NOT NULL,
    [BookingMainID]        BIGINT         NOT NULL,
    [BookingPaymentDt]     DATETIME       NOT NULL,
    [BookingPaymentAmount] FLOAT (53)     NOT NULL,
    [ChequeNumber]         NVARCHAR (100) NULL,
    [CreditCardNumber]     NVARCHAR (100) NULL,
    [IssueDate]            DATETIME       NULL,
    [ClearanceDate]        DATETIME       NULL,
    [CreditCardType]       NVARCHAR (100) NULL,
    [Bank]                 NVARCHAR (100) NULL,
    [CreditCardExpiryDt]   DATETIME       NULL,
    [PaidBy]               NVARCHAR (100) NULL,
    [UserDomainKey]        BIGINT         NOT NULL,
    CONSTRAINT [PK_BookingPayment] PRIMARY KEY CLUSTERED ([BookingPaymentID] ASC),
    CONSTRAINT [FK_BookingPayment_BookingMain] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]),
    CONSTRAINT [FK_BookingPayment_PaymentMode] FOREIGN KEY ([PaymentModeID]) REFERENCES [dbo].[PaymentMode] ([PaymentModeID])
);



