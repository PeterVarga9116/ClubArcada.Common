using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class CashPlayerData
    {
        public static List<sp_get_cash_league_ladderResult> GetCashLadder(Credentials cr, Guid leagueId, int count)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_cash_league_ladder(count, leagueId, null, null).ToList();
            }
        }
    }
}
