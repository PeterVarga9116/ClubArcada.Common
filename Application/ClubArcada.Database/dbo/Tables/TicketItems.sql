CREATE TABLE [dbo].[TicketItems] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [TicketId]        UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [Type]            INT              NOT NULL,
    [Name]            NVARCHAR (50)    NOT NULL,
    [Amount]          DECIMAL (18, 2)  NOT NULL,
    [Stack]           INT              NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    CONSTRAINT [PK_TicketItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TicketItems_Tickets] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Tickets] ([Id])
);

