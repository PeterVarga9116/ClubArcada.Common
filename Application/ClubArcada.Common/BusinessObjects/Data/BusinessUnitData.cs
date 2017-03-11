using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class BusinessUnitData
    {
        public static List<BusinessUnit> GetList(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.BusinessUnits.ToList();
            }
        }

        public static BusinessUnit GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.BusinessUnits.SingleOrDefault(u => u.Id == id);
            }
        }

        public static BusinessUnit Save(Credentials cr, BusinessUnit item)
        {
            var loaded = GetById(cr, item.Id);

            if (loaded.IsNull())
            {
                return Create(cr, item);
            }
            else
            {
                return Update(cr, item);
            }
        }

        private static BusinessUnit Create(Credentials cr, BusinessUnit item)
        {
            item.Id = Guid.NewGuid();
            item.DateCreated = DateTime.Now;

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.BusinessUnits.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static BusinessUnit Update(Credentials cr, BusinessUnit item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.BusinessUnits.SingleOrDefault(u => u.Id == item.Id);

                itemToUpdate.Name = item.Name;
                itemToUpdate.Address = item.Address;
                itemToUpdate.Email = item.Email;
                itemToUpdate.HasCalendar = item.HasCalendar;
                itemToUpdate.Phone = item.Phone;

                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }
    }
}
