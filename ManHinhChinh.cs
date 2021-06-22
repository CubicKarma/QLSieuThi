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
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            quanLyNhanVien.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Helper.Utilities.GetMainForm().Show();
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
    }
}
