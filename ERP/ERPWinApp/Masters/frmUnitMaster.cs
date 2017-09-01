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
    public partial class frmUnitMaster : Form
    {
        #region Constructor(s)

        public frmUnitMaster()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        internal string helpFile = "\\Help\\HelpFile.chm";
        Variables _variables = new Variables();
        
        ApplicationConnection _appConnection = new ApplicationConnection();
        ShowStatus _ShowStatus;
        List<UnitDescription> _listUnit = new List<UnitDescription>();
        private int _gridRowIndex = 0;
        private int _row = 0;
        private int _col = 0;

        #endregion

        #region Private Event(s)

        private void frmUnit_Load(object sender, EventArgs e)
        {
            try
            {
                dvUnitDesc.EnableHeadersVisualStyles = false;
                SettingGridColumnOrder();
                FillShowStatus();
                FillGrid();
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmUnitMaster.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                ostrpDelete.Visible = false;
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetDisabledButton(btnDelete);
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
            }
            catch { }
        }

        private void dvUnitDesc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 2)
                {
                    if (dvUnitDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        UnitEdit.Visible = false;
                        UnitStatus.Visible = false;
                        UnitDelete.Visible = false;
                        UpdateUnit(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    if (dvUnitDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        DialogResult isQuit;
                        TransactionResult _result = null;
                        if (dvUnitDesc[3, e.RowIndex].Value.ToString() == "Enable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Enabled?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = UnitDescription.EnableDisableUnit(_appConnection, Convert.ToInt32(dvUnitDesc[6, e.RowIndex].Value.ToString()), true);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Unit Description Successfully Enabled.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Enabling Unit Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        else if (dvUnitDesc[3, e.RowIndex].Value.ToString() == "Disable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Disabled?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = UnitDescription.EnableDisableUnit(_appConnection, Convert.ToInt32(dvUnitDesc[6, e.RowIndex].Value.ToString()), false);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Unit Description Successfully Disabled.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Disabling Unit Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dvUnitDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dvUnitDesc[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvUnitDesc[4, e.RowIndex].ReadOnly = true;
                        dvUnitDesc[4, e.RowIndex].Value = false;
                        dvUnitDesc.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    dvUnitDesc_CellEndEdit(sender, e);
                }
            }
            catch { }
        }
       
        private void UpdateCancelClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvUnitDesc.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvUnitDesc.Rows[e.RowIndex].Cells["CancelRecord"];

                if ((dvUnitDesc.Columns[e.ColumnIndex].Name == "UpdateRecord") || (dvUnitDesc.Columns[e.ColumnIndex].Name == "CancelRecord"))
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dvUnitDesc.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidation(e.ColumnIndex, e.RowIndex)) { return; }
                            _listUnit.Clear();
                            UnitDescription _Unit = new UnitDescription();
                            _Unit.UnitID = Convert.ToInt32(dvUnitDesc.Rows[e.RowIndex].Cells[6].Value.ToString());
                            _Unit.Unit = dvUnitDesc.Rows[e.RowIndex].Cells[1].Value.ToString();
                            _Unit.AuditUserID = MDIForm.UserID;
                            _listUnit.Add(_Unit);

                            UnitDescription _UnitDescription = new UnitDescription();
                            _UnitDescription.UnitList = _listUnit;
                            TransactionResult _Result = null;
                            _Result = _UnitDescription.Commit(ScreenMode.Edit);
                            dvUnitDesc.Columns.Remove("CancelRecord");
                            dvUnitDesc.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        if (dvUnitDesc.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            dvUnitDesc.Columns.Remove("CancelRecord");
                            dvUnitDesc.Columns.Remove("UpdateRecord");
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

                _listUnit.Clear();
                foreach (DataGridViewRow _Row in dvUnitDesc.Rows)
                {
                    if ((_Row.Cells[6].Value == null))
                    {
                        if ((_Row.Cells[1].Value != null))
                        {
                            UnitDescription _Unit = new UnitDescription();
                            _Unit.Unit = _Row.Cells[1].Value.ToString();
                            _Unit.AuditUserID = MDIForm.UserID;
                            _Unit.IsEnabled = EnableDisable;
                            _listUnit.Add(_Unit);
                        }
                    }
                }
                UnitDescription _UnitDescription = new UnitDescription();
                _UnitDescription.UnitList = _listUnit;
                TransactionResult _Result = null;
                _Result = _UnitDescription.Commit(ScreenMode.Add);
                MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                FillGrid();
            }
            catch { }
        }

        private void dvUnitDesc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dvUnitDesc[0, e.RowIndex].Value = _RowNumber;
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
                _listUnit.Clear();
                foreach (DataGridViewRow _Row in dvUnitDesc.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[4].FormattedValue) == true)
                    {
                        status = _Row.Cells[4].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            UnitDescription _Unit = new UnitDescription();
                            _Unit.UnitID = Convert.ToInt32(_Row.Cells[6].Value.ToString());
                            _listUnit.Add(_Unit);
                        }

                    }
                }
                UnitDescription _UnitDescription = new UnitDescription();
                _UnitDescription.UnitList = _listUnit;
                if (_listUnit.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected Unit(s) will be Deleted. Do You Want to Delete?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _UnitDescription.Commit(ScreenMode.Delete);
                        MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        private void dvUnitDesc_DataError(object sender, DataGridViewDataErrorEventArgs anError)
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
        private void dvUnitDesc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dvUnitDesc.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dvUnitDesc.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void ostrpDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (_gridRowIndex < dvUnitDesc.Rows.Count - 1)
                    if (dvUnitDesc[6, _row].Value == null)
                        dvUnitDesc.Rows.RemoveAt(_row);
            }
            catch { }
        }
        private void dvUnitDesc_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dvUnitDesc[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dvUnitDesc[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dvUnitDesc.RowCount - 1);
                }

                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex == dvUnitDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvUnitDesc Should Not be Empty");
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex == dvUnitDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        // MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvUnitDesc Should Not be Empty");
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dvUnitDesc.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dvUnitDesc[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvUnitDesc[4, e.RowIndex].ReadOnly = true;
                        dvUnitDesc[4, e.RowIndex].Value = false;
                        dvUnitDesc.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }
            }
            catch { }
        }

        private void dvUnitDesc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    //dont remove these two lines
                    //purposefully i called two times 
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                }
            }
            catch { }
        }

        private void dvUnitDesc_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ostrpDelete.Visible = true;
            _variables.FnSetEnabledButton(btnSave);
            
        }

        private void dvUnitDesc_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnSave);
            
        }

        private void frmUnitMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method(s)

        private bool FormValidation()
        {
            bool valid = true;
            for (int t = 0; t < dvUnitDesc.Rows.Count - 1; t++)
            {
                if (dvUnitDesc[1, t].Value == null)
                {
                    MessageBox.Show("Please Enter Unit.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dvUnitDesc[1, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (FindDuplicateUnit())
                {
                    MessageBox.Show("Please Remove The Duplicate Unit.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dvUnitDesc[1, t].Selected = true;
                    break;
                }
            }
            
            return valid;
        }

        private bool UpdateFormValidation(int columnIndex, int rowIndex)
        {
            bool valid = true;
            if (dvUnitDesc[1, rowIndex].Value == null)
            {
                dvUnitDesc[1, rowIndex].ErrorText = "Please Enter Unit.";
                dvUnitDesc[1, rowIndex].Selected = true;
                valid = false;
            }
            else if (FindDuplicateUnit())
            {
                dvUnitDesc[1, rowIndex].ErrorText = "Please Remove Duplicate Role.";
                valid = false;
                dvUnitDesc[1, rowIndex].Selected = true;
            }
            return valid;
        }

        private bool FindDuplicateUnit()
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dvUnitDesc.Rows.Count;
            rCountWithEntries = 0;

            // Loop to count the number of dvUnitDesc entered
            for (int i = 0; i < rCount; i++)
            {

                if (dvUnitDesc[1, i].Value != null && dvUnitDesc[1, i].Value.ToString().Trim() != "")
                {
                    rCountWithEntries = rCountWithEntries + 1;
                }
                else
                {
                    break;
                }
            }
            string[] arDuplicate = new string[rCountWithEntries];
            // If dvUnitDesc have been entered, then it is saved
            if (rCountWithEntries > 0)
            {
                int j = 0;
                for (int i = 0; i < rCountWithEntries; i++)
                {
                    if (dvUnitDesc[1, i].Value != null && dvUnitDesc[1, i].Value.ToString().Trim() != "")
                    {
                        arDuplicate[j] = dvUnitDesc[1, i].Value.ToString();
                        j++;
                    }
                }

                Array.Sort(arDuplicate);
                j = 0;
                string tempDuplicate = arDuplicate[0];
                for (int i = 1; i < rCountWithEntries; i++)
                {
                    if (tempDuplicate != arDuplicate[i])
                    {
                        tempDuplicate = arDuplicate[i];
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
                _listUnit = UnitDescription.GetEnableDisableUnit(_appConnection, EnableDisable);

                dvUnitDesc.Rows.Clear();
                foreach (UnitDescription _UnitDescription in _listUnit)
                {
                    dvUnitDesc.Rows.Add();
                    dvUnitDesc.Rows[_RowIndex].ReadOnly = true;
                    dvUnitDesc[6, _RowIndex].Value = _UnitDescription.UnitID.ToString();
                    dvUnitDesc[0, _RowIndex].Value = _RowIndex + 1;
                    dvUnitDesc[1, _RowIndex].Value = _UnitDescription.Unit;
                    DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dvUnitDesc.Rows[_RowIndex].Cells["UnitEdit"];
                    DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dvUnitDesc.Rows[_RowIndex].Cells["UnitStatus"];
                    buttonEdit.Enabled = true;
                    buttonStatus.Enabled = true;
                    UnitEdit.UseColumnTextForButtonValue = false;
                    dvUnitDesc[2, _RowIndex].Value = "Edit";
                    UnitStatus.UseColumnTextForButtonValue = false;
                    if (_ShowStatus == ShowStatus.Disabled)
                        dvUnitDesc[3, _RowIndex].Value = "Enable";
                    else
                        dvUnitDesc[3, _RowIndex].Value = "Disable";
                    _RowIndex++;
                }
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetDisabledButton(btnDelete);
                
                ostrpDelete.Visible = false;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Unit Master", "frmUnitMaster", "FillGrid", ex.Message);
            }
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 4)
            {
                for (int i = 0; i < dvUnitDesc.RowCount - 1; i++)
                {
                    if (dvUnitDesc.Rows[i].Cells[4].Value != null)
                        if (Convert.ToBoolean(dvUnitDesc.Rows[i].Cells[4].Value) == true)
                        {
                            delSelected = true;
                        }
                }
                if (delSelected == true)
                {
                    _variables.FnSetEnabledButton(btnDelete);
                    
                }
                else
                {
                    _variables.FnSetDisabledButton(btnDelete);
                    
                }
            }
            this.Validate();
        }

        private void UpdateUnit(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dvUnitDesc.Columns.Add(column2);
                dvUnitDesc.Columns.Add(column3);
                dvUnitDesc.AllowUserToAddRows = false;
                dvUnitDesc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dvUnitDesc.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dvUnitDesc.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvUnitDesc.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvUnitDesc.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dvUnitDesc.Rows[RowIndex].ReadOnly = false;
                dvUnitDesc.CellClick += new DataGridViewCellEventHandler(UpdateCancelClick);
            }
            catch (Exception ex)
            {


                ErrorLog.LogErrorMessageToDB("Unit Master", "frmUnitMaster", "UpdateUnit", ex.Message);
            }
        }

        private void SettingGridColumnOrder()
        {
            UnitSno.DisplayIndex = 0;
            UnitDesc.DisplayIndex = 1;
            UnitEdit.DisplayIndex = 2;
            UnitStatus.DisplayIndex = 3;
            UnitDelete.DisplayIndex = 4;
            UnitEditingChk.DisplayIndex = 5;
            Unitno.DisplayIndex = 6;
            UnitSno.Visible = true;
            UnitSno.ReadOnly = true;
            UnitDesc.Visible = true;
            UnitEdit.Visible = true;
            UnitStatus.Visible = true;
            UnitDelete.Visible = true;
            UnitEditingChk.Visible = false;
            Unitno.Visible = false;
            dvUnitDesc.AllowUserToAddRows = true;
        }

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnButtonTheme(btnSave);
            _variables.FnButtonTheme(btnDelete);
            _variables.FnButtonTheme(btnClose);
            _variables.FnGridTheme(dvUnitDesc);
            _variables.FnSetToolTip(btnClose, "Alt+C Close");
            _variables.FnSetToolTip(btnDelete, "Alt+D Delete");
            _variables.FnSetToolTip(btnSave, "Alt+S Save");
            _variables.FnSubTitleTheme(lblStatus);
        }

        #endregion

    }
}