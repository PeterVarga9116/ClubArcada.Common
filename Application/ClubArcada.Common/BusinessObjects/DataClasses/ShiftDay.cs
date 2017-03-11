using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class ShiftDay
    {
        public List<Shift> DayShifts { get; set; }

        public List<Shift> NightShifts { get; set; }

        public Guid BusinessUnitId { get; set; }

        public DateTime Date { get; set; }
    }
}
