﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class TournamentResultData
    {
        public static TournamentPlayer GetById(Credentials cr, Guid id)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.TournamentPlayers.SingleOrDefault(u => u.Id == id);
            }
        }

        public static List<TournamentPlayer> GetListByTournamentId(Credentials cr, Guid tournamentId)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.TournamentPlayers.Where(u => u.TournamentId == tournamentId).ToList();
            }
        }

        public static void SetState(Credentials cr, Guid id, int state)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var toUpdate = dc.TournamentPlayers.SingleOrDefault(t => t.Id == id);

                toUpdate.State = state;
                dc.SubmitChanges();
            }
        }

        public static TournamentPlayer Save(Credentials cr, TournamentPlayer item)
        {
            var loaded = GetById(cr, item.Id);

            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static TournamentPlayer Create(Credentials cr, TournamentPlayer item)
        {
            if (item.Id.IsNull())
            {
                item.Id = Guid.NewGuid();
            }

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.TournamentPlayers.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static TournamentPlayer Update(Credentials cr, TournamentPlayer item)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var toUpdate = dc.TournamentPlayers.SingleOrDefault(u => u.Id == item.Id);

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