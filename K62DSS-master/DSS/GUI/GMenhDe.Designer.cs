namespace DSS.GUI
{
    partial class GMenhDe
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
            this.tbTen = new System.Windows.Forms.TextBox();
            this.btThemMoi = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.lbDanhSach = new System.Windows.Forms.ListBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên mệnh đề";
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(21, 37);
            this.tbTen.Margin = new System.Windows.Forms.Padding(4);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(364, 26);
            this.tbTen.TabIndex = 1;
            // 
            // btThemMoi
            // 
            this.btThemMoi.Location = new System.Drawing.Point(21, 70);
            this.btThemMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.Size = new System.Drawing.Size(100, 28);
            this.btThemMoi.TabIndex = 2;
            this.btThemMoi.Text = "Thêm mới";
            this.btThemMoi.UseVisualStyleBackColor = true;
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(131, 69);
            this.btLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(100, 28);
            this.btLuu.TabIndex = 3;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // lbDanhSach
            // 
            this.lbDanhSach.FormattingEnabled = true;
            this.lbDanhSach.ItemHeight = 20;
            this.lbDanhSach.Location = new System.Drawing.Point(21, 106);
            this.lbDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.lbDanhSach.Name = "lbDanhSach";
            this.lbDanhSach.Size = new System.Drawing.Size(364, 324);
            this.lbDanhSach.TabIndex = 4;
            this.lbDanhSach.Click += new System.EventHandler(this.lbDanhSach_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(238, 69);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(97, 28);
            this.btXoa.TabIndex = 5;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // GMenhDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 464);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.lbDanhSach);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btThemMoi);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GMenhDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Mệnh đề";
            this.Load += new System.EventHandler(this.GMenhDe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Button btThemMoi;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.ListBox lbDanhSach;
        private System.Windows.Forms.Button btXoa;
    }
}