CREATE TABLE [dbo].[CashStates] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [TournamentId]     UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId]  UNIQUEIDENTIFIER NOT NULL,
    [ModifiedByUserId] UNIQUEIDENTIFIER NULL,
    [Input]            DECIMAL (18, 2)  NOT NULL,
    [LastInput]        DECIMAL (18, 2)  NOT NULL,
    [Rake]             DECIMAL (18, 2)  NOT NULL,
    [Jackpot]          DECIMAL (18, 2)  NOT NULL,
    [State]            INT              NOT NULL,
    [DateCreated]      DATETIME         NOT NULL,
    [DateDeleted]      DATETIME         NULL,
    CONSTRAINT [PK_CashStates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashStates_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);

