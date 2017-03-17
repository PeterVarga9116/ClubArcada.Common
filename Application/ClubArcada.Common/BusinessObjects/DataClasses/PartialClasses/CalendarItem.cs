using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class CalendarItem
    {
        public static CalendarItem New(DateTime date, string title, Guid id, string color)
        {
            return new CalendarItem()
            {
                id = id,
                title = title,
                start = date,
                color = color
            };
        }

        public Guid id { get; set; }

        public string title { get; set; }

        public DateTime start { get; set; }

        public string color { get; set; }
    }
}
