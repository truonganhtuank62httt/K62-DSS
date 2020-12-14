namespace DSS.GUI
{
    partial class GLuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.clbVeTrai = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbVePhai = new System.Windows.Forms.ComboBox();
            this.btThemMoi = new System.Windows.Forms.Button();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTenLuat = new System.Windows.Forms.TextBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.tbMoTaLuat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mô tả luật";
            // 
            // clbVeTrai
            // 
            this.clbVeTrai.CheckOnClick = true;
            this.clbVeTrai.FormattingEnabled = true;
            this.clbVeTrai.Location = new System.Drawing.Point(12, 244);
            this.clbVeTrai.Name = "clbVeTrai";
            this.clbVeTrai.Size = new System.Drawing.Size(329, 214);
            this.clbVeTrai.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vế phải";
            // 
            // cbbVePhai
            // 
            this.cbbVePhai.FormattingEnabled = true;
            this.cbbVePhai.Location = new System.Drawing.Point(12, 488);
            this.cbbVePhai.Name = "cbbVePhai";
            this.cbbVePhai.Size = new System.Drawing.Size(329, 28);
            this.cbbVePhai.TabIndex = 3;
            // 
            // btThemMoi
            // 
            this.btThemMoi.Location = new System.Drawing.Point(12, 519);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(95, 24);
            this.btThemMoi.TabIndex = 4;
            this.btThemMoi.Text = "Thêm mới";
            this.btThemMoi.UseVisualStyleBackColor = true;
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // btCapNhat
            // 
            this.btCapNhat.Location = new System.Drawing.Point(128, 519);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(95, 24);
            this.btCapNhat.TabIndex = 5;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(246, 519);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(95, 24);
            this.btXoa.TabIndex = 6;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên luật";
            // 
            // tbTenLuat
            // 
            this.tbTenLuat.Location = new System.Drawing.Point(15, 34);
            this.tbTenLuat.Name = "tbTenLuat";
            this.tbTenLuat.Size = new System.Drawing.Size(326, 26);
            this.tbTenLuat.TabIndex = 8;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(362, 13);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(693, 528);
            this.dgvDanhSach.TabIndex = 9;
            this.dgvDanhSach.Click += new System.EventHandler(this.dgvDanhSach_Click);
            // 
            // tbMoTaLuat
            // 
            this.tbMoTaLuat.Location = new System.Drawing.Point(15, 81);
            this.tbMoTaLuat.Multiline = true;
            this.tbMoTaLuat.Name = "tbMoTaLuat";
            this.tbMoTaLuat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMoTaLuat.Size = new System.Drawing.Size(326, 130);
            this.tbMoTaLuat.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Vế trái";
            // 
            // GLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMoTaLuat);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.tbTenLuat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btCapNhat);
            this.Controls.Add(this.btThemMoi);
            this.Controls.Add(this.cbbVePhai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbVeTrai);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GLuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý luật";
            this.Load += new System.EventHandler(this.GLuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbVeTrai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbVePhai;
        private System.Windows.Forms.Button btThemMoi;
        private System.Windows.Forms.Button btCapNhat;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTenLuat;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.TextBox tbMoTaLuat;
        private System.Windows.Forms.Label label4;
    }
}