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
    public partial class GMenhDe : Form
    {
        public GMenhDe()
        {
            InitializeComponent();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbTen.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập tên mệnh đề!");
                tbTen.Focus();
                return;
            }

            CMenhDe cMenhDe = new CMenhDe();
            if (!cMenhDe.Exist(tbTen.Text.Trim()))
            {
                cMenhDe.Insert(tbTen.Text.Trim());
            }
            else
            {
                MessageBox.Show("Mệnh đề này đã có trong CSDL");
                return;
            }    
            tbTen.Text = "";
            tbTen.Focus();

            LoadMenhDe();
        }

        private void LoadMenhDe()
        {
            CMenhDe cMenhDe = new CMenhDe();
            DataTable tb = cMenhDe.SelectAll();
            lbDanhSach.DataSource = tb;
            lbDanhSach.DisplayMember = "Name";
            lbDanhSach.ValueMember = "ID";            
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if(lbDanhSach.SelectedItem == null)
            {
                MessageBox.Show("Bạn phải chọn Mệnh đề cần sửa trong Danh sách");
                return;
            }

            if (String.IsNullOrEmpty(tbTen.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập tên mệnh đề!");
                tbTen.Focus();
                return;
            }

            CMenhDe cMenhDe = new CMenhDe();
            MMenhDe menhDe = cMenhDe.GetByID(lbDanhSach.SelectedValue.ToString());
            menhDe.Name = tbTen.Text.Trim();
            if (!cMenhDe.ExistExceptID(menhDe.Name, menhDe.ID.ToString()))
            {
                cMenhDe.Update(menhDe);
            }
            else
            {
                MessageBox.Show("Tên mệnh đề bạn đã sửa trùng với tên của mệnh đề khác trong CSDL! Hãy chọn tên khác");
                tbTen.Focus();
                return;
            }    
            
            tbTen.Text = "";
            tbTen.Focus();

            LoadMenhDe();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (lbDanhSach.SelectedItem == null)
            {
                MessageBox.Show("Bạn phải chọn Mệnh đề cần Xóa trong Danh sách");
                return;
            }

            CMenhDe cMenhDe = new CMenhDe();
            if (cMenhDe.CanDelete(lbDanhSach.SelectedValue.ToString()))
            {
                cMenhDe.Delete(int.Parse(lbDanhSach.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa Mệnh đề này vì có Luật liên quan");
                return;
            }    

            tbTen.Text = "";
            tbTen.Focus();

            LoadMenhDe();
        }

        private void GMenhDe_Load(object sender, EventArgs e)
        {
            LoadMenhDe();
        }

        private void lbDanhSach_Click(object sender, EventArgs e)
        {
            tbTen.Text = lbDanhSach.Text;
        }
    }
}
