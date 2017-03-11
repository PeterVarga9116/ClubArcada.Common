using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Tournament
    {
        public EnumModel GameTypeEnum
        {
            get
            {
                return new EnumModel() { id = (int)GameType, name = ((eGameType)GameType).GetDescription(), property = ((eGameType)GameType).GetGameTypeColor() };
            }
            set
            {
                this.GameType = value.id;
            }
        }
    }
}
