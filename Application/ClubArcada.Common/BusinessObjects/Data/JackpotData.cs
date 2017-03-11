using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class JackpotData
    {
        public static Jackpot GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Jackpots.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Jackpot GetActive(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Jackpots.SingleOrDefault(j => j.DateStopped.IsNull());
            }
        }

        public static List<Jackpot> GetList(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Jackpots.ToList();
            }
        }

        public static Jackpot Create(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var item = new Jackpot();

                item.Id = Guid.NewGuid();
                item.DateStarted = DateTime.Now;

                dc.Jackpots.InsertOnSubmit(item);
                dc.SubmitChanges();
                return item;
            }
        }

        public static void TriggerJackpot(Credentials cr, Guid floorId, Guid winUserId, decimal amount)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var activeJackpot = dc.Jackpots.SingleOrDefault(j => j.DateStopped.IsNull());

                activeJackpot.DateStopped = DateTime.Now;
                activeJackpot.FloorUserId = floorId;
                activeJackpot.WinUserId = winUserId;
                activeJackpot.Amount = amount;

                dc.SubmitChanges();
            }

            Create(cr);
        }
    }
}