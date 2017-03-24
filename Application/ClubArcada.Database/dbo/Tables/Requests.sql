CREATE TABLE [dbo].[Requests] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId] UNIQUEIDENTIFIER NOT NULL,
    [AssignedTo]      UNIQUEIDENTIFIER NULL,
    [Status]          INT              NOT NULL,
    [Description]     NVARCHAR (500)   NOT NULL,
    [DateCreated]     DATETIME         NOT NULL,
    [DateDeleted]     DATETIME         NULL,
    [DateCompleted]   DATETIME         NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Requests_Users] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[Users] ([Id])
);


GO

CREATE TRIGGER [dbo].[tr_create_audit_history_oncreate] 
   ON  [dbo].[Requests]
   AFTER INSERT
AS 
BEGIN
      INSERT INTO audithistories
		(
		Id,
		datecreated,
		ObjectId,
		CreatedByUserId,
		type,
		Description
		)
	VALUES      
		(
		NewId(),
		Getdate(),
		(SELECT Id FROM inserted),
		(SELECT CreatedByUserId FROM inserted),
		2,
		'New internal request'
		)

END