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
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
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

        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KHACHHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSdt.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KHACHHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaKH.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void QLPhongBan_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Helper.Define.dataSource);
            connection.Open();
            loadData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManHinhChinh manHinhChinh = new ManHinhChinh();
            manHinhChinh.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
