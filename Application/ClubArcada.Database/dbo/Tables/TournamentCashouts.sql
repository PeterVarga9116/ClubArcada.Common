CREATE TABLE [dbo].[TournamentCashouts] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [TournamentId]    UNIQUEIDENTIFIER NOT NULL,
    [Rake]            DECIMAL (18, 2)  NOT NULL,
    [Prizepool]       DECIMAL (18, 2)  NOT NULL,
    [Food]            DECIMAL (18, 2)  NOT NULL,
    [Dotation]        DECIMAL (18, 2)  NOT NULL,
    [Places]          NVARCHAR (MAX)   NOT NULL,
    [RunnerHelp]      DECIMAL (18, 2)  NOT NULL,
    [Tips]            DECIMAL (18, 2)  NOT NULL,
    [CGBank]          DECIMAL (18, 2)  NOT NULL,
    [APCBank]         DECIMAL (18, 2)  NOT NULL,
    [Comment]         NVARCHAR (500)   NOT NULL,
    [Floor]           DECIMAL (18, 2)  NOT NULL,
    [Dealer]          DECIMAL (18, 2)  NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TournamentCashouts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TournamentCashouts_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);

