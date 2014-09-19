﻿CREATE TABLE [dbo].[BPMain] (
    [BPMainID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [CompanyID]             BIGINT         NOT NULL,
    [BPMainCode]            NVARCHAR (100) NOT NULL,
    [BPMainName]            NVARCHAR (255) NULL,
    [BPMainDescription]     NVARCHAR (500) NULL,
    [IsSystemGuarantor]     BIT            CONSTRAINT [DF_BPMain_IsSystemGuarantor] DEFAULT ((0)) NOT NULL,
    [SystemGuarantorID]     BIGINT         NULL,
    [NonSystemGuarantor]    NVARCHAR (500) NULL,
    [BusinessLegalStatusID] SMALLINT       NULL,
    [IsIndividual]          BIT            NOT NULL,
    [DealingEmployeeID]     BIGINT         NULL,
    [RowVersion]            BIGINT         CONSTRAINT [DF__BPMain__RowVersi__66D536B1] DEFAULT ((0)) NOT NULL,
    [IsActive]              BIT            CONSTRAINT [DF__BPMain__IsActive__67C95AEA] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT            CONSTRAINT [DF__BPMain__IsDelete__68BD7F23] DEFAULT ((0)) NOT NULL,
    [IsPrivate]             BIT            CONSTRAINT [DF__BPMain__IsPrivat__69B1A35C] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]            BIT            CONSTRAINT [DF__BPMain__IsReadOn__6AA5C795] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]          DATETIME       NOT NULL,
    [RecCreatedBy]          NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedBy]      NVARCHAR (100) NOT NULL,
    [PaymentTermID]         SMALLINT       CONSTRAINT [DF__BPMain__PaymentT__7EC1CEDB] DEFAULT ((2)) NOT NULL,
    [BPRatingTypeID]        SMALLINT       NULL,
    [BPEmailAddress]        NVARCHAR (100) NULL,
    [BPIsValid]             BIT            CONSTRAINT [DF_BPMain_BPIsValid] DEFAULT ((1)) NOT NULL,
    [UserDomainKey]         BIGINT         NOT NULL,
    CONSTRAINT [PK61] PRIMARY KEY CLUSTERED ([BPMainID] ASC),
    CONSTRAINT [RefBPRatingType6191] FOREIGN KEY ([BPRatingTypeID]) REFERENCES [dbo].[BPRatingType] ([BPRatingTypeID]),
    CONSTRAINT [RefBusinessLegalStatus291] FOREIGN KEY ([BusinessLegalStatusID]) REFERENCES [dbo].[BusinessLegalStatus] ([BusinessLegalStatusID]),
    CONSTRAINT [RefCompany325] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]),
    CONSTRAINT [RefPaymentTerm618] FOREIGN KEY ([PaymentTermID]) REFERENCES [dbo].[PaymentTerm] ([PaymentTermID])
);
