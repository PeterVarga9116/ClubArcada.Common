using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class CashPlayer : INotifyPropertyChanged
    {
        public List<CashIn> CashInList { get; set; }
        public List<CashIn> CashOutList { get; set; }

        public System.Timers.Timer Timer = new System.Timers.Timer();

        private int _playSeconds = 0;

        public string PlayPauseButtonContent { get { return IsRunning ? "PAUSE" : "START"; } }

        public string PlayTimeDisplayName { get { return string.Format("Playtime: {0:00}:{1:00}:{2:00} | Points: {3}", TimeSpan.FromSeconds(_playSeconds).Hours, TimeSpan.FromSeconds(_playSeconds).Minutes, TimeSpan.FromSeconds(_playSeconds).Seconds, this.Points); } }

        public bool IsRunning { get { return StateEnum.In(eCashPlayerState.Running); } }
        public bool IsPaused { get { return StateEnum.In(eCashPlayerState.Paused); } }
        public bool IsStopped { get { return StateEnum.In(eCashPlayerState.NotSet); } }

        public bool IsPlayPauseButtonEnabled { get { return !IsStopped; } }
        public bool IsTransferButtonEnabled { get { return !IsStopped; } }
        public bool IsBonusButtonEnabled { get { return !IsStopped; } }
        public bool IsCashOutButtonEnabled { get { return !IsStopped; } }

        public Visibility IsRunningTextVisible { get { return !IsStopped && IsRunning ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility IsPausedTextVisible { get { return !IsStopped && IsPaused ? Visibility.Visible : Visibility.Collapsed; } }

        public CashPlayer(Guid cashGameId, Guid cashTableId, Guid userId) : this()
        {
            CashGameId = cashGameId;
            CashTableId = cashTableId;
            UserId = userId;

            CashInList = new List<DataClasses.CashIn>();
            CashOutList = new List<DataClasses.CashIn>();

            StartTime = DateTime.Now;
            StateEnum = eCashPlayerState.Running;

            Timer.Elapsed += Timer_Elapsed;
            Timer.Interval = 1000;
            Timer.Enabled = false;
            Timer.Start();
            SetPaused();
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

            PropertyChanged.Raise(() => IsPlayPauseButtonEnabled);
            PropertyChanged.Raise(() => IsTransferButtonEnabled);
            PropertyChanged.Raise(() => IsBonusButtonEnabled);
            PropertyChanged.Raise(() => IsCashOutButtonEnabled);
        }

        public void ToogleRunning()
        {
            if (IsRunning)
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

        #region Events

        public event EventHandler Transfer;
        private void _transfer()
        {
            if (Transfer.IsNotNull())
                Transfer(this, EventArgs.Empty);
        }
        private ICommand _btnTransferClick;
        public ICommand btnTransferClick
        {
            get
            {
                return _btnTransferClick ?? (_btnTransferClick = new CommandHandler(() => _transfer(), true));
            }
        }

        public event EventHandler PlayPause;
        public void _playPause()
        {
            if (PlayPause.IsNotNull())
                PlayPause(this, EventArgs.Empty);
        }
        private ICommand _btnTooglePlayPauseClick;
        public ICommand btnTooglePlayPauseClick
        {
            get
            {
                return _btnTooglePlayPauseClick ?? (_btnTooglePlayPauseClick = new CommandHandler(() => _playPause(), true));
            }
        }

        public event EventHandler CashIn;
        private void _cashIn()
        {
            if (CashIn.IsNotNull())
                CashIn(this, EventArgs.Empty);
        }
        private ICommand _btnCashInClick;
        public ICommand btnCashInClick
        {
            get
            {
                return _btnCashInClick ?? (_btnCashInClick = new CommandHandler(() => _cashIn(), true));
            }
        }

        public event EventHandler CashOut;
        private void _cashOut()
        {
            if (CashOut.IsNotNull())
                CashOut(this, EventArgs.Empty);
        }
        private ICommand _btnCashOutClick;
        public ICommand btnCashOutClick
        {
            get
            {
                return _btnCashOutClick ?? (_btnCashOutClick = new CommandHandler(() => _cashOut(), true));
            }
        }

        public event EventHandler Bonus;
        private void _bonus()
        {
            if (Bonus.IsNotNull())
                Bonus(this, EventArgs.Empty);
        }
        private ICommand _btnBonusClick;
        public ICommand btnBonusClick
        {
            get
            {
                return _btnBonusClick ?? (_btnBonusClick = new CommandHandler(() => _bonus(), true));
            }
        }

        #endregion
    }
}
