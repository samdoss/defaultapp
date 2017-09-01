using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;  
using ERP.CommonLayer;
using ERP.DataLayer;
  
namespace ERPWinApp
{
    public partial class frmFindUser : Form
    {
        #region Constructor(s)

        public frmFindUser()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        ApplicationConnection _ApplicationConnection = new ApplicationConnection();
        private int _UserID;
        private string _UserName;
        
        internal string helpFile = "\\Help\\HelpFile.chm";

        #endregion

        #region Public Properties

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
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
                            UserID = Convert.ToInt32(itemRow.SubItems[4].Text.ToString());
                            UserName = itemRow.SubItems[5].Text.ToString();
                            bRowSelected = true;
                            this.Close();
                        }
                    }
                    if (!bRowSelected)
                    {
                        UserID = Convert.ToInt32(listUser.Items[0].SubItems[4].Text.ToString());
                        UserName = listUser.Items[0].SubItems[5].Text.ToString();
                        this.Close();
                    }
                }
                else
                {
                    UserID = 0;
                    this.Close();
                }
            }
            catch { }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "")
                {
                    listUser.Items.Clear();
                    return;
                }
                listUser.Items.Clear();
                string searchText = txtUserName.Text.ToString().Trim();
                RoleDescription roleDesc = new RoleDescription();
                using (SqlDataReader dataReader = roleDesc.FindUsers(searchText))
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(dataReader["Name"].ToString());
                            lvi.SubItems.Add(dataReader["Telephone"].ToString());
                            lvi.SubItems.Add(dataReader["Mobile"].ToString());
                            lvi.SubItems.Add(dataReader["Area"].ToString());
                            lvi.SubItems.Add(dataReader["UserID"].ToString());
                            lvi.SubItems.Add(dataReader["UserName"].ToString());
                            listUser.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
                //
                ErrorLog.LogErrorMessageToDB("Find User", "frmFindUser", "txtUserName_TextChanged", ex.Message);
            }
        }        

        private void frmFindUser_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmBilling.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                //Font Settings
                LoadDefaultColorandFonts();
                if (_UserName != null)
                    txtUserName.Text = _UserName.ToString();

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