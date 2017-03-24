CREATE TABLE [dbo].[CashPlayers] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [TournamentId]    UNIQUEIDENTIFIER NOT NULL,
    [CashTableId]     UNIQUEIDENTIFIER NOT NULL,
    [State]           INT              NOT NULL,
    [StartTime]       DATETIME         NOT NULL,
    [EndTime]         DATETIME         NULL,
    [Points]          INT              NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CashResults] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashPlayers_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id]),
    CONSTRAINT [FK_CashPlayers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

