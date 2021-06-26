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
    public partial class QuanLyNhanVien : Form
    {
        //Help ref
        Form helpf;
        //Ket noi SQL
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader sqlReader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        //Datasourse (khac nhau)

        DataTable table = new DataTable();

        //demo datagridview trong form QuanLyNhanvien.cs
        void loadData()
        {
            //Thiet lap input listener
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);

            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Helper.Define.dataSource);
            connection.Open();
            loadData();
        }

        private void lblTenNv_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNv_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLuong_Click(object sender, EventArgs e)
        {

        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaNv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtGioiTinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dtpNgaySinh.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from HOADON where id_Nv ='" + txtMaNv.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from NHANVIEN where id_Nv ='" + txtMaNv.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
        //gọi sự kiện đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Chuyển về form đăng nhập rồi mới tắt form để app đc terminate
            Helper.Utilities.GetMainForm().Show();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Helper.Define.dataSource);

            connection.Open();

            string sql = "select * from NHANVIEN where id_Nv = '" + txtMaNv.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {

                MessageBox.Show(" Trùng mã nhân viên! Mời Nhập lại");
            }
            else
            {
                if (txtMaNv.Text != null)
                {
                    dta.Close();
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into NHANVIEN values('" + txtMaNv.Text + "', N'" + txtTenNv.Text + "', N'" + txtGioiTinh.Text + "', N'" + txtDiachi.Text + "', N'" + txtSdt.Text + "', N'" + dtpNgaySinh.Text + "')";
                    command.ExecuteNonQuery();
                    loadData();
                }

            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtMaNv.Text = "";
            txtTenNv.Text = "";
            txtGioiTinh.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
            dtpNgaySinh.Text = "1/1/1900";
            txtSearch.Text = "";
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update NHANVIEN set id_Nv='" + txtMaNv.Text + "', ten_Nv = N'" + txtTenNv.Text + "', gioiTinh_Nv= N'" + txtGioiTinh.Text + "', diaChi_Nv= N'" + txtDiachi.Text + "', sdt_Nv= N'" + txtSdt.Text + "', dob_Nv= N'" + dtpNgaySinh.Text + "' where id_Nv='"+txtMaNv.Text+"' ";
            command.ExecuteNonQuery();
            loadData();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            // tìm kiếm theo tên nhân viên
            SqlConnection connection = new SqlConnection(Helper.Define.dataSource);
            connection.Open();
            string tenNV = txtSearch.Text;
            string sql = "select ten_Nv from NHANVIEN where ten_Nv = '" + txtSearch.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader data = cmd.ExecuteReader();

            if (data.Read() == true)
            {
                data.Close();
                command = connection.CreateCommand();
                command.CommandText = "select * from NHANVIEN where ten_Nv='" + txtSearch.Text + "'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show("Không có giáo viên cần tìm!");
            }
        }

        //input listener
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                CreateHelpForm();
            }
        }

        private void CreateHelpForm()
        {
            if (helpf == null)
            {
                Helper.Helper helper = new Helper.Helper();
                helper.ShowDialog();
                helpf = helper;
            }
        }

        private void helpBTN_Click(object sender, EventArgs e)
        {
            CreateHelpForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManHinhChinh manHinhChinh = new ManHinhChinh();
            manHinhChinh.ShowDialog();
        }
    }
}