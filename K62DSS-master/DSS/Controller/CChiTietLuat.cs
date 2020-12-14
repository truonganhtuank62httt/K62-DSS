using DSS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DSS.Controller
{
    public class CChiTietLuat
    {
        String tableName = "tbChiTietLuat";
        String columnsName = "ID, Name";
        MyDataAccess da = new MyDataAccess();

        public DataTable SelectAll()
        {
            String query = "Select * From " + tableName;
            return da.Read(query);
        }

        public DataTable SelectAll(String condition)
        {
            String query = "Select * From " + tableName;
            if (condition.Length > 0)
                query += " Where " + condition;
            return da.Read(query);
        }

        public List<MChiTietLuat> SelectAllList()
        {
            DataTable tb = SelectAll();
            if (tb != null)
            {
                List<MChiTietLuat> ds = new List<MChiTietLuat>();
                foreach (DataRow r in tb.Rows)
                {
                    MChiTietLuat m = new MChiTietLuat();
                    m.ID = int.Parse(r["ID"].ToString());
                    m.RuleID = int.Parse(r["RuleID"].ToString());
                    m.LeftID = int.Parse(r["LeftID"].ToString());
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }

        public List<MChiTietLuat> SelectAllList(String condition)
        {
            DataTable tb = SelectAll(condition);
            if (tb != null)
            {
                List<MChiTietLuat> ds = new List<MChiTietLuat>();
                foreach (DataRow r in tb.Rows)
                {
                    MChiTietLuat m = new MChiTietLuat();
                    m.ID = int.Parse(r["ID"].ToString());
                    m.RuleID = int.Parse(r["RuleID"].ToString());
                    m.LeftID = int.Parse(r["LeftID"].ToString());
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }


        public MChiTietLuat GetByID(String id)
        {
            List<MChiTietLuat> ds = SelectAllList("ID=" + id);
            if (ds != null && ds.Count > 0)
                return ds[0];
            else
                return null;
        }


        public Boolean Exist(int luatID, int leftID)
        {
            DataTable tb = SelectAll("RuleID=" + luatID.ToString() 
                + " And LeftID=" + leftID.ToString());
            if (tb == null)
                return false;
            else
                return true;
        }

        public Boolean ExistLeft(String leftID)
        {
            DataTable tb = SelectAll("LeftID=" + leftID);
            if (tb == null)
                return false;
            else
                return true;
        }

        public int Insert(int luatID, int leftID)
        {
            if (!Exist(luatID, leftID))
            {
                String query = "Insert Into " + tableName + "(RuleID, LeftID) Values("
                    + luatID.ToString() + "," + leftID.ToString() + ")";
                return da.Write(query);
            }
            else
                return 0;
        }

        public int Insert(MChiTietLuat chiTietLuat)
        {
            if (!Exist(chiTietLuat.RuleID, chiTietLuat.LeftID))
            {
                String query = "Insert Into " + tableName + "(RuleID, LeftID) Values("
                    + chiTietLuat.RuleID.ToString() + ","
                    + chiTietLuat.LeftID.ToString() + ")";
                return da.Write(query);
            }
            else
                return 0;
        }

        public int Update(int id, int luatID, int leftID)
        {
            String query = "Update " + tableName + " Set RuleID="
                + luatID.ToString() + ","
                + leftID.ToString() + " Where ID=" + id;
            return da.Write(query);
        }

        public int Update(MChiTietLuat chiTietLuat)
        {
            String query = "Update " + tableName + " Set RuleID="
                + chiTietLuat.RuleID.ToString() + ","
                + chiTietLuat.LeftID.ToString() + " Where ID=" + chiTietLuat.ID;
            return da.Write(query);
        }

        public int Delete(int id)
        {
            String query = "Delete " + tableName + " Where ID=" + id;
            return da.Write(query);
        }

        public int Delete(String condition)
        {
            String query = "Delete " + tableName + " Where " + condition;
            return da.Write(query);
        }
    }
}
