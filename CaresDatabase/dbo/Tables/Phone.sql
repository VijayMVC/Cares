CREATE TABLE [dbo].[Phone] (
    [PhoneID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [IsDefault]        BIT            NULL,
    [PhoneNumber]      NVARCHAR (25)  NULL,
    [BPMainID]         BIGINT         NULL,
    [PhoneTypeID]      SMALLINT       NOT NULL,
    [WorkLocationID]   BIGINT         NULL,
    [EmployeeID]       BIGINT         NULL,
    [RowVersion]       BIGINT         CONSTRAINT [DF_Phone_RowVersion] DEFAULT ((0)) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF__Phone__IsActive__40257DE4] DEFAULT ((1)) NOT NULL,
    [IsDeleted]        BIT            CONSTRAINT [DF__Phone__IsDeleted__4119A21D] DEFAULT ((0)) NOT NULL,
    [IsPrivate]        BIT            CONSTRAINT [DF__Phone__IsPrivate__420DC656] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]       BIT            CONSTRAINT [DF__Phone__IsReadOnl__4301EA8F] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]     DATETIME       NOT NULL,
    [RecCreatedBy]     NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt] DATETIME       NOT NULL,
    [RecLastUpdatedBy] NVARCHAR (100) NOT NULL,
    [UserDomainKey]    BIGINT         NOT NULL,
    CONSTRAINT [PK33] PRIMARY KEY NONCLUSTERED ([PhoneID] ASC),
    CONSTRAINT [RefBPMain242] FOREIGN KEY ([BPMainID]) REFERENCES [dbo].[BPMain] ([BPMainID]),
    CONSTRAINT [RefEmployee344] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [RefPhoneType1941] FOREIGN KEY ([PhoneTypeID]) REFERENCES [dbo].[PhoneType] ([PhoneTypeID]),
    CONSTRAINT [RefworkLocation1942] FOREIGN KEY ([WorkLocationID]) REFERENCES [dbo].[WorkLocation] ([WorkLocationID]) ON DELETE CASCADE
);





