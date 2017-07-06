using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class CashPlayer : INotifyPropertyChanged
    {
        public System.Timers.Timer Timer = new System.Timers.Timer();

        private int _playSeconds = 0;

        public string PlayPauseButtonContent { get { return IsRunning ? "PAUSE" : "START"; } }

        public string PlayTimeDisplayName { get { return string.Format("Playtime: {0:00}:{1:00}:{2:00} | Points: {3}", TimeSpan.FromSeconds(_playSeconds).Hours, TimeSpan.FromSeconds(_playSeconds).Minutes, TimeSpan.FromSeconds(_playSeconds).Seconds, this.Points); } }

        public bool IsRunning { get { return StateEnum.In(eCashPlayerState.Running); } }

        public bool IsPaused { get { return StateEnum.In(eCashPlayerState.Paused); } }

        public bool IsStopped { get { return StateEnum.In(eCashPlayerState.NotSet); } }

        public Visibility IsRunningTextVisible { get { return IsRunning ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility IsPausedTextVisible { get { return IsRunning ? Visibility.Collapsed : Visibility.Visible; } }

        public CashPlayer New(Guid adminUserId, Guid cashTableId, Guid userId)
        {
            Timer.Elapsed += Timer_Elapsed;
            Timer.Interval = 1000;
            Timer.Enabled = false;
            Timer.Start();
            SetPaused();

            return new CashPlayer()
            {
                CreatedByUserId = adminUserId,
                CashGameId = Guid.NewGuid(),
                CashOuts = new System.Data.Linq.EntitySet<CashOut>(),
                CashIns = new System.Data.Linq.EntitySet<CashIn>(),
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid(),
                StartTime = DateTime.Now,
                StateEnum = eCashPlayerState.Running,
                CashTableId = cashTableId,
                UserId = userId,
            };
        }

        public void Refresh()
        {
            PropertyChanged.Raise(() => PlayTimeDisplayName);
            PropertyChanged.Raise(() => Points);
            PropertyChanged.Raise(() => IsRunning);
            PropertyChanged.Raise(() => IsPaused);
            PropertyChanged.Raise(() => IsStopped);
            PropertyChanged.Raise(() => StateEnum);
            PropertyChanged.Raise(() => PlayPauseButtonContent);
            PropertyChanged.Raise(() => IsRunningTextVisible);
            PropertyChanged.Raise(() => IsPausedTextVisible);
        }

        public void ToogleRunning()
        {
            if(IsRunning)
            {
                SetPaused();
            }
            else
            {
                SetRunning();
            }
        }

        public void SetRunning()
        {
            State = (int)eCashPlayerState.Running;
            Timer.Enabled = true;
            Refresh();
        }

        public void SetStopped()
        {
            State = (int)eCashPlayerState.NotSet;
            Timer.Enabled = false;
            Refresh();
        }

        public void SetPaused()
        {
            State = (int)eCashPlayerState.Paused;
            Timer.Enabled = false;
            Refresh();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _playSeconds = _playSeconds + 1;
            Points = (int)TimeSpan.FromSeconds(_playSeconds).TotalMinutes;
            Refresh();
        }

        public eCashPlayerState StateEnum
        {
            get
            {
                if (State == 0)
                {
                    return eCashPlayerState.NotSet;
                }
                else if (State == 1)
                {
                    return eCashPlayerState.Running;
                }
                else if (State == 2)
                {
                    return eCashPlayerState.Paused;
                }
                else
                {
                    throw new NotImplementedException("Sate");
                }
            }
            set
            {
                State = (int)value;
                Refresh();
            }
        }
    }
}
