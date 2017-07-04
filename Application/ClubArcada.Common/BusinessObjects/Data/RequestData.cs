using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public partial class RequestData
    {
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

        public static List<sp_get_requestsResult> Get(Credentials cr)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.sp_get_requests().ToList();
                
            }
        }
    }
}