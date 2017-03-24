CREATE TABLE [dbo].[Shifts] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [BusinessUnitId]  UNIQUEIDENTIFIER NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [Type]            INT              NOT NULL,
    [Duration]        INT              NOT NULL,
    [IsDay]           BIT              NULL,
    [StartDate]       DATETIME         NOT NULL,
    [EndDate]         DATETIME         NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Shifts_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

