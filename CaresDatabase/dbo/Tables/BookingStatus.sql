CREATE TABLE [dbo].[BookingStatus] (
    [BookingStatusID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BookingStatusCode]        NVARCHAR (100) NOT NULL,
    [BookingStatusName]        NVARCHAR (255) NULL,
    [BookingStatusDescription] NVARCHAR (500) NULL,
    [BookingStatusCat]         SMALLINT       NULL,
    [RowVersion]               BIGINT         CONSTRAINT [DF__BookingSt__RowVe__012A0591] DEFAULT ((0)) NOT NULL,
    [IsActive]                 BIT            CONSTRAINT [DF__BookingSt__IsAct__021E29CA] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT            CONSTRAINT [DF__BookingSt__IsDel__03124E03] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                BIT            CONSTRAINT [DF__BookingSt__IsPri__0406723C] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]               BIT            CONSTRAINT [DF__BookingSt__IsRea__04FA9675] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]             DATETIME       NOT NULL,
    [RecCreatedBy]             NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]         DATETIME       NOT NULL,
    [RecLastUpdatedBy]         NVARCHAR (100) NOT NULL,
    [UserDomainKey]            BIGINT         NOT NULL,
    CONSTRAINT [PK89_1] PRIMARY KEY NONCLUSTERED ([BookingStatusID] ASC)
);

