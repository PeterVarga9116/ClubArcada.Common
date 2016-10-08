using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class TournamentResultData
    {
        public static TournamentResult GetById(Credentials cr, Guid id)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.TournamentResults.SingleOrDefault(u => u.Id == id);
            }
        }

        public static List<TournamentResult> GetListByTournamentId(Credentials cr, Guid tournamentId)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.TournamentResults.Where(u => u.TournamentId == tournamentId).ToList();
            }
        }

        public static void SetState(Credentials cr, Guid id, int state)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var toUpdate = dc.TournamentResults.SingleOrDefault(t => t.Id == id);

                toUpdate.State = state;
                dc.SubmitChanges();
            }
        }

        public static TournamentResult Save(Credentials cr, TournamentResult item)
        {
            var loaded = GetById(cr, item.Id);

            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static TournamentResult Create(Credentials cr, TournamentResult item)
        {
            if (item.Id.IsNull())
            {
                item.Id = Guid.NewGuid();
            }

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.TournamentResults.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static TournamentResult Update(Credentials cr, TournamentResult item)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var toUpdate = dc.TournamentResults.SingleOrDefault(u => u.Id == item.Id);

                toUpdate.AddOnCount = item.AddOnCount;
                toUpdate.DateDeleted = item.DateDeleted;
                toUpdate.Points = item.Points;
                toUpdate.PokerCount = item.PokerCount;
                toUpdate.Rank = item.Rank;
                toUpdate.ReBuyCount = item.ReBuyCount;
                toUpdate.ReEntryCount = item.ReEntryCount;
                toUpdate.RoyalFlushCount = item.RoyalFlushCount;
                toUpdate.SpecialAddOnCount = item.SpecialAddOnCount;
                toUpdate.StraightFlushCount = item.StraightFlushCount;

                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }
    }
}