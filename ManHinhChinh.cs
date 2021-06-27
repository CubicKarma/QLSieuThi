using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            quanLyNhanVien.ShowDialog();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                var helperDialog = new Helpers.Helper();
                helperDialog.ShowDialog();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Helpers.Utilities.GetMainForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLKhachHang quanLyKhachHang = new QLKhachHang();
            quanLyKhachHang.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQLHang menuHang = new MenuQLHang();
            menuHang.ShowDialog();
        }

        private void helpBTN_Click(object sender, EventArgs e)
        {
            var helperDialog = new Helpers.Helper();
            helperDialog.ShowDialog();
        }
    }
}
