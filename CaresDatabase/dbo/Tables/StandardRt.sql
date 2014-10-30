CREATE TABLE [dbo].[StandardRt] (
    [StandardRtID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChildStandardRtID] BIGINT         NULL,
    [StandardRtMainID]  BIGINT         NOT NULL,
    [AllowedMileage]    INT            NOT NULL,
    [ExcessMileageChrg] FLOAT (53)     NOT NULL,
    [StandardRate]      FLOAT (53)     NOT NULL,
    [RevisionNumber]    BIGINT         NOT NULL,
    [IsActive]          BIT            NOT NULL,
    [IsDeleted]         BIT            NOT NULL,
    [IsPrivate]         BIT            NOT NULL,
    [IsReadOnly]        BIT            NOT NULL,
    [RowVersion]        BIGINT         NOT NULL,
    [RecCreatedDt]      DATETIME       NOT NULL,
    [RecLastUpdatedDt]  DATETIME       NOT NULL,
    [RecCreatedBy]      NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]  NVARCHAR (100) NOT NULL,
    [HireGroupDetailID] BIGINT         NOT NULL,
    [StandardRtEndDt]   DATETIME       NOT NULL,
    [StandardRtStartDt] DATETIME       NOT NULL,
    [UserDomainKey]     BIGINT         NOT NULL,
    CONSTRAINT [PK80] PRIMARY KEY NONCLUSTERED ([StandardRtID] ASC),
    CONSTRAINT [RefHireGroupDetail377] FOREIGN KEY ([HireGroupDetailID]) REFERENCES [dbo].[HireGroupDetail] ([HireGroupDetailID]),
    CONSTRAINT [RefStandardRt371] FOREIGN KEY ([ChildStandardRtID]) REFERENCES [dbo].[StandardRt] ([StandardRtID]),
    CONSTRAINT [RefStandardRtMain148] FOREIGN KEY ([StandardRtMainID]) REFERENCES [dbo].[StandardRtMain] ([StandardRtMainID]) ON DELETE CASCADE
);



