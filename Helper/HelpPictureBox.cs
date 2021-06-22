using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.Helper
{
    public partial class HelpPictureBox : UserControl
    {
        int currentIndex = 0;
        int[] maxIndex = new int[4] { 1, 2, 1, 1 };
        IMAGESTATE currentState = IMAGESTATE.ADDHELPER;
        string[,] helpString = new string[4, 3] 
        { 
            { "B1: Điền thông tin nhân viên cần thêm vào các bảng", "B2: Nhấp chuột trái vào nút Thêm để thêm nhân viên vào cơ sở dữ liệu","" }, 
            { "B1: Nhấp chuột trái 2 lần vào dòng nhân viên cần sửa", "B2: Thay đổi thông tin ở trên các bảng","B3: Nhấp chuột trái vào nút Sửa để cập nhập lại thông tin nhân viên" },
            { "B1: Nhấp chuột trái 2 lần vào dòng nhân viên cần xoá", "B2: Nhấp chuột trái vào nút Xoá để xoá nhân viên khỏi cơ sở dữ liệu","" },
            { "B1: Điền thông tin nhân viên cần tìm kiếm vào bảng", "B2: Nhấp chuột trái vào nút tìm kiếm để in ra thông tin của các nhân viên tương đồng với thông tin đã nhập","" }
        };
        public HelpPictureBox()
        {
            InitializeComponent();
        }

        private void setImage(string filename)
        {
            helpLabel.Text = helpString[(int)currentState,currentIndex];
            checkLabeOverflow();
            helperPic.Image = Image.FromFile(Application.StartupPath + filename);
            helperPic.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void updateInformation(IMAGESTATE state, int index = 0)
        {
            //Pass
            if (index > maxIndex[(int)currentState] || index < 0) return;

            index = Define.Clamp(ref index, 0, maxIndex[(int)currentState]);
            currentIndex = index;
            currentState = state;
            imageProgressBar.Value = Convert.ToInt32(((float)(index + 1) / (maxIndex[(int)currentState]+1) * 100));
            switch (state)
            {
                case IMAGESTATE.ADDHELPER:
                    setImage("\\Image\\add" + index + ".png");
                    return;
                case IMAGESTATE.DELETEHELPER:
                    setImage("\\Image\\delete" + index + ".png");
                    return;
                case IMAGESTATE.EDITHELPER:
                    setImage("\\Image\\edit" + index + ".png");
                    return;
                case IMAGESTATE.SEARCHHELPER:
                    setImage("\\Image\\search" + index + ".png");
                    return;
            }
        }

        private void previousBTN_Click(object sender, EventArgs e)
        {
            updateInformation(currentState, currentIndex - 1);
        }

        private void nextBTN_Click(object sender, EventArgs e)
        {
            updateInformation(currentState, currentIndex + 1);
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
