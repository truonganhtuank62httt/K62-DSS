using DSS.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSS.Model
{
    public class MLuat
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int RightID { get; set; }

        public MMenhDe Right()
        {
            CMenhDe cMenhDe = new CMenhDe();
            return cMenhDe.GetByID(RightID.ToString());
        }

        public List<MChiTietLuat> ChiTietLuat()
        {
            CChiTietLuat cChiTietLuat = new CChiTietLuat();
            return cChiTietLuat.SelectAllList("RuleID=" + ID.ToString());
        }
    }
}
