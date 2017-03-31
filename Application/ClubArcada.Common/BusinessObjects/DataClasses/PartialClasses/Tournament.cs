using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<TournamentPlayerLight> Players { get; set; }
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
