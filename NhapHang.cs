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
    public partial class NhapHang : Form
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
            command = connection.CreateCommand();
            command.CommandText = "select * from HANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public NhapHang()
        {
            InitializeComponent();
        }

        private void lblTenNv_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaHang.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenHang.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtDonGiaNhap.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtDonGiaBan.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Helpers.Define.dataSource);
            connection.Open();
            loadData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQLHang menuQlHang = new MenuQLHang();
            menuQlHang.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from HANGNHAP";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Helpers.Define.dataSource);

            connection.Open();

            string sql = "select * from HANG where id_Hang = '" + txtMaHang.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {

                MessageBox.Show(" Trùng Mã hàng! Mời Nhập lại");
            }
            else
            {
                dta.Close();
                command = connection.CreateCommand();
                command.CommandText = "Insert into HANG values('" + txtMaHang.Text + "', N'" + txtTenHang.Text + "','" + txtSoLuong.Text + "','" + txtDonGiaNhap.Text + "','" + txtDonGiaBan.Text + "')";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "Insert into HANG values('" + txtMaHang.Text + "', N'" + txtTenHang.Text + "','" + txtSoLuong.Text + "','" + txtDonGiaNhap.Text + "')";
                command.ExecuteNonQuery();
                loadData();
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtSearch.Text = "";
            loadData();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from HANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //kiểm tra điều kiện combobox đang tìm theo gì, trong combobox hiện đang có tìm theo mã hàng, tên hàng và số lượng

            SqlConnection connection = new SqlConnection(Helpers.Define.dataSource);
            connection.Open();
            //kiểm tra điều kiện combobox đang tìm theo gì, trong combobox hiện đang có tìm theo mã hàng, tên hàng và số lượng
            if (cbxTimTheo.Text == "Mã hàng")
            {
                if (txtSearch.Text.Trim() != "")
                {
                    string sql = "select * from Hang where id_Hang = '" + txtSearch.Text + "'";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    if (sqlReader.Read() == true)
                    {

                        sqlReader.Close();
                        command = connection.CreateCommand();
                        command.CommandText = "select * from Hang where id_Hang='" + txtSearch.Text + "'";
                        adapter.SelectCommand = command;
                        table.Clear();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table; ;
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin tìm kiếm hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (cbxTimTheo.Text == "Tên hàng")
            {


                if (txtSearch.Text.Trim() != "")
                {
                    string sql = "select * from Hang where ten_Hang = '" + txtSearch.Text + "'";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    if (sqlReader.Read() == true)
                    {

                        sqlReader.Close();
                        command = connection.CreateCommand();
                        command.CommandText = "select * from Hang where ten_Hang='" + txtSearch.Text + "'";
                        adapter.SelectCommand = command;
                        table.Clear();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table; ;
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin tìm kiếm hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (cbxTimTheo.Text == "Số lượng")
            {
                if (txtSearch.Text.Trim() != "")
                {
                    string sql = "select * from Hang where soLuong = '" + txtSearch.Text + "'";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    if (sqlReader.Read() == true)
                    {

                        sqlReader.Close();
                        command = connection.CreateCommand();
                        command.CommandText = "select * from Hang where soLuong='" + txtSearch.Text + "'";
                        adapter.SelectCommand = command;
                        table.Clear();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table; ;
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập thông tin tìm kiếm hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
