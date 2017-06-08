using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Tournament
    {
        public EnumModel GameTypeEnum
        {
            get
            {
                return new EnumModel() { id = (int)GameType, name = ((eGameType)GameType).GetDescription(), property = ((eGameType)GameType).GetGameTypeColor() };
            }
            set
            {
                this.GameType = value.id;
            }
        }

        public TournamentCashout CashOut { get; set; }

        public List<TournamentPlayerLight> PlayersLight { get; set; }
        public List<TournamentPlayer> Players { get; set; }

        public string DisplayName { get { return string.Format("€{0} {1}", BuyInPrize, GameTypeEnum.name).ToUpper(); } set { } }

        public string DateDisplayName { get { return Date.ToString("dd.MM.yyyy HH:mm"); } set { } }

        /// <summary>
        /// Light|Dark|Border
        /// </summary>
        public string[] Colors
        {
            get
            {
                return ((eGameType)GameType).GetTournamentColors();
            }
            private set { }
        }

        public string ColorLight { get { return "#" + Colors[0]; } set { } }
        public string ColorDark { get { return "#" + Colors[1]; } set { } }
        public string ColorBorder { get { return "#" + Colors[2]; } set { } }

        public string DateString
        {
            get
            {
                return Date.ToString("dd.MM.yyyy HH:mm");
            }
            private set { }
        }

        public bool Is2itemVisible
        {
            get
            {
                return ((eGameType)GameType).In(eGameType.DoubleChance, eGameType.RebuyLimited, eGameType.RebuyUnlimited, eGameType.TripleChance);
            }
            private set { }
        }

        public bool Is3itemVisible
        {
            get
            {
                return ((eGameType)GameType).In(eGameType.RebuyLimited, eGameType.RebuyUnlimited, eGameType.TripleChance);
            }
            private set { }
        }

        public bool IsChance
        {
            get
            {
                return ((eGameType)GameType).In(eGameType.DoubleChance, eGameType.TripleChance);
            }
            private set { }
        }

        public List<string> ItemsDisplayName
        {
            get
            {
                var x = new List<string>();
                x.Add(IsChance ? "1. chance" : "Buy in");
                x.Add(IsChance ? "2. chance" : "Rebuy");
                x.Add(IsChance ? "3. chance" : "Add-on");

                return x;
            }
            private set { }
        }

        public decimal Bank
        {
            get
            {
                if (Players.IsNotNull() && Players.Any())
                {
                    var bank = 0;
                    foreach (var p in Players)
                    {
                        var a = p.ReEntryCount * BuyInPrize +  BuyInPrize;
                        var b = p.ReBuyCount * RebuyPrize;
                        var c = p.AddOnCount * AddOnPrize;
                        var d = p.SpecialAddOnCount * SpecialAddonPrize;

                        bank = bank + a + b + c + d;
                    }

                    return bank;
                }
                else
                {
                    return 0;
                }
            }
            set
            { }
        }

        public int PlayerCount
        {
            get
            {
                if (Players.IsNotNull() && Players.Any())
                {
                    return Players.Sum(p => p.ReEntryCount) + Players.Count;
                }
                else
                {
                    return 0;
                }
                }
            set
            {

            }
        }
    }

    public partial class sp_get_tournament_reportResult
    {
        public string DateString
        {
            get
            {
                if (Date.IsNotNull())
                    return this.Date.ToString("dd.MM.yyyy HH:mm");
                else
                    return string.Empty;
            }
            private set { }
        }

        public string GameTypeString
        {
            get
            {
                if (GameType.IsNotNull())
                    return ((eGameType)this.GameType).GetDescription();
                else
                    return string.Empty;
            }
            private set { }
        }
    }
}
