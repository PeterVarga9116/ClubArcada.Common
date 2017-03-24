-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_requests]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 

r.DateCompleted
,r.DateCreated
,r.DateDeleted
,r.Description
,r.Id
,r.Status
,u.FirstName + ' ' + u.LastName AS UserCreated
,uc.FirstName + ' ' + uc.LastName AS UserCompleted

FROM Requests r
LEFT JOIN Users u on r.CreatedByUserId = u.Id
LEFT JOIN Users uc on r.AssignedTo = uc.Id
END