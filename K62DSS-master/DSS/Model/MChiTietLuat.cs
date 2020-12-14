using DSS.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSS.Model
{
    public class MChiTietLuat
    {
        public int ID { get; set; }
        public int RuleID { get; set; }
        public int LeftID { get; set; }

        public MLuat Luat()
        {
            CLuat cLuat = new CLuat();
            return cLuat.GetByID(RuleID.ToString());
        }

        public MMenhDe Left()
        {
            CMenhDe cMenhDe = new CMenhDe();
            return cMenhDe.GetByID(LeftID.ToString());
        }
    }
}
