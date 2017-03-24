CREATE TABLE [dbo].[TournamentPlayers] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [TournamentId]       UNIQUEIDENTIFIER NOT NULL,
    [UserId]             UNIQUEIDENTIFIER NOT NULL,
    [Points]             DECIMAL (18, 2)  NOT NULL,
    [Rank]               INT              NOT NULL,
    [ReBuyCount]         INT              NOT NULL,
    [AddOnCount]         INT              NOT NULL,
    [PokerCount]         INT              NOT NULL,
    [StraightFlushCount] INT              NOT NULL,
    [RoyalFlushCount]    INT              NOT NULL,
    [DateCreated]        DATETIME         NOT NULL,
    [DateDeleted]        DATETIME         NULL,
    [ReEntryCount]       INT              NOT NULL,
    [State]              INT              NOT NULL,
    [SpecialAddOnCount]  INT              NOT NULL,
    [StackBonusSum]      INT              CONSTRAINT [DF_TournamentPlayers_StackBonus] DEFAULT ((0)) NOT NULL,
    [CreatedByUserId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TournamentResults] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TournamentPlayers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_TournamentResults_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);

