
CREATE PROCEDURE [dbo].[sp_get_shifts]
	@businessUnitId uniqueidentifier,
	@dateFrom	datetime,
	@dateTo datetime
AS
BEGIN

   SELECT 
   
   s.Id AS 'Id'
   ,s.StartDate
   ,s.EndDate
   ,s.Duration
   ,s.IsDay
   ,s.Type
   ,u.FirstName + ' ' + u.LastName AS 'Name'
   ,u.Color


   FROM 
   Shifts s
   JOIN Users u on u.Id = s.UserId
   WHERE s.BusinessUnitId = @businessUnitId
END