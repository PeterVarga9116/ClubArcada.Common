using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Jackpot
    {
        public User WinUser { get; set;}

        public double GetAmount()
        {
            return (this.DateStopped.Value - this.DateStarted).TotalSeconds * 0.001;
        }
    }
}
