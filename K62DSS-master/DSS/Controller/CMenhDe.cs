using DSS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DSS.Controller
{
    public class CMenhDe
    {
        String tableName = "tbMenhDe";
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

        public List<MMenhDe> SelectAllList()
        {
            DataTable tb = SelectAll();
            if (tb != null)
            {
                List<MMenhDe> ds = new List<MMenhDe>();
                foreach (DataRow r in tb.Rows)
                {
                    MMenhDe m = new MMenhDe();
                    m.ID = int.Parse(r["ID"].ToString());
                    m.Name = r["Name"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }

        public List<MMenhDe> SelectAllList(String condition)
        {
            DataTable tb = SelectAll(condition);
            if (tb != null)
            {
                List<MMenhDe> ds = new List<MMenhDe>();
                foreach (DataRow r in tb.Rows)
                {
                    MMenhDe m = new MMenhDe();
                    m.ID = int.Parse(r["ID"].ToString());
                    m.Name = r["Name"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }

        public MMenhDe GetByID(String id)
        {
            List<MMenhDe> ds = SelectAllList("ID=" + id);
            if (ds != null && ds.Count > 0)
                return ds[0];
            else
                return null;
        }

        public Boolean Exist(String name)
        {
            DataTable tb = SelectAll("Name=N'" + name + "'");
            if (tb == null)
                return false;
            else
                return true;
        }

        public Boolean ExistExceptID(String name, String id)
        {
            DataTable tb = SelectAll("Name=N'" + name + "' And ID !=" + id);
            if (tb == null)
                return false;
            else
                return true;
        }


        public Boolean CanDelete(String id)
        {
            CLuat cLuat = new CLuat();
            if (cLuat.ExitRight(id))
                return false;
            CChiTietLuat cChiTietLuat = new CChiTietLuat();
            if (cChiTietLuat.ExistLeft(id))
                return false;
            return true;
        }

        public int Insert(String name)
        {
            if (!Exist(name))
            {
                String query = "Insert Into " + tableName + "(Name) Values(N'"
                    + name + "')";
                return da.Write(query);
            }
            else
                return 0;
        }

        public int Insert(MMenhDe menhDe)
        {
            if (!Exist(menhDe.Name))
            {
                String query = "Insert Into " + tableName + "(Name) Values(N'"
                    + menhDe.Name + "')";
                return da.Write(query);
            }
            else
                return 0;
        }

        public int Update(int id, String name)
        {
            String query = "Update " + tableName + " Set Name=N'"
                + name + "' Where ID=" + id;
            return da.Write(query);
        }

        public int Update(MMenhDe menhDe)
        {
            String query = "Update " + tableName + " Set Name=N'"
                + menhDe.Name + "' Where ID=" + menhDe.ID;
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
