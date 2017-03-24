
CREATE PROCEDURE [dbo].[sp_get_audit_history]
	@count int
AS
BEGIN
	SELECT TOP(@count)
		a.DateCreated
		,a.Type
		,a.Description
		,u.FirstName + ' ' + u.LastName AS 'CreatedByUser'
	FROM
	AuditHistories a
	LEFT JOIN Users u on u.Id = a.CreatedByUserId
	ORDER BY a.DateCreated DESC
END