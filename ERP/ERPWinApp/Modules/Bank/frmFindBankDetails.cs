using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using ERP.DataLayer;
using ERP.CommonLayer;


namespace ERPWinApp
{
    public partial class frmFindBankDetails : Form
    {
        #region Constructor(s)

        public frmFindBankDetails()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        ApplicationConnection _ApplicationConnection = new ApplicationConnection();
        
        private int _searchID;
        private string _searchText;
        
        internal string helpFile = "\\Help\\HelpFile.chm";

        #endregion

        #region Public Properties

        public int SearchID
        {
            get { return _searchID; }
            set { _searchID = value; }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

        #endregion

        #region Private Events

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool bRowSelected = false;
                if (listUser.Items.Count > 0)
                {
                    foreach (ListViewItem itemRow in listUser.Items)
                    {
                        if (itemRow.Selected == true)
                        {
                            SearchID = Convert.ToInt32(itemRow.SubItems[4].Text.ToString());
                            SearchText = itemRow.SubItems[0].Text.ToString();
                            bRowSelected = true;
                            this.Close();
                        }
                    }
                    if (!bRowSelected)
                    {
                        SearchID = Convert.ToInt32(listUser.Items[0].SubItems[4].Text.ToString());
                        SearchText = listUser.Items[0].SubItems[5].Text.ToString();
                        this.Close();
                    }
                }
                else
                {
                    SearchID = 0;
                    this.Close();
                }
            }
            catch { }
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchText.Text == "")
                {
                    listUser.Items.Clear();
                    return;
                }
                listUser.Items.Clear();
                string searchText = txtSearchText.Text.ToString().Trim();
                BankDetailDL bankObj = new BankDetailDL();
                using (SqlDataReader dataReader = bankObj.FindUsers(searchText))
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(dataReader["BankAccountHolderName"].ToString());
                            lvi.SubItems.Add(dataReader["BankAccountNumber"].ToString());
                            lvi.SubItems.Add(dataReader["BankName"].ToString());
                            lvi.SubItems.Add(dataReader["IFSCCode"].ToString());
                            lvi.SubItems.Add(dataReader["BankDetailID"].ToString());
                            lvi.SubItems.Add(dataReader["BankName"].ToString());
                            listUser.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
                //
                //ErrorLog.LogErrorMessageToDB("Find User", "frmFindUser", "txtUserName_TextChanged", ex.Message);
            }
        }

        private void frmFindBankDetails_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmBankDetails.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                //Font Settings
                LoadDefaultColorandFonts();
                if (_searchText != null)
                    txtSearchText.Text = _searchText.ToString();

            }
            catch { }
        }

        private void frmFindBankDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listUser_DoubleClick(object sender, EventArgs e)
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