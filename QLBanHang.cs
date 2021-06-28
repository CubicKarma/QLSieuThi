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
    public partial class QLBanHang : Form
    {
        public QLBanHang()
        {
            InitializeComponent();
        }

        //Help ref
        Form helpf;
        //Ket noi SQL
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader sqlReader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        //Datasourse (khac nhau)

        DataTable table = new DataTable();  //main datagridview
        DataTable table2 = new DataTable(); //datagridview hien thi nhan vien
        DataTable table3 = new DataTable(); //datagridview hien thi khach hang
        DataTable table4 = new DataTable(); //datagridview hien thi hang

        private void UpdateNV()
        {
            cmbMaNv.Items.Clear();
            command.CommandText = "SELECT * FROM NHANVIEN";
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                cmbMaNv.Items.Add(sqlReader["id_Nv"].ToString());
            }
            sqlReader.Close();
        }
        private void UpdateKH()
        {
            cmbMaKH.Items.Clear();
            command.CommandText = "SELECT * FROM KHACHHANG";
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                cmbMaKH.Items.Add(sqlReader["id_Khach"].ToString());
            }
            sqlReader.Close();
        }
        private void UpdateHang()
        {
            cmbMaHang.Items.Clear();
            command.CommandText = "SELECT * FROM HANG";
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                cmbMaHang.Items.Add(sqlReader["id_Hang"].ToString());
            }
            sqlReader.Close();
        }

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from HOADON";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            UpdateKH();
            UpdateNV();
            UpdateHang();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            dtpNgayBan.Text = "";
            cmbMaNv.Text = "";
            txtTenNv.Text = "";
            cmbMaKH.Text = "";
            txtTenKH.Text = "";
            txtSoLuong.Text = "";
            cmbMaHang.Text = "";
            txtTenHang.Text = "";
            txtDonGia.Text = "";
            txtTongTien.Text = "";
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Helpers.Define.dataSource);

            connection.Open();

            string sql = "select * from HOADON where id_Hd = '" + txtMaHD.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {

                MessageBox.Show(" Trùng mã hóa đơn! Mời Nhập lại");
            }
            else
            {
                if (txtMaHD.Text != null)
                {
                    dta.Close();
                    //kiểm tra số lượng hàng mua so với số lượng hàng trong kho
                    int soLuongMua = Int32.Parse(txtSoLuong.Text);
                    int soLuongTrongKho = Int32.Parse(txtSoLuongHangTrongKho.Text);
                    if (soLuongMua > soLuongTrongKho)
                        MessageBox.Show("Hàng trong kho không đủ");
                    else
                    {
                        //update số lượng hàng trong kho
                        int soLuongHangConLai = soLuongTrongKho - soLuongMua;
                        command = connection.CreateCommand();
                        command.CommandText = "update HANG set soLuong = " + soLuongHangConLai + " where id_Hang = '" + cmbMaHang.Text + "'";
                        command.ExecuteNonQuery();

                        //thêm hóa đơn
                        command = connection.CreateCommand();
                        command.CommandText = "Insert into HOADON values('" + txtMaHD.Text + "', N'" + cmbMaHang.Text + "', N'" + txtSoLuong.Text + "', N'" + cmbMaNv.Text + "', N'" + cmbMaKH.Text + "', N'" + dtpNgayBan.Text + "', N'" + txtTongTien.Text + "')";
                        command.ExecuteNonQuery();
                        loadData();
                    }    
                }
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int donGia = Int32.Parse(txtDonGia.Text);
            int soLuong = Int32.Parse(txtSoLuong.Text);
            int tongTien = donGia * soLuong;
            txtTongTien.Text = tongTien.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //command = connection.CreateCommand();
            //command.CommandText = "delete from NHANVIEN where id_Da = '" + txtMaHD.Text + "'";
            //command.ExecuteNonQuery();

            //command = connection.CreateCommand();
            //command.CommandText = "delete from DUAN where id_Da = '" + txtMaHD.Text + "'";
            //command.ExecuteNonQuery();
            //loadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from HOADON";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void QLDuAn_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Helpers.Define.dataSource);
            connection.Open();
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaHD.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cmbMaHang.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cmbMaNv.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cmbMaKH.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dtpNgayBan.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtTongTien.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQLHang menuQlHang = new MenuQLHang();
            menuQlHang.ShowDialog();
        }

        private void cmbMaNv_SelectedIndexChanged(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN where id_Nv = '" + cmbMaNv.Text + "'";
            adapter.SelectCommand = command;
            table2.Clear();
            adapter.Fill(table2);
            dataGridView2.DataSource = table2;

            txtTenNv.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
        }

        private void cmbMaNv_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;

            //if (cb.SelectedValue != null)
            //{
            //    command = connection.CreateCommand();
            //    command.CommandText = "select ten_Nv from NHANVIEN where id_Nv = '" + cmbMaNv.Text + "'";
            //    adapter.SelectCommand = command;
            //    table2.Clear();
            //    adapter.Fill(table2);
            //    dataGridView2.DataSource = table;

            //    txtTenNv.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
            //}
        }

        private void cmbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KHACHHANG where id_Khach = '" + cmbMaKH.Text + "'";
            adapter.SelectCommand = command;
            table3.Clear();
            adapter.Fill(table3);
            dataGridView3.DataSource = table3;

            txtTenKH.Text = dataGridView3.Rows[0].Cells[1].Value.ToString();
            txtSdt.Text = dataGridView3.Rows[0].Cells[2].Value.ToString();
        }

        private void cmbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from HANG where id_Hang = '" + cmbMaHang.Text + "'";
            adapter.SelectCommand = command;
            table4.Clear();
            adapter.Fill(table4);
            dataGridView4.DataSource = table4;

            txtTenHang.Text = dataGridView4.Rows[0].Cells[1].Value.ToString();
            txtDonGia.Text = dataGridView4.Rows[0].Cells[4].Value.ToString();
            txtSoLuongHangTrongKho.Text = dataGridView4.Rows[0].Cells[2].Value.ToString();
        }
    }
}
