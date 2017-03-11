using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class ShiftData
    {
        public static Shift GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Shifts.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Shift Save(Credentials cr, Shift item)
        {
            var shift = GetById(cr, item.Id);

            if (shift.IsNotNull())
            {
                return Update(cr, item);
            }
            else
            {
                return Create(cr, item);
            }
        }

        private static Shift Create(Credentials cr, Shift item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedBy = cr.UserId;

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Shifts.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Shift Update(Credentials cr, Shift user)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var userToUpdate = dc.Shifts.SingleOrDefault(u => u.Id == user.Id);

                userToUpdate.BusinessUnitId = user.BusinessUnitId;
                userToUpdate.Date = user.Date;
                userToUpdate.Duration = user.Duration;
                userToUpdate.Type = user.Type;
                userToUpdate.UserId = user.UserId;

                dc.SubmitChanges();
            }

            return GetById(cr, user.Id);
        }

        public static ShiftDay GetDayShift(Credentials cr, Guid businessUnitId, DateTime date)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var shifts = dc.Shifts.Where(u => u.BusinessUnitId == businessUnitId && u.Date.Date == date.Date).ToList();

                return new ShiftDay()
                {
                    BusinessUnitId = businessUnitId,
                    Date = date,
                    DayShifts = shifts.Where(s => s.IsDay.Value).ToList(),
                    NightShifts = shifts.Where(s => !s.IsDay.Value).ToList()
                };
            }
        }

    }
}
