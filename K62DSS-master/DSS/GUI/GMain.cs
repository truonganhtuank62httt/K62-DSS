using DSS.Controller;
using DSS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSS.GUI
{
    public partial class GMain : Form
    {
        public GMain()
        {
            InitializeComponent();
        }

        private void mệnhĐềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GMenhDe md = new GMenhDe();
            md.ShowDialog();
        }

        private void luậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GLuat l = new GLuat();
            l.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GMenhDe md = new GMenhDe();
            md.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GLuat l = new GLuat();
            l.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        List<String> dsMenhDe = new List<String>();
        private void GMain_Load(object sender, EventArgs e)
        {
            CMenhDe cmd = new CMenhDe();
            List<MMenhDe> ds = cmd.SelectAllList();
            if(ds != null && ds.Count > 0)
            {
                foreach(MMenhDe m in ds)
                {                    
                    clbMenhDe.Items.Add(m.Name);
                    dsMenhDe.Add(m.ID.ToString());
                }    
            }    
        }

        private void btSuyLuan_Click(object sender, EventArgs e)
        {
            // Kiem tra xem nguoi dung da chon cac menh de hay chua, toi thieu 1 menh de
            if(clbMenhDe.CheckedItems.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn tối thiểu 1 mệnh đề!");
                clbMenhDe.Focus();
                return;
            }

            // Doc danh sach luat
            CLuat cl = new CLuat();
            List<MLuat> tapLuat = cl.SelectAllList();

            // Doc tap su kien da biet
            List<MMenhDe> tapSKDB = new List<MMenhDe>();
            CMenhDe cmd = new CMenhDe();
            for(int i = 0; i < clbMenhDe.Items.Count; i++)
            {
                if(clbMenhDe.GetItemChecked(i))
                {
                    MMenhDe m = cmd.GetByID(dsMenhDe[i]);
                    tapSKDB.Add(m);
                }    
            }    

            // Dung mo to suy dien de suy luan
            Motor mt = new Motor();
            mt.TLuat = tapLuat;
            mt.TSKDB = tapSKDB;
            List<MMenhDe> dsKetQua = mt.Search();
            List<MLuat> tapLuat2 = cl.SelectAllList();
            // Dien giai ket qua
            if (dsKetQua != null && dsKetQua.Count > 0)
            {
                tbKetQua.Text = "Kết quả thu được:\r\n";
                foreach(MMenhDe md in dsKetQua)
                {
                    tbKetQua.AppendText(md.Name + "\r\n");
                    int searchIndex = tapLuat2.FindIndex(item => item.RightID == md.ID);
                    tbKetQua.AppendText("\n" + tapLuat2[searchIndex].Description+"\n");
                }
            }
            else
            {
                tbKetQua.Text = "Không tìm được kết quả nào phù hợp";
            }    
        }
    }
}
