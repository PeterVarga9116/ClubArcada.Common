CREATE PROCEDURE [dbo].[sp_get_cash_league_ladder] 
	@Count INT,
	@LeagueId UNIQUEIDENTIFIER = null,
	@DateFrom DateTime = null,
	@DateTo DateTime = null
AS
BEGIN
	SELECT TOP (@Count) a.userid,
                        a.points,
                        a.playcount,
                        u.nickname,
						a.state
    FROM   (SELECT DISTINCT cr.UserId,
                            Sum(cr.Points) AS Points,
                            Count(cr.UserId) AS PlayCount,
							Sum(cr.State) AS state
            FROM   CashPlayers cr
                   INNER JOIN tournaments t ON t.Id = cr.tournamentid
                   INNER JOIN leagues l ON l.Id = t.leagueid
            WHERE		(@LeagueId IS NULL OR l.Id = @LeagueId)
					AND (@DateFrom IS NULL OR @DateFrom < t.Date)
					AND	(@DateTo IS NULL OR @DateTo > t.Date)
					AND t.DateDeleted IS NULL
            GROUP  BY cr.UserId) a
           INNER JOIN users u ON u.Id = a.UserId
		   WHERE u.IsPersonal = 0
    ORDER  BY a.points DESC,
              a.playcount DESC,
              u.nickname 
END