using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class frmFindBill : Form
    {
        #region Constructor(s)

        public frmFindBill()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variable(s)

        Variables _variables = new Variables();
        private string _BillDescriptionID;
        
        internal string helpFile = "\\Help\\HelpFile.chm";

        #endregion

        #region Public Properties

        public string BillDescriptionID
        {
            get { return _BillDescriptionID; }
            set { _BillDescriptionID = value; }
        }

        #endregion

        #region Private Event(s)

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool bRowSelected = false;
                if (lstBillDescription.Items.Count > 0)
                {
                    foreach (ListViewItem itemRow in lstBillDescription.Items)
                    {
                        if (itemRow.Selected == true)
                        {
                            BillDescriptionID = itemRow.SubItems[0].Text.ToString();
                            bRowSelected = true;
                            this.Close();
                        }
                    }
                    if (!bRowSelected)
                    {
                        BillDescriptionID = lstBillDescription.Items[0].SubItems[0].Text.ToString();
                        this.Close();
                    }
                }
                else
                {
                    BillDescriptionID = "";
                    this.Close();
                }
            }
            catch { }
        }

        private void frmFindBill_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmBilling.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                
                //Font Settings
                LoadDefaultColorandFonts();
                if (_BillDescriptionID != null)
                    txtBillDescription.Text = _BillDescriptionID.ToString();
                txtBillDescription.Focus();
            }
            catch { }
        }

        private void frmFindBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBillDescription_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOk_Click(sender, e);
            }
            catch { }
        }

        private void txtBillDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BillDescription objBillDescription = new BillDescription();
                string searchText = txtBillDescription.Text.ToString().Trim();
                SqlDataReader dr = objBillDescription.GetFindBill(searchText);
                lstBillDescription.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ListViewItem lvi = new ListViewItem(dr["BillCode"].ToString());
                        lvi.SubItems.Add(dr["BillDescription"].ToString());
                        lvi.SubItems.Add(dr["BillDescriptionID"].ToString());
                        lstBillDescription.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {


                ErrorLog.LogErrorMessageToDB("Find Bill", "frmFindBill", "txtBillDescription_TextChanged", ex.Message);
            }
        }

        #endregion

        #region Private Methods(s)

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnButtonTheme(btnCancel);
            _variables.FnButtonTheme(btnOk);
            _variables.FnSetToolTip(btnCancel, "Alt+C Cancel");
            _variables.FnSetToolTip(btnOk, "Alt+O OK");
        }

        #endregion

    }
}