using ClubArcada.Common.BusinessObjects.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class ShiftData
    {
        public static List<Shift> GetList(Credentials cr, Guid businessUnitId)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Shifts.Where(u => u.BusinessUnitId == businessUnitId).ToList();
            }
        }

        public static List<sp_get_shiftsResult> GetList(Credentials cr, Guid businessUnitId, DateTime from, DateTime to)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_shifts(businessUnitId, from, to).ToList();
            }
        }

        public static ShiftDay GetDayShift(Credentials cr, Guid businessUnitId, DateTime date)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var shifts = dc.Shifts.Where(u => u.BusinessUnitId == businessUnitId && u.StartDate.Date == date.Date).ToList();

                foreach (var s in shifts)
                {
                    s.User = UserData.GetById(cr, s.UserId).Item;
                }

                var shiftDay = new ShiftDay()
                {
                    BusinessUnitId = businessUnitId,
                    Date = date,
                    DayShifts = shifts.Where(s => s.IsDay.Value).ToList(),
                    NightShifts = shifts.Where(s => !s.IsDay.Value).ToList()
                };

                if (shiftDay.DayShifts == null)
                    shiftDay.DayShifts = new List<Shift>();

                if (shiftDay.NightShifts == null)
                    shiftDay.NightShifts = new List<Shift>();

                return shiftDay;
            }
        }

        public static ShiftDay SaveDayShift(Credentials cr, ShiftDay item)
        {
            foreach (var i in item.DayShifts)
            {
                i.BusinessUnitId = item.BusinessUnitId;
                i.StartDate = item.Date;
                i.IsDay = true;
                i.CreatedByUserId = cr.UserId;
                i.UserId = i.User.Id;
                Save(cr, i);
            }
            foreach (var i in item.NightShifts)
            {
                i.BusinessUnitId = item.BusinessUnitId;
                i.StartDate = item.Date;
                i.IsDay = false;
                i.CreatedByUserId = cr.UserId;
                i.UserId = i.User.Id;
                Save(cr, i);
            }

            return GetDayShift(cr, item.BusinessUnitId, item.Date);
        }

    }
}
