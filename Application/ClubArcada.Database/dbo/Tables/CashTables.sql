CREATE TABLE [dbo].[CashTables] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [TournamentId]    UNIQUEIDENTIFIER NOT NULL,
    [GameType]        INT              NOT NULL,
    [Name]            NVARCHAR (50)    NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateClosed]      DATETIME         NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CashTables] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashTables_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);

