using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Banner
    {

    }

    public class BannerLight
    {
        public BannerLight(Banner banner)
        {
            Sort = banner.SortNumber;
            Data = Convert.ToBase64String(banner.Data.ToArray());
        }

        public double Sort { get; set; }

        public string Data { get; set; }
    }
}
