using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class RequestData
    {
        public static Request Create(Credentials cr, Request item)
        {
            item.DateCreated = DateTime.Now;
            item.Id = Guid.NewGuid();
            item.UserId = cr.UserId;

            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                dc.Requests.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return item;
        }

        public static List<sp_get_requestsResult> GetList(Credentials cr)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                return dc.sp_get_requests().ToList();
            }
        }

        public static void SetResolved(Credentials cr, Guid id)
        {
            using (var dc = new CADBDataContext(cr.ConnectionString))
            {
                var toUpdate = dc.Requests.SingleOrDefault(r => r.Id == id);
                toUpdate.Status = 1;
                toUpdate.DateCompleted = DateTime.Now;
                toUpdate.AssignedTo = cr.UserId;
                dc.SubmitChanges();
            }
        }
    }
}