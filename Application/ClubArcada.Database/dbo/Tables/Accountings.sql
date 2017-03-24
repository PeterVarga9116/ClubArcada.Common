CREATE TABLE [dbo].[Accountings] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [IsLoggedInTournament] BIT              NOT NULL,
    [IsLoggedInCash]       BIT              NOT NULL,
    [DateLastReset]        DATETIME         NULL,
    [DateDeleted]          DATETIME         NULL,
    [DateCreated]          DATETIME         NOT NULL,
    [CreatedByUserId]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Accountings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Accountings_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

