using System;
using System.Collections.Generic;
using ClubArcada.Common.BusinessObjects.DataClasses;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class TournamentCashoutData
    {
        public static List<CashOut> GetListByCashResultResutltId(Credentials cr, Guid playerId)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.CashOuts.Where(t => t.PlayerId == playerId).ToList();
            }
        }

        private static CashOut Create(Credentials cr, CashOut item)
        {
            item.DateCreated = DateTime.Now;
            item.Id = Guid.NewGuid();
            item.CreatedByUserId = cr.UserId;

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.CashOuts.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return item;
        }
    }
}