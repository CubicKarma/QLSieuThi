using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public partial class HelpPictureBox : UserControl
    {
        Graphics g;
        int currentIndex = 0;
        int[,] maxIndex = new int[4, 4] { { 1, 2, 1, 1 }, 
                                          { 1, 2, 1, 1 } , 
                                          { 2, 2, 1, 1 }, 
                                          { 1, 2, 1, 1 } };
        HELPERSTATE currentState = HELPERSTATE.ADDHELPER;
        CATSTATE currentObjectToRef = CATSTATE.Product;
        string[,] helpStringProduct = new string[4, 3] 
        { 
            { "B1: Điền thông tin sản phẩm cần nhập vào các ô thông tin", 
                "B2: Nhấp chuột trái vào nút Xác nhận để thêm sản phẩm vào cơ sở dữ liệu","" }, 
            { "B1: Chọn tiêu chí tìm kiếm",
              "B2: Điền thông tin tìm kiếm sản phẩm dựa theo tiêu chí",
              "B2: Nhấp chuột trái vào nút tìm kiếm để in ra thông tin của các sản phẩm tương đồng với thông tin đã nhập" },
            { "B1: Điền thông tin mặt hàng và khách hàng mua sản phẩm vào các ô thông tin để xuất hóa đơn",
              "B2: Nhấp chuột trái vào nút Tạo hóa đơn để cập nhập lại xuất và lưu lại hóa đơn bán hàng",
              "" },
            { "B1: Điền thông tin sản phẩm cần tìm kiếm vào bảng", 
              "B2: Nhấp chuột trái vào nút tìm kiếm để in ra thông tin của các sản phẩm tương đồng với thông tin đã nhập","" }
        };
        string[,] helpStringCustomer = new string[4, 3]
        {
            { "B1: Điền thông tin khách hàng và sản phẩm cần thêm vào các ô thông tin",
              "B2: Nhấp chuột trái vào nút khách hàng để lưu phiếu khách hàng",
              "" },
            { "B1: Nhấp chuột trái 2 lần vào dòng hoặc nhập mã khách hàng cần sửa vào trong ô",
              "B2: Thay đổi thông tin ở trên các bảng",
              "B3: Nhấp chuột trái vào nút Sửa để cập nhập lại thông tin khách hàng" },
            { "B1: Nhấp chuột trái 2 lần vào dòng hoặc nhập mã khách hàng cần xoá",
              "B2: Nhấp chuột trái vào nút Xoá để xoá thông tin khách hàng","" },
            { "B1: Điền thông tin khách hàng cần tìm kiếm vào bảng",
              "B2: Nhấp chuột trái vào nút tìm kiếm để in ra thông tin của các khách hàng tương đồng với thông tin đã nhập","" }
        };
        string[,] helpStringExport = new string[4, 3]
        {
            { "B1: Điền thông tin xuất kho và sản phẩm cần thêm vào các ô thông tin",
              "B2: Nhấp chuột trái vào nút Thêm để thêm sản phẩm vào danh sách xuất kho",
              "B3: Nhấp chuột trái vào nút xuất kho để lưu phiếu xuất kho" },
            { "B1: Nhấp chuột trái 2 lần vào dòng hoặc nhập mã sản phẩm cần sửa trong bảng hoặc gõ mã sản phẩm vào trong ô",
              "B2: Thay đổi thông tin ở trên các bảng",
              "B3: Nhấp chuột trái vào nút Sửa để cập nhập lại thông tin sản phẩm trong danh sách xuất kho" },
            { "B1: Nhấp chuột trái 2 lần vào dòng hoặc nhập mã sản phẩm cần xoá",
              "B2: Nhấp chuột trái vào nút Xoá để xoá sản phẩm khỏi phiếu xuất","" },
            { "",
              "","" }
        };
        string[,] helpStringStaff = new string[4, 3]
        {
            { "B1: Điền thông tin nhân viên cần thêm vào các ô thông tin",
              "B2: Nhấp chuột trái vào nút Thêm để thêm nhân viên vào cơ sở dữ liệu","" },
            { "B1: Nhấp chuột trái 2 lần vào dòng hoặc nhập mã nhân viên cần sửa trong bảng hoặc gõ mã nhân viên vào trong ô",
              "B2: Thay đổi thông tin ở trên các bảng",
              "B3: Nhấp chuột trái vào nút Sửa để cập nhập lại thông tin nhân viên" },
            { "B1: Nhấp chuột trái 2 lần vào dòng hoặc nhập mã nhân viên cần xoá",
              "B2: Nhấp chuột trái vào nút Xoá để xoá nhân viên khỏi cơ sở dữ liệu","" },
            { "B1: Điền thông tin nhân viên cần tìm kiếm vào bảng",
              "B2: Nhấp chuột trái vào nút tìm kiếm để in ra thông tin của các nhân viên tương đồng với thông tin đã nhập","" }
        };
        public HelpPictureBox()
        {
            InitializeComponent();
            g = progressBar.CreateGraphics();
            progressBar.Paint += progressPaint;
        }

        private void progressPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            float percentage = 1f / (maxIndex[(int)currentObjectToRef, (int)currentState] + 1);
            int width = Convert.ToInt32(progressBar.Width * percentage);
            Rectangle rectangle = new Rectangle(0, 0, width, progressBar.Height);
            SolidBrush brush = new SolidBrush(Color.Green);

            e.Graphics.FillRectangle(brush, rectangle);
        }

        private void setImage(string filename)
        {
            switch(currentObjectToRef)
            {
                case CATSTATE.Product:
                    helpLabel.Text = helpStringProduct[(int)currentState, currentIndex];
                    checkLabeOverflow();
                    helperPic.Image = Image.FromFile(Application.StartupPath + "\\Image\\Product" + filename);
                    break;
                case CATSTATE.Customer:
                    helpLabel.Text = helpStringCustomer[(int)currentState, currentIndex];
                    checkLabeOverflow();
                    helperPic.Image = Image.FromFile(Application.StartupPath + "\\Image\\Customer" + filename);
                    break;
                case CATSTATE.Export:
                    helpLabel.Text = helpStringExport[(int)currentState, currentIndex];
                    checkLabeOverflow();
                    helperPic.Image = Image.FromFile(Application.StartupPath + "\\Image\\Export" + filename);
                    break;
                case CATSTATE.Staff:
                    helpLabel.Text = helpStringStaff[(int)currentState, currentIndex];
                    checkLabeOverflow();
                    helperPic.Image = Image.FromFile(Application.StartupPath + "\\Image\\Staff" + filename);
                    break;
            }   

            helperPic.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void updateInformation(HELPERSTATE state,CATSTATE catstate, int index = 0)
        {
            //Pass
            if (index > maxIndex[(int)catstate, (int)currentState] || index < 0) return;

            index = Define.Clamp(ref index, 0, maxIndex[(int)catstate, (int)currentState]);
            currentIndex = index;
            currentState = state;
            currentObjectToRef = catstate;
            FillProgressBar(index);
            switch (state)
            {
                case HELPERSTATE.ADDHELPER:
                    setImage("\\add" + index + ".png");
                    return;
                case HELPERSTATE.DELETEHELPER:
                    setImage("\\del" + index + ".png");
                    return;
                case HELPERSTATE.EDITHELPER:
                    setImage("\\edit" + index + ".png");
                    return;
                case HELPERSTATE.SEARCHHELPER:
                    setImage("\\search" + index + ".png");
                    return;
            }
        }

        private void FillProgressBar(int index)
        {
            g.Clear(Color.White);
            float percentage = (float)(index + 1) / ( maxIndex[(int)currentObjectToRef, (int)currentState] + 1);
            int width = Convert.ToInt32(progressBar.Width * percentage);
            Rectangle rectangle = new Rectangle(0, 0, width, progressBar.Height);

            SolidBrush brush = new SolidBrush(Color.Green);
            
            g.FillRectangle(brush, rectangle);
        }

        private void previousBTN_Click(object sender, EventArgs e)
        {
            updateInformation(currentState,currentObjectToRef ,currentIndex - 1);
        }

        private void nextBTN_Click(object sender, EventArgs e)
        {
            updateInformation(currentState, currentObjectToRef, currentIndex + 1);
        }

        void checkLabeOverflow()
        {
            while (helpLabel.Width < System.Windows.Forms.TextRenderer.MeasureText(helpLabel.Text,
            new Font(helpLabel.Font.FontFamily, helpLabel.Font.Size, helpLabel.Font.Style)).Width)
            {
                helpLabel.Font = new Font(helpLabel.Font.FontFamily, helpLabel.Font.Size - 0.5f, helpLabel.Font.Style);
            }
        }

        private void helperPic_Resize(object sender, EventArgs e)
        {
            checkLabeOverflow();
        }
    }
}
