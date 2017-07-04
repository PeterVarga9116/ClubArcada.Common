using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TournamentPlayerData
    {
        public static List<TournamentPlayer> GetListByTournamentId(Credentials cr, Guid tournamentId, bool loadUser = false)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var list = dc.TournamentPlayers.Where(u => u.TournamentId == tournamentId).ToList();

                if (loadUser)
                {
                    foreach (var l in list)
                    {
                        l.User = UserData.GetById(cr, l.UserId);
                    }
                }

                return list;
            }
        }

        public static void SetState(Credentials cr, Guid id, int state)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toUpdate = dc.TournamentPlayers.SingleOrDefault(t => t.Id == id);

                toUpdate.State = state;
                dc.SubmitChanges();
            }
        }

        public static List<sp_get_tournament_resultsResult> GetPlayers(Credentials cr, Guid tournamentId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_tournament_results(tournamentId).ToList();
            }
        }

        public static List<sp_get_poker_league_ladderResult> GetTournamentLadder(Credentials cr, Guid leagueId, int count)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_poker_league_ladder(count, leagueId, null, null).ToList();
            }
        }
    }
}