using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSS.Model;
using DSS.Controller;

namespace DSS.GUI
{
    public partial class GLuat : Form
    {
        public GLuat()
        {
            InitializeComponent();
        }

        List<String> IDList = new List<string>();
        private void GLuat_Load(object sender, EventArgs e)
        {
            // Doc toan bo menh de len: Checklistbox, combobox
            CMenhDe cm = new CMenhDe();
            DataTable tbmd = cm.SelectAll();
            if(tbmd != null)
            {
                foreach(DataRow r in tbmd.Rows)
                {
                    clbVeTrai.Items.Add(r["Name"].ToString());
                    IDList.Add(r["ID"].ToString());
                }

                cbbVePhai.DataSource = tbmd;
                cbbVePhai.DisplayMember = "Name";
                cbbVePhai.ValueMember = "ID";
            }

            // Doc toan bo luat len: Datagridview
            DocLuat();
        }

        private void DocLuat()
        {
            CLuat cl = new CLuat();
            List<MLuat> tbl = cl.SelectAllList();
            if(tbl != null)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("ID", typeof(String));
                tb.Columns.Add("TT", typeof(String));
                tb.Columns.Add("Ten", typeof(String));
                tb.Columns.Add("MoTa", typeof(String));
                tb.Columns.Add("VeTrai", typeof(String));
                tb.Columns.Add("VePhai", typeof(String));

                int dem = 0;
                foreach(MLuat m in tbl)
                {
                    dem++;
                    DataRow r = tb.NewRow();
                    r["ID"] = m.ID.ToString();
                    r["TT"] = dem.ToString();
                    r["Ten"] = m.Name;
                    r["MoTa"] = m.Description;
                    List<MChiTietLuat> veTrai = m.ChiTietLuat();
                    if(veTrai != null)
                    {
                        String vt = "";
                        foreach(MChiTietLuat ct in veTrai)
                        {
                            vt += ct.Left().Name + ",";
                        }
                        if (vt.Length > 0)
                            vt = vt.Substring(0, vt.Length - 1);
                        r["VeTrai"] = vt;
                    }
                    r["VePhai"] = m.Right().Name;
                    tb.Rows.Add(r);
                }
                dgvDanhSach.DataSource = tb;
                dgvDanhSach.Columns["ID"].Visible = false;
            }    
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            // Kiem soat nhap du lieu
            if(String.IsNullOrEmpty(tbTenLuat.Text))
            {
                tbTenLuat.Focus();
                MessageBox.Show("Bạn phải nhập tên Luật");
                return;
            }
            if (String.IsNullOrEmpty(tbMoTaLuat.Text))
            {
                tbMoTaLuat.Focus();
                MessageBox.Show("Bạn phải nhập thông tin mô tả Luật");
                return;
            }
            if(clbVeTrai.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn mệnh đề vế trái");
                clbVeTrai.Focus();
                return;
            }

            // Cap nhat vao CSDL
            CLuat cl = new CLuat();
            List<MMenhDe> veTrai = new List<MMenhDe>();
            CMenhDe cmd = new CMenhDe();
            int index = 0;
            for(int i = 0; i < clbVeTrai.Items.Count; i++)
            {
                if(clbVeTrai.GetItemChecked(index))
                {
                    String id = IDList[i];
                    MMenhDe m = cmd.GetByID(id);
                    if (m != null)
                        veTrai.Add(m);
                }
                index++;
            }
            int dem = cl.Insert(tbTenLuat.Text, tbMoTaLuat.Text, int.Parse(cbbVePhai.SelectedValue.ToString()), veTrai);
            if(dem == 1)
            {
                // Load lại du lieu tren giao dien
                DocLuat();
                tbTenLuat.Text = "";
                tbMoTaLuat.Text = "";
                cbbVePhai.SelectedIndex = 0;
                for (int i = 0; i < clbVeTrai.Items.Count; i++)
                    clbVeTrai.SetItemChecked(i, false);
            }    
            else
            {
                MessageBox.Show("Lỗi ...");
            }    
        }

        private void dgvDanhSach_Click(object sender, EventArgs e)
        {
            String id = dgvDanhSach.SelectedRows[0].Cells["ID"].Value.ToString();
            CLuat cl = new CLuat();
            MLuat ml = cl.GetByID(id);
            if (ml != null)
            {
                for (int i = 0; i < clbVeTrai.Items.Count; i++)
                    clbVeTrai.SetItemChecked(i, false);
                tbTenLuat.Text = ml.Name;
                tbMoTaLuat.Text = ml.Description;
                cbbVePhai.SelectedValue = ml.RightID.ToString();
                List<MChiTietLuat> veTrai = ml.ChiTietLuat();
                if(veTrai != null && veTrai.Count > 0)
                {
                    foreach(MChiTietLuat ct in veTrai)
                    {
                        for(int i = 0; i < clbVeTrai.Items.Count; i++)
                        {
                            if(IDList[i].Equals(ct.LeftID.ToString()))
                            {
                                clbVeTrai.SetItemChecked(i, true);
                                break;
                            }
                        }    
                    }    
                }    
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if(dgvDanhSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn dữ liệu cần sửa từ Danh sách luât!");
                return;
            }    

            // Kiem soat nhap du lieu
            if (String.IsNullOrEmpty(tbTenLuat.Text))
            {
                tbTenLuat.Focus();
                MessageBox.Show("Bạn phải nhập tên Luật");
                return;
            }
            if (String.IsNullOrEmpty(tbMoTaLuat.Text))
            {
                tbMoTaLuat.Focus();
                MessageBox.Show("Bạn phải nhập thông tin mô tả Luật");
                return;
            }
            if (clbVeTrai.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn mệnh đề vế trái");
                clbVeTrai.Focus();
                return;
            }

            // Cap nhat vao CSDL
            CLuat cl = new CLuat();
            List<MMenhDe> veTrai = new List<MMenhDe>();
            CMenhDe cmd = new CMenhDe();
            int index = 0;
            for (int i = 0; i < clbVeTrai.Items.Count; i++)
            {
                if (clbVeTrai.GetItemChecked(index))
                {
                    String id = IDList[i];
                    MMenhDe m = cmd.GetByID(id);
                    if (m != null)
                        veTrai.Add(m);
                }
                index++;
            }
            String luatID = dgvDanhSach.SelectedRows[0].Cells["ID"].Value.ToString();
            int dem = cl.Update(int.Parse(luatID), tbTenLuat.Text, tbMoTaLuat.Text, int.Parse(cbbVePhai.SelectedValue.ToString()), veTrai);
            if (dem == 1)
            {
                // Load lại du lieu tren giao dien
                DocLuat();
                tbTenLuat.Text = "";
                tbMoTaLuat.Text = "";
                cbbVePhai.SelectedIndex = 0;
                for (int i = 0; i < clbVeTrai.Items.Count; i++)
                    clbVeTrai.SetItemChecked(i, false);
            }
            else
            {
                MessageBox.Show("Lỗi ...");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn dữ liệu cần sửa từ Danh sách luât!");
                return;
            }
            CLuat cl = new CLuat();
            String luatID = dgvDanhSach.SelectedRows[0].Cells["ID"].Value.ToString();
            int dem = cl.Delete(int.Parse(luatID));
            if(dem == 1)
            {
                DocLuat();
                tbTenLuat.Text = "";
                tbMoTaLuat.Text = "";
                cbbVePhai.SelectedIndex = 0;
                for (int i = 0; i < clbVeTrai.Items.Count; i++)
                    clbVeTrai.SetItemChecked(i, false);
            }    
        }
    }
}
