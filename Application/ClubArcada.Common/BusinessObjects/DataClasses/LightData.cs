using Newtonsoft.Json;
using System;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class UserLight
    {
        public UserLight(User user)
        {
            Id = user.Id;
            FullName = user.DisplyNameWithNickname;
            Nickname = user.NickName;
        }

        [JsonProperty("ID")]
        public Guid Id { get; set; }

        [JsonProperty("FN")]
        public string FullName { get; set; }

        [JsonProperty("N")]
        public string Nickname { get; set; }

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

        [JsonProperty("ID")]
        public Guid Id { get; set; }

        [JsonProperty("RNC")]
        public int ReEntryCount { get; set; }

        [JsonProperty("RBC")]
        public int ReBuyCount { get; set; }

        [JsonProperty("AOC")]
        public int AddOnCount { get; set; }

        [JsonProperty("R")]
        public int Rank { get; set; }

        [JsonProperty("B1")]
        public int Poker { get; set; }

        [JsonProperty("B2")]
        public int StraightFlush { get; set; }

        [JsonProperty("B3")]
        public int RoyalFlush { get; set; }

        [JsonProperty("BP")]
        public int BonusPoints { get; set; }

        [JsonProperty("P")]
        public decimal Points { get; set; }

        public UserLight User { get; set; }
    }
}
