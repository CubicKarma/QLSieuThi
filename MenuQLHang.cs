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
    public partial class MenuQLHang : Form
    {
        public MenuQLHang()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManHinhChinh manHinhChinh = new ManHinhChinh();
            manHinhChinh.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhapHang nhapHang = new NhapHang();
            nhapHang.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLBanHang banHang = new QLBanHang();
            banHang.ShowDialog();
        }
    }
}
