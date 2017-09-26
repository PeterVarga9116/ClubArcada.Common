using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class CashTable
    {
        public static CashTable New(Guid cashGameId, Guid userId, string name, eCashTableGameType gameType)
        {
            var cashTable = new CashTable()
            {
                Id = Guid.NewGuid(),
                CashPlayers = new ObservableCollection<CashPlayer>(),
                DateCreated = DateTime.Now,
                CashGameId = cashGameId,
                CreatedByUserId = userId,
                Name = name,
                GameTypeEnum = gameType
            };

            cashTable.CashPlayers.CollectionChanged += delegate 
            {
                cashTable.Refresh();
            };

            return cashTable;
        }

        public void Close()
        {
            DateClosed = DateTime.Now;
            PropertyChanged.Raise(() => IsClosed);
        }

        public void Refresh()
        {
            PropertyChanged.Raise(() => CashPlayers);
            PropertyChanged.Raise(() => DisplayName);
        }

        public bool IsClosed { get { return DateClosed.HasValue; } }

        public eCashTableGameType GameTypeEnum
        {
            get
            {
                return (eCashTableGameType)GameType;
            }
            set
            {
                GameType = (int)value;
            }
        }

        public string DisplayName
        {
            get
            {
                return string.Format("Table #{0} | {1} | {2}", Name, GameTypeEnum.GetDescription(), IsRunning ? "Running" : "Paused");
            }
            private set
            {

            }
        }

        public override string ToString()
        {
            return string.Format("Table #{0} | {1} | {2}", Name, GameTypeEnum.GetDescription(), IsRunning ? "Running" : "Paused");
        }

        private ObservableCollection<CashPlayer> _cashPlayers;
        public ObservableCollection<CashPlayer> CashPlayers
        {
            get
            {
                return _cashPlayers;
            }
            set
            {
                _cashPlayers = value;
                PropertyChanged.Raise(() => CashPlayers);
            }
        }


    }
}
