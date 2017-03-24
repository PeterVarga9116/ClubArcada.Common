-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_user_transaction_history] 
	@userId uniqueidentifier
AS
BEGIN
SELECT

t.Id,
t.TransactionType,
t.DateAddedToDB,
t.DateCreated,
t.DateUsed,
t.Amount,
t.Amount2,
t.Description,
t.DatePayed,
t.DateCreated,
t.CreatedByApp,
t.AttachedTransactionId,

uu.FirstName + ' ' + uu.LastName as 'CreatedBy'

FROM Transactions t
JOIN Users uu on uu.Id = t.CreatedByUserId

WHERE t.UserId = @userId AND t.DateDeleted IS NULL

ORDER BY t.DateCreated DESC
END