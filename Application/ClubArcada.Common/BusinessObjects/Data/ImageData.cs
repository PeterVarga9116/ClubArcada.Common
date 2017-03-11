using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.Data
{
    public class ImageData
    {
        public static Image GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Images.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Image Save(Credentials cr, Image item)
        {
            item.Id = Guid.NewGuid();

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Images.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }
    }
}
