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
    public partial class frmRole : Form
    {
        #region Constructor(s)

        public frmRole()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        Variables objVariables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
        internal string helpFile = "\\Help\\HelpFile.chm";

        #endregion
        
        #region Private Event(s)

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmRole.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                // Fill Relation
                ddlRole.DataSource = Role.GetRoleList(_appConnection).Tables[0];
                ddlRole.DisplayMember = "RoleName";
                ddlRole.ValueMember = "RoleID";
                objVariables.FnSetDisabledButton(btnSave);
                LoadDefaultColorandFonts();
            }
            catch { }
        }

        private void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRole.SelectedIndex != 0)
                {
                    objVariables.FnSetEnabledButton(btnSave);
                    
         
                    int RowIndex = 0;
                    bool[] arrRights = new bool[6];
                    dgvRights.Rows.Clear();
                    if (ddlRole.SelectedIndex > 0)
                    {
                        using (SqlDataReader dataReader = (SqlDataReader)Role.GetRoleXFormLevel(_appConnection, Convert.ToInt32(ddlRole.SelectedValue.ToString())))
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    if (ddlRole.SelectedText.ToString() == "Administrator")
                                    {
                                        dgvRights.Rows.Add();
                                        dgvRights.Rows[RowIndex].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                        dgvRights.Rows[RowIndex].Cells[0].Value = dataReader["FormLevelID"].ToString();
                                        dgvRights.Rows[RowIndex].Cells[1].Value = dataReader["Name"].ToString();
                                        FindRighs(ref arrRights, dataReader["Rights"].ToString());
                                        dgvRights.Rows[RowIndex].Cells[2].Value = arrRights[0];
                                        dgvRights.Rows[RowIndex].Cells[3].Value = arrRights[1];
                                        dgvRights.Rows[RowIndex].Cells[4].Value = arrRights[2];
                                        dgvRights.Rows[RowIndex].Cells[5].Value = arrRights[3];
                                        dgvRights.Rows[RowIndex].Cells[6].Value = arrRights[4];
                                        dgvRights.Rows[RowIndex].Cells[7].Value = arrRights[5];
                                        RowIndex++;
                                    }
                                    else
                                    {
                                        if ((dataReader["Name"].ToString() != "Company Information") && (dataReader["Name"].ToString() != "Reset Password") && (dataReader["Name"].ToString() != "Users") && (dataReader["Name"].ToString() != "User Rights") && (dataReader["Name"].ToString() != "Roles") && (dataReader["Name"].ToString() != "Role Description"))
                                        {
                                            dgvRights.Rows.Add();
                                            dgvRights.Rows[RowIndex].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                            dgvRights.Rows[RowIndex].Cells[0].Value = dataReader["FormLevelID"].ToString();
                                            dgvRights.Rows[RowIndex].Cells[1].Value = dataReader["Name"].ToString();
                                            FindRighs(ref arrRights, dataReader["Rights"].ToString());
                                            dgvRights.Rows[RowIndex].Cells[2].Value = arrRights[0];
                                            dgvRights.Rows[RowIndex].Cells[3].Value = arrRights[1];
                                            dgvRights.Rows[RowIndex].Cells[4].Value = arrRights[2];
                                            dgvRights.Rows[RowIndex].Cells[5].Value = arrRights[3];
                                            dgvRights.Rows[RowIndex].Cells[6].Value = arrRights[4];
                                            dgvRights.Rows[RowIndex].Cells[7].Value = arrRights[5];
                                            RowIndex++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    dgvRights.Rows.Clear();
                    objVariables.FnSetDisabledButton(btnSave);
                    
                }
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Role", "frmRole", "ddlRole_SelectedIndexChanged", ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string FormLevelIDList = string.Empty;
                string rightsList = string.Empty;
                string rightElement;
                int rights;
                short RoleID = short.Parse(ddlRole.SelectedValue.ToString());
                for (int index = 0; index < dgvRights.RowCount; index++)
                {
                    rightElement = string.Empty;
                    rights = 2;
                    while (rights <= 6)
                    {
                        if (bool.Parse(dgvRights.Rows[index].Cells[rights].Value.ToString()) == true)
                        {
                            rightElement = rightElement + "1";
                        }
                        else
                        {
                            rightElement = rightElement + "0";
                        }
                        rights++;
                    }
                    if (rightElement != "00000")
                    {
                        rightsList = rightsList + rightElement + "|";
                        FormLevelIDList = FormLevelIDList + dgvRights[0, index].Value + "|";
                    }
                }

                if (FormLevelIDList != string.Empty)
                {
                    TransactionResult _result;
                    _result = Role.AddRoleXRights(_appConnection, Convert.ToInt32(ddlRole.SelectedValue.ToString()), FormLevelIDList, rightsList);
                    MessageBox.Show(_result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ddlRole.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void dgvRights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!(e.RowIndex == -1) || (e.ColumnIndex == -1))
                {
                    //dont remove these two lines
                    //purposefully i called two times 
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                }
            }
            catch { }
        }

        private void frmRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Methods

        private void LoadDefaultColorandFonts()
        {
            objVariables.FnTitleTheme(lblCaption);
            objVariables.FnButtonTheme(btnSave);
            objVariables.FnButtonTheme(btnClose);
            objVariables.FnGridTheme(dgvRights);
            objVariables.FnSetToolTip(btnSave, "Alt+S Save");
            objVariables.FnSetToolTip(btnClose, "Alt+C Close");
        }

        private void FindRighs(ref bool[] arrRights, string rights)
        {
            int i = 0;
            bool all = true;
            while (i < 5)
            {
                if (rights.Substring(i, 1) == "1")
                {
                    arrRights[i] = true;
                }
                else
                {
                    arrRights[i] = false;
                    all = false;
                }
                i++;
            }
            arrRights[5] = all;
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
           if (ColumnIndex == 7)
            {
                dgvRights.Rows[RowIndex].Cells[2].Value = false;
                dgvRights.Rows[RowIndex].Cells[3].Value = false;
                dgvRights.Rows[RowIndex].Cells[4].Value = false;
                dgvRights.Rows[RowIndex].Cells[5].Value = false;
                dgvRights.Rows[RowIndex].Cells[6].Value = false;

                if (bool.Parse(dgvRights.Rows[RowIndex].Cells[7].Value.ToString()) == true)
                {
                    dgvRights.Rows[RowIndex].Cells[2].Value = true;
                    dgvRights.Rows[RowIndex].Cells[3].Value = true;
                    dgvRights.Rows[RowIndex].Cells[4].Value = true;
                    dgvRights.Rows[RowIndex].Cells[5].Value = true;
                    dgvRights.Rows[RowIndex].Cells[6].Value = true;
                    dgvRights.Rows[RowIndex].Cells[7].Value = true;
                }
            }
            if ((ColumnIndex > 1) || (ColumnIndex < 7))
            {
                bool loopflag = true;
                for (int i = 2; i <= 6; i++)
                {
                    if (bool.Parse(dgvRights.Rows[RowIndex].Cells[i].Value.ToString()) == false)
                    {
                        loopflag = false;
                        dgvRights.Rows[RowIndex].Cells[7].Value = false;
                    }
                }
                dgvRights.Rows[RowIndex].Cells[7].Value = loopflag;
            }
            this.Validate();
        }
        #endregion

    }
}
