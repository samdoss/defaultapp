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
    public partial class frmFindCompany : Form
    {
        #region Constructor(s)

        public frmFindCompany()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variable(s)

        Variables _variables = new Variables();
        private string _companyNumber;
        
        internal string helpFile = "\\Help\\HelpFile.chm";
        #endregion

        #region Public Properties

        public string CompanyNumber
        {
            get { return _companyNumber; }
            set { _companyNumber = value; }
        }

        #endregion

        #region Private Event(s)

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool bRowSelected = false;
                if (lsDrugList.Items.Count > 0)
                {
                    foreach (ListViewItem itemRow in lsDrugList.Items)
                    {
                        if (itemRow.Selected == true)
                        {
                            CompanyNumber = itemRow.SubItems[4].Text.ToString();
                            bRowSelected = true;
                            this.Close();
                        }
                    }
                    if (!bRowSelected)
                    {
                        CompanyNumber = lsDrugList.Items[0].SubItems[4].Text.ToString();
                        this.Close();
                    }
                }
                else
                {
                    CompanyNumber = "";
                    this.Close();
                }
            }
            catch { }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    FindDrug objMaster = new FindDrug();
            //    string searchText = txtUserName.Text.ToString().Trim();
            //    SqlDataReader dr = objMaster.GetFindDrugCompany(searchText);
            //    lsDrugList.Items.Clear();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            ListViewItem lvi = new ListViewItem(dr["CompanyName"].ToString());
            //            lvi.SubItems.Add(dr["BrandName"].ToString());
            //            lvi.SubItems.Add(dr["Area"].ToString());
            //            lvi.SubItems.Add(dr["Mobile"].ToString());
            //            lvi.SubItems.Add(dr["DrugCompanyID"].ToString());
            //            lsDrugList.Items.Add(lvi);

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
                
                
            //    ErrorLog.LogErrorMessageToDB("Find Company", "frmFindCompany", "txtUserName_TextChanged");
            //}
        }

        private void frmFindUser_Load(object sender, EventArgs e)
        {
            try
            {
                //ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                //ApplicationHelpProvider.SetHelpKeyword(this, "frmFindCompany.htm");
                //ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                
                //Font Settings
                LoadDefaultColorandFonts();
                if (_companyNumber != null)
                    txtUserName.Text = _companyNumber.ToString();

            }
            catch { }
        }

        private void frmFindUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsDrugList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOk_Click(sender, e);
            }
            catch { }
        }
        
        #endregion

        #region Private Method(s)

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