CREATE TABLE [dbo].[BookingMain] (
    [BookingMainID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [OpenLocation]           BIGINT         NOT NULL,
    [CloseLocation]          BIGINT         NOT NULL,
    [BookingMainDescription] NVARCHAR (500) NULL,
    [StartDtTime]            DATETIME       NOT NULL,
    [EndDtTime]              DATETIME       NOT NULL,
    [RowVersion]             BIGINT         CONSTRAINT [DF__BookingMa__RowVe__3691F209] DEFAULT ((0)) NOT NULL,
    [IsActive]               BIT            CONSTRAINT [DF__BookingMa__IsAct__37861642] DEFAULT ((1)) NOT NULL,
    [IsDeleted]              BIT            CONSTRAINT [DF__BookingMa__IsDel__387A3A7B] DEFAULT ((0)) NOT NULL,
    [IsPrivate]              BIT            CONSTRAINT [DF__BookingMa__IsPri__396E5EB4] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]             BIT            CONSTRAINT [DF__BookingMa__IsRea__3A6282ED] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]           DATETIME       NOT NULL,
    [RecCreatedBy]           NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]       DATETIME       NOT NULL,
    [RecLastUpdatedBy]       NVARCHAR (100) NOT NULL,
    [BookingStatusID]        SMALLINT       NOT NULL,
    [PaymentTermID]          SMALLINT       NOT NULL,
    [OperationID]            BIGINT         NOT NULL,
    [UserDomainKey]          BIGINT         NOT NULL,
    [HireGroupDetailID]      BIGINT         NOT NULL,
    CONSTRAINT [PK20_1] PRIMARY KEY NONCLUSTERED ([BookingMainID] ASC),
    CONSTRAINT [RefBookingStatus438] FOREIGN KEY ([BookingStatusID]) REFERENCES [dbo].[BookingStatus] ([BookingStatusID]),
    CONSTRAINT [RefHireGroupDetail] FOREIGN KEY ([HireGroupDetailID]) REFERENCES [dbo].[HireGroupDetail] ([HireGroupDetailID]),
    CONSTRAINT [RefOperation500] FOREIGN KEY ([OperationID]) REFERENCES [dbo].[Operation] ([OperationID]),
    CONSTRAINT [RefOperationsWorkplace436] FOREIGN KEY ([OpenLocation]) REFERENCES [dbo].[OperationsWorkplace] ([OperationsWorkplaceID]),
    CONSTRAINT [RefOperationsWorkplace437] FOREIGN KEY ([CloseLocation]) REFERENCES [dbo].[OperationsWorkplace] ([OperationsWorkplaceID]),
    CONSTRAINT [RefPaymentTerm494] FOREIGN KEY ([PaymentTermID]) REFERENCES [dbo].[PaymentTerm] ([PaymentTermID])
);



