CREATE PROCEDURE [dbo].[sp_get_tournament_results] 
	@tournamentId uniqueidentifier
AS
BEGIN
	SELECT 
	t.Rank
	,u.NickName
	,t.Points
	,u.IsPersonal
	,t.State
	,t.ReEntryCount
	,t.ReBuyCount
	,t.AddOnCount
	,t.DateCreated
	,t.DateDeleted
	,t.RoyalFlushCount
	,t.StraightFlushCount
	,PokerCount

	FROM TournamentPlayers t
	JOIN Users u on u.Id = t.UserId

	WHERE 
	t.TournamentId = @tournamentId 
	ORDER BY
	t.Rank
END