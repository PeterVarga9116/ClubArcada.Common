CREATE TABLE [dbo].[StructureDetails] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [StructureId]     UNIQUEIDENTIFIER NOT NULL,
    [Type]            INT              NOT NULL,
    [Number]          INT              NOT NULL,
    [Level]           INT              NOT NULL,
    [SB]              INT              NOT NULL,
    [BB]              INT              NOT NULL,
    [Ante]            INT              NOT NULL,
    [Time]            INT              NOT NULL,
    [IsLastLevel]     BIT              NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_StructureDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StructureDetails_Structures] FOREIGN KEY ([StructureId]) REFERENCES [dbo].[Structures] ([Id])
);

