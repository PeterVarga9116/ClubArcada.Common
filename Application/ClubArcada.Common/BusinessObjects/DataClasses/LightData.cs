using System;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class UserLight
    {
        public UserLight(User user)
        {
            Id = user.Id;
            FullName = user.DisplyNameWithNickname;
        }

        public Guid Id { get; set; }

        public string FullName { get; set; }

    }

    public class TournamentPlayerLight
    {
        public TournamentPlayerLight(TournamentPlayer tp)
        {
            Id = tp.Id;
            Rank = tp.Rank;
            Points = tp.Points;
            Poker = tp.PokerCount;
            StraightFlush = tp.StraightFlushCount;
            RoyalFlush = tp.RoyalFlushCount;
            ReEntryCount = tp.ReEntryCount;
            ReBuyCount = tp.ReBuyCount;
            AddOnCount = tp.AddOnCount;
            User = new UserLight(tp.User);
            BonusPoints = Poker * 5 + StraightFlush * 10 + RoyalFlush * 15;
        }

        public Guid Id { get; set; }

        public int ReEntryCount { get; set; }

        public int ReBuyCount { get; set; }

        public int AddOnCount { get; set; }

        public int Rank { get; set; }

        public int Poker { get; set; }

        public int StraightFlush { get; set; }

        public int RoyalFlush { get; set; }

        public int BonusPoints { get; set; }

        public decimal Points { get; set; }

        public UserLight User { get; set; }
    }
}
