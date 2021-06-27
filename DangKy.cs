using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLNhanSu
{
    public partial class DangKy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        public DangKy()
        {
            InitializeComponent();
        }
        private void DangKy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Helpers.Define.dataSource);
            connection.Open();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
           
            try
            {
                command = connection.CreateCommand();
                string taiKhoan = txtTaikhoan.Text;
                string matKhau = txtMatkhau.Text;
                command.CommandText = "INSERT INTO DANGNHAP (TaiKhoan, MatKhau) VALUES ('" + taiKhoan + "', '" + matKhau + "')";
                command.ExecuteNonQuery();

                this.Close();
                Helpers.Utilities.GetMainForm().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
