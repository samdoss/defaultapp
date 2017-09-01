using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;  
using ERP.CommonLayer;
using ERP.DataLayer;
  
namespace ERPWinApp
{
    public partial class frmFindSupplier : Form
    {
        #region Constructor(s)

        public frmFindSupplier()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        ApplicationConnection _ApplicationConnection = new ApplicationConnection();
        private int _SupplierID;
        private string _SupplierName;
        
        internal string helpFile = "\\Help\\HelpFile.chm";

        #endregion

        #region Public Properties

        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }

        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }

        #endregion

        #region Private Events

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool bRowSelected = false;
                if (listSupplier.Items.Count > 0)
                {
                    foreach (ListViewItem itemRow in listSupplier.Items)
                    {
                        if (itemRow.Selected == true)
                        {
                            SupplierID = Convert.ToInt32(itemRow.SubItems[4].Text.ToString());
                            SupplierName = itemRow.SubItems[5].Text.ToString();
                            bRowSelected = true;
                            this.Close();
                        }
                    }
                    if (!bRowSelected)
                    {
                        SupplierID = Convert.ToInt32(listSupplier.Items[0].SubItems[4].Text.ToString());
                        SupplierName = listSupplier.Items[0].SubItems[5].Text.ToString();
                        this.Close();
                    }
                }
                else
                {
                    SupplierID = 0;
                    this.Close();
                }
            }
            catch { }
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierName.Text == "")
                {
                    listSupplier.Items.Clear();
                    return;
                }
                listSupplier.Items.Clear();
                string searchText = txtSupplierName.Text.ToString().Trim();
                RoleDescription roleDesc = new RoleDescription();
				using (SqlDataReader dataReader = roleDesc.FindSupplier(searchText))
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(dataReader["Name"].ToString());
                            lvi.SubItems.Add(dataReader["Telephone"].ToString());
                            lvi.SubItems.Add(dataReader["Mobile"].ToString());
                            lvi.SubItems.Add(dataReader["Area"].ToString());
                            lvi.SubItems.Add(dataReader["SupplierID"].ToString());
                            lvi.SubItems.Add(dataReader["SupplierName"].ToString());
                            listSupplier.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Find Supplier", "frmFindSupplier", "txtSupplierName_TextChanged", ex.Message);
            }
        }        

        private void frmFindSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmBilling.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                //Font Settings
                LoadDefaultColorandFonts();
                if (_SupplierName != null)
                    txtSupplierName.Text = _SupplierName.ToString();

            }
            catch { }
        }

        private void frmFindSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOk_Click(sender, e);
            }
            catch { }
        }

        #endregion

        #region Private Method

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