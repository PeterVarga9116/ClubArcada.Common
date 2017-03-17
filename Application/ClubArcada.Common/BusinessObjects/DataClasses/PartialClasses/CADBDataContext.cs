using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class CADBDataContext
    {
        public static CADBDataContext New(string cs)
        {
            var context = new CADBDataContext(cs);
            context.DeferredLoadingEnabled = false;
            return context;

            string ss = "sgsgsdfies";

            string s = ss.EndsWith("ies") ? ss.Remove(ss.Length, 1) : ss;
        }
    }
}
