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
            if (item.DateCreated.IsNull())
            {
                item.DateCreated = DateTime.Now;
            }

            if(item.UserId.IsEmpty())
            {
                item.UserId = cr.UserId;
            }

            if (item.Id.IsEmpty())
            {
                item.UserId = cr.UserId;
            }

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Requests.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return item;
        }

        public static List<sp_get_requestsResult> GetList(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_requests().ToList();
            }
        }

        public static void SetResolved(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
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