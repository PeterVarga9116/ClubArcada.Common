using System;
using System.Collections.Generic;
using ClubArcada.Common.BusinessObjects.DataClasses;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class TournamentCashoutData
    {
        public static List<CashOut> GetListByCashPlayerId(Credentials cr, Guid playerId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.CashOuts.Where(t => t.PlayerId == playerId).ToList();
            }
        }
    }
}