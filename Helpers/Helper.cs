using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public partial class Helper : Form
    {
        Button CurrentButton;
        public Helper()
        {
            InitializeComponent();
            btnClick(addRHelperBTN);
            helpBox.updateInformation(HELPERSTATE.ADDHELPER,CATSTATE.Product);
        }
        void btnClick(Button btn)
        {
            if (CurrentButton == null)
            {
                CurrentButton = btn;
                Utilities.setButtonState(true, ref CurrentButton);
                return;
            }
            if (CurrentButton == btn)
                return;
            Utilities.setButtonState(false, ref CurrentButton);
            CurrentButton = btn;
            Utilities.setButtonState(true, ref CurrentButton);
        }
        #region READER
        private void addStHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.ADDHELPER,CATSTATE.Product);
        }

        private void editStHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.EDITHELPER, CATSTATE.Product);
        }

        private void delStHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.DELETEHELPER, CATSTATE.Product);
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.SEARCHHELPER, CATSTATE.Product);
        }
        #endregion
        #region LENDING
        private void addLENDINGHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.ADDHELPER, CATSTATE.Customer);
        }

        private void editLENDINGHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.EDITHELPER, CATSTATE.Customer);
        }

        private void delLENDINGHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.DELETEHELPER, CATSTATE.Customer);
        }

        private void searchLENDINGHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.SEARCHHELPER, CATSTATE.Customer);
        }
        #endregion
        #region BOOL
        private void addBOOKHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.ADDHELPER, CATSTATE.Staff);
        }

        private void editBOOKHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.EDITHELPER, CATSTATE.Staff);
        }

        private void delBOOKHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.DELETEHELPER, CATSTATE.Staff);
        }

        private void searchBOOKHelperBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.SEARCHHELPER, CATSTATE.Staff);
        }
        #endregion

        private void nvAdd_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.ADDHELPER, CATSTATE.Staff);
        }

        private void nvEdit_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.EDITHELPER, CATSTATE.Staff);
        }

        private void nvDel_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.DELETEHELPER, CATSTATE.Staff);
        }

        private void nvSearch_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.SEARCHHELPER, CATSTATE.Staff);
        }

        private void statsBTN_Click(object sender, EventArgs e)
        {
            btnClick((Button)sender);
            helpBox.updateInformation(HELPERSTATE.SEARCHHELPER, CATSTATE.Customer);
        }

    }
}
