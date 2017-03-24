CREATE TABLE [dbo].[Users] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [CreatedByUserId]  UNIQUEIDENTIFIER NOT NULL,
    [FirstName]        NVARCHAR (100)   NOT NULL,
    [LastName]         NVARCHAR (100)   NOT NULL,
    [NickName]         NVARCHAR (100)   NOT NULL,
    [Email]            NVARCHAR (100)   NOT NULL,
    [PhoneNumber]      NVARCHAR (100)   NOT NULL,
    [Password]         NVARCHAR (20)    NOT NULL,
    [IsAdmin]          BIT              NOT NULL,
    [IsBlocked]        BIT              NOT NULL,
    [IsPersonal]       BIT              NOT NULL,
    [AutoReturnType]   INT              CONSTRAINT [DF_Users_AutoReturnType] DEFAULT ((2)) NOT NULL,
    [IsWallet]         BIT              NOT NULL,
    [AdminLevel]       INT              NOT NULL,
    [DateCreated]      DATETIME         NOT NULL,
    [IsTestUser]       BIT              NOT NULL,
    [EmailConfirmed]   BIT              CONSTRAINT [DF_Users_EmailConfirmed] DEFAULT ((0)) NOT NULL,
    [PasswordHash]     NVARCHAR (MAX)   NULL,
    [SecurityStamp]    NVARCHAR (MAX)   NULL,
    [TwoFactorEnabled] BIT              CONSTRAINT [DF_Users_TwoFactorEnabled] DEFAULT ((0)) NOT NULL,
    [Color]            NVARCHAR (50)    NULL,
    [ImageId]          UNIQUEIDENTIFIER NULL,
    [BusinessUnitId]   UNIQUEIDENTIFIER NULL,
    [DateDeleted]      DATETIME         NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[tr_create_audit_history_users_oncreate]
   ON  [dbo].[Users]
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
		3,
		'New user: ' + (SELECT NickName + ' - ' + FirstName + ' ' + LastName FROM inserted)
		)

END