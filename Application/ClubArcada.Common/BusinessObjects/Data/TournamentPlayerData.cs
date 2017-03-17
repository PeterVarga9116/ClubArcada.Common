using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TournamentPlayerData
    {
        public static List<TournamentPlayer> GetListByTournamentId(Credentials cr, Guid tournamentId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.TournamentPlayers.Where(u => u.TournamentId == tournamentId).ToList();
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
    }
}