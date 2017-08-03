using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Forms.VisualStyles;
using System.Configuration;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class frmRoleMaster : Form
    {
        #region Constructor(s)

        public frmRoleMaster()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        internal string helpFile = "\\Help\\*.chm";
        
        
        ApplicationConnection _connectionObj = new ApplicationConnection();
        ShowStatus _ShowStatus;
		List<RoleDL> _listRole = new List<RoleDL>();
        private int _gridRowIndex = 0;
        private int _row = 0;
        private int _col = 0;

        #endregion

        #region Private Event(s)

        private void frmRoleMaster_Load(object sender, EventArgs e)
        {
            try
            {
                dvRoleDesc.EnableHeadersVisualStyles = false;
                SettingGridColumnOrder();
                FillShowStatus();
                FillGrid();
                PCSHelp.HelpNamespace = (Application.StartupPath + helpFile);
                PCSHelp.SetHelpKeyword(this, "frmRoleMaster.htm");
                PCSHelp.SetHelpNavigator(this, HelpNavigator.Topic);
                ostrpDelete.Visible = false;
                
                LoadDefaultColorandFonts();
            }
            catch { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ShowStatus = (ShowStatus)Enum.Parse(typeof(ShowStatus), ddlStatus.SelectedValue.ToString());
                FillGrid();
	            btnDelete.Enabled = true;
	            btnSave.Enabled = true;

            }
            catch { }
        }

        private void dvRoleDesc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 2)
                {
                    if (dvRoleDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        RoleEdit.Visible = false;
                        RoleStatus.Visible = false;
                        RoleDelete.Visible = false;
                        UpdateRole(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    if (dvRoleDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        DialogResult isQuit;
                        TransactionResult _result = null;
                        if (dvRoleDesc[3, e.RowIndex].Value.ToString() == "Enable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Enabled?", "Application Name", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = RoleDescription.EnableDisableRole(_connectionObj, Convert.ToInt32(dvRoleDesc[6, e.RowIndex].Value.ToString()), true);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Role Description Successfully Enabled.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Enabling Role Description.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        else if (dvRoleDesc[3, e.RowIndex].Value.ToString() == "Disable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Disabled?", "Application Name", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
								_result = RoleDescription.EnableDisableRole(_connectionObj, Convert.ToInt32(dvRoleDesc[6, e.RowIndex].Value.ToString()), false);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Role Description Successfully Disabled.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Disabling Role Description.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dvRoleDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dvRoleDesc[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvRoleDesc[4, e.RowIndex].ReadOnly = true;
                        dvRoleDesc[4, e.RowIndex].Value = false;
                        dvRoleDesc.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    dvRoleDesc_CellEndEdit(sender, e);
                }
            }
            catch { }
        }
        
        private void UpdateCancelClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvRoleDesc.Rows[e.RowIndex].Cells["UpdateRecord"];
            DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvRoleDesc.Rows[e.RowIndex].Cells["CancelRecord"];

            if ((dvRoleDesc.Columns[e.ColumnIndex].Name == "UpdateRecord") || (dvRoleDesc.Columns[e.ColumnIndex].Name == "CancelRecord"))
            {
                if (_btnUpdate.Enabled || _btnCancel.Enabled)
                {
                    if (dvRoleDesc.Columns[e.ColumnIndex].Name == "UpdateRecord")
                    {
                        if (!UpdateFormValidation(e.ColumnIndex,e.RowIndex)) { return; }
                        _listRole.Clear();
                        RoleDL _Role = new RoleDL();
                        _Role.RoleID = Convert.ToInt32(dvRoleDesc.Rows[e.RowIndex].Cells[6].Value.ToString());
                        _Role.Roles = dvRoleDesc.Rows[e.RowIndex].Cells[1].Value.ToString();
                        _Role.AuditUserID = 1;
                        _listRole.Add(_Role);

                        RoleDescription _RoleDescription = new RoleDescription();
                        _RoleDescription.RoleList = _listRole;
                        TransactionResult _Result = null;
                        _Result = _RoleDescription.Commit(ScreenMode.Edit);
                        dvRoleDesc.Columns.Remove("CancelRecord");
                        dvRoleDesc.Columns.Remove("UpdateRecord");
                        SettingGridColumnOrder();
                        FillGrid();
                    }
                    if (dvRoleDesc.Columns[e.ColumnIndex].Name == "CancelRecord")
                    {
                        dvRoleDesc.Columns.Remove("CancelRecord");
                        dvRoleDesc.Columns.Remove("UpdateRecord");
                        SettingGridColumnOrder();
                        FillGrid();
                    }
                }
            }
        }
        catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FormValidation()) { return; }
                bool EnableDisable = true;
                if (_ShowStatus == ShowStatus.Disabled)
                    EnableDisable = false;

                _listRole.Clear();
                foreach (DataGridViewRow _Row in dvRoleDesc.Rows)
                {
                    if ((_Row.Cells[6].Value == null))
                    {
                        if ((_Row.Cells[1].Value != null))
                        {
                            RoleDL _Role = new RoleDL();
                            _Role.Roles = _Row.Cells[1].Value.ToString();
                            _Role.AuditUserID = 1;
                            _Role.IsEnabled = EnableDisable;
                            _listRole.Add(_Role);
                        }
                    }
                }
                RoleDescription _RoleDescription = new RoleDescription();
                _RoleDescription.RoleList = _listRole;

                if (_listRole.Count != 0)
                {
                    TransactionResult _Result = null;
                    _Result = _RoleDescription.Commit(ScreenMode.Add);
                    MessageBox.Show(_Result.Message, "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    FillGrid();
                }
                else
                {
                    MessageBox.Show("Please Enter The Role.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch { }
        }

        private void dvRoleDesc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dvRoleDesc[0, e.RowIndex].Value = _RowNumber;

                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                string status;
                _listRole.Clear();
                foreach (DataGridViewRow _Row in dvRoleDesc.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[4].FormattedValue) == true)
                    {
                        status = _Row.Cells[4].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            RoleDL _Role = new RoleDL();
                            _Role.RoleID = Convert.ToInt32(_Row.Cells[6].Value.ToString());
                            _listRole.Add(_Role);
                        }

                    }
                }
                RoleDescription _RoleDescription = new RoleDescription();
                _RoleDescription.RoleList = _listRole;
                if (_listRole.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected Role(s) will be Deleted. Do You Want to Delete?", "Application Name", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _RoleDescription.Commit(ScreenMode.Delete);
                        MessageBox.Show(_Result.Message, "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        FillGrid();
                        if (_Result.Status == TransactionStatus.Success)
                        {
                            FillGrid();
                        }
                    }
                    else
                    {
                        FillGrid();
                    }
                }
            }
            catch
            {
            }
        }

        private void dvRoleDesc_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                //MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                // MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                //MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                //MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "An Error.";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "An Error.";
                anError.ThrowException = false;
            }
        }

        private void dvRoleDesc_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dvRoleDesc[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dvRoleDesc[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dvRoleDesc.RowCount - 1);
                }

                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex == dvRoleDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvRoleDesc Should Not be Empty");
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex == dvRoleDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        // MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvRoleDesc Should Not be Empty");
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dvRoleDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dvRoleDesc[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvRoleDesc[4, e.RowIndex].ReadOnly = true;
                        dvRoleDesc[4, e.RowIndex].Value = false;
                        dvRoleDesc.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }
            }
            catch { }
        }

        private void dvRoleDesc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    //dont remove these two lines
                    //purposefully i called two times 
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                    //GridValueChanged(e.RowIndex, e.ColumnIndex);
                }
            }
            catch { }
        }

        private void dvRoleDesc_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                int countLast = 0;
                countLast = dvRoleDesc.Rows.Count - 1;
                dvRoleDesc[4, countLast].ReadOnly = true;
                ostrpDelete.Visible = true;
                
                
            }
            catch { }
        }

        private void dvRoleDesc_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            
            
        }

        private void ostrpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gridRowIndex < dvRoleDesc.Rows.Count - 1)
                    if (dvRoleDesc[6, _row].Value == null)
                        dvRoleDesc.Rows.RemoveAt(_row);
            }
            catch { }
        }

        private void dvRoleDesc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dvRoleDesc.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dvRoleDesc.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void frmRoleMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method(s)

        private bool FormValidation()
        {
            bool valid = true;
            for (int t = 0; t < dvRoleDesc.Rows.Count - 1; t++)
            {
                if (dvRoleDesc[1, t].Value == null)
                {
                    MessageBox.Show("Please Enter The Role.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dvRoleDesc[1, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (FindDuplicateRole())
                {
                    MessageBox.Show("Please Remove The Duplicate Role.", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dvRoleDesc[1, t].Selected = true;
                    break;
                }
            }
            return valid;
        }

        private bool UpdateFormValidation(int columnIndex, int rowIndex)
        {
            bool valid = true;
            if (dvRoleDesc[1, rowIndex].Value == null)
            {
                dvRoleDesc[1, rowIndex].ErrorText = "Please Enter Role.";
                dvRoleDesc[1, rowIndex].Selected = true;
                valid = false;
            }
            else if (FindDuplicateRole())
            {
                dvRoleDesc[1, rowIndex].ErrorText = "Please Remove Duplicate Role.";
                valid = false;
                dvRoleDesc[1, rowIndex].Selected = true;
            }
            return valid;
        }

        private bool FindDuplicateRole()
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dvRoleDesc.Rows.Count;
            rCountWithEntries = 0;

            // Loop to count the number of dvRoleDesc entered
            for (int i = 0; i < rCount; i++)
            {

                if (dvRoleDesc[1, i].Value != null && dvRoleDesc[1, i].Value.ToString().Trim() != "")
                {
                    rCountWithEntries = rCountWithEntries + 1;
                }
                else
                {
                    break;
                }
            }
            string[] arPatientDuplicate = new string[rCountWithEntries];
            // If dvRoleDesc have been entered, then it is saved
            if (rCountWithEntries > 0)
            {
                int j = 0;
                for (int i = 0; i < rCountWithEntries; i++)
                {
                    if (dvRoleDesc[1, i].Value != null && dvRoleDesc[1, i].Value.ToString().Trim() != "")
                    {
                        arPatientDuplicate[j] = dvRoleDesc[1, i].Value.ToString();
                        j++;
                    }
                }

                Array.Sort(arPatientDuplicate);
                j = 0;
                string tempDuplicate = arPatientDuplicate[0];
                for (int i = 1; i < rCountWithEntries; i++)
                {
                    if (tempDuplicate != arPatientDuplicate[i])
                    {
                        tempDuplicate = arPatientDuplicate[i];
                    }
                    else
                    {
                        IsDuplicatesFound = true;
                    }
                }
            }
            return IsDuplicatesFound;
        }

        private void FillShowStatus()
        {
            ddlStatus.DataSource = Enum.GetValues(typeof(ShowStatus));
        }

        private void FillGrid()
        {
            try
            {
                int _RowIndex = 0;
                bool EnableDisable = true;
                if (_ShowStatus == ShowStatus.Disabled)
                    EnableDisable = false;
				_listRole = RoleDescription.GetEnableDisableRole(_connectionObj, EnableDisable);

                dvRoleDesc.Rows.Clear();
                foreach (RoleDL _RoleDescription in _listRole)
                {
                    dvRoleDesc.Rows.Add();
                    dvRoleDesc.Rows[_RowIndex].ReadOnly = true;
                    dvRoleDesc[6, _RowIndex].Value = _RoleDescription.RoleID.ToString();
                    dvRoleDesc[0, _RowIndex].Value = _RowIndex + 1;
                    dvRoleDesc[1, _RowIndex].Value = _RoleDescription.Roles;
                    DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dvRoleDesc.Rows[_RowIndex].Cells["RoleEdit"];
                    DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dvRoleDesc.Rows[_RowIndex].Cells["RoleStatus"];
                    buttonEdit.Enabled = true;
                    buttonStatus.Enabled = true;
                    RoleEdit.UseColumnTextForButtonValue = false;
                    dvRoleDesc[2, _RowIndex].Value = "Edit";
                    RoleStatus.UseColumnTextForButtonValue = false;
                    if (_ShowStatus == ShowStatus.Disabled)
                        dvRoleDesc[3, _RowIndex].Value = "Enable";
                    else
                        dvRoleDesc[3, _RowIndex].Value = "Disable";
                    _RowIndex++;
                }
                btnDelete.Enabled = true;
	            btnSave.Enabled = true;

                
                ostrpDelete.Visible = false;
            }
            catch (Exception ex)
            {
				//_errorLog = new ErrorLog();
				//_errorLog.ErrorMessage = ex.Message;
				//_errorLog.ShowError("Role Master", "frmRoleMaster", "FillGrid");
            }
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 4)
            {
                for (int i = 0; i < dvRoleDesc.RowCount - 1; i++)
                {
                    if (dvRoleDesc.Rows[i].Cells[4].Value != null)
                        if (Convert.ToBoolean(dvRoleDesc.Rows[i].Cells[4].Value) == true)
                        {
                            delSelected = true;
                        }
                }
                if (delSelected == true)
                {
	                btnDelete.Enabled = true;
                }
                else
                {
	                //btnDelete.Enabled = false;
				}
            }
            this.Validate();
        }

        private void UpdateRole(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dvRoleDesc.Columns.Add(column2);
                dvRoleDesc.Columns.Add(column3);
                dvRoleDesc.AllowUserToAddRows = false;
                dvRoleDesc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dvRoleDesc.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dvRoleDesc.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvRoleDesc.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvRoleDesc.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dvRoleDesc.Rows[RowIndex].ReadOnly = false;
                dvRoleDesc.CellClick += new DataGridViewCellEventHandler(UpdateCancelClick);
            }
            catch { }
        }

        private void SettingGridColumnOrder()
        {
            RoleSno.DisplayIndex = 0;
            RoleDesc.DisplayIndex = 1;
            RoleEdit.DisplayIndex = 2;
            RoleStatus.DisplayIndex = 3;
            RoleDelete.DisplayIndex = 4;
            RoleEditingChk.DisplayIndex = 5;
            Roleno.DisplayIndex = 6;
            RoleSno.Visible = true;
            RoleSno.ReadOnly = true;
            RoleDesc.Visible = true;
            RoleEdit.Visible = true;
            RoleStatus.Visible = true;
            RoleDelete.Visible = true;
            RoleEditingChk.Visible = false;
            Roleno.Visible = false;
            dvRoleDesc.AllowUserToAddRows = true;
        }

        private void LoadDefaultColorandFonts()
        {
	        btnDelete.Enabled = true;
	        btnSave.Enabled = true;
	        btnClose.Enabled = true;
        }

        #endregion

    }
}