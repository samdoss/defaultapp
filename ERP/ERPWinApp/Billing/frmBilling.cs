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
    public partial class frmBilling : Form
    {
        #region Constructors

        public frmBilling()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        
        ApplicationConnection _appConnection = new ApplicationConnection();
        ShowStatus _ShowStatus;
        List<BillDescription> _listBillMaster = new List<BillDescription>();
        internal string helpFile = "\\Help\\HelpFile.chm";
        ScreenMode userMode;
        private int _gridRowIndex = 0;
        private int _row = 0;
        private int _col = 0;

        #endregion

        #region Private Event(s)

        private void frmBilling_Load(object sender, EventArgs e)
        {
            try
            {
                ostrpDelete.Visible = false;
                SettingGridColumnOrder();
                FillShowStatus();
                FillGrid();
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetDisabledButton(btnDelete);
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmBilling.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
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

        private void dvBillingDesc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 5)
                {
                    if (dvBillingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        BillEdit.Visible = false;
                        BillStatus.Visible = false;
                        BillDelete.Visible = false;
                        UpdateBill(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    if (dvBillingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        DialogResult isQuit;
                        TransactionResult _result = null;
                        if (dvBillingDesc[6, e.RowIndex].Value.ToString() == "Enable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Enabled?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = BillDescription.EnableDisableBill(_appConnection, Convert.ToInt32(dvBillingDesc[9, e.RowIndex].Value.ToString()), true);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Bill Description Successfully Enabled.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Enabling Bill Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        else if (dvBillingDesc[6, e.RowIndex].Value.ToString() == "Disable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Disabled?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = BillDescription.EnableDisableBill(_appConnection, Convert.ToInt32(dvBillingDesc[9, e.RowIndex].Value.ToString()), false);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Bill Description Successfully Disabled.", "SoftwareName",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Disabling Bill Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    if (dvBillingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        dvBillingDesc[7, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvBillingDesc[7, e.RowIndex].ReadOnly = true;
                        dvBillingDesc[7, e.RowIndex].Value = false;
                    }
                }

                if (e.ColumnIndex == 7)
                {
                    dvBillingDesc_CellEndEdit(sender, e);
                }
               
            }
            catch(Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Billing", "frmBilling", "dvBillingDesc_CellContentClick", ex.Message);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidation()) { return; }
            bool EnableDisable = true;
            if (_ShowStatus == ShowStatus.Disabled)
                EnableDisable = false;

            _listBillMaster.Clear();
            foreach (DataGridViewRow _Row in dvBillingDesc.Rows)
            {
                if ((_Row.Cells[9].Value == null))
                {
                    if ((_Row.Cells[1].Value != null) && (_Row.Cells[2].Value != null) && (_Row.Cells[3].Value != null) && (_Row.Cells[4].Value != null))
                    {
                        BillDescription _BillMaster = new BillDescription();
                        _BillMaster.BillCode = _Row.Cells[1].Value.ToString();
                        _BillMaster.Description = _Row.Cells[2].Value.ToString();
                        _BillMaster.Price = Convert.ToInt32(_Row.Cells[3].Value.ToString());
                        _BillMaster.ServiceTax = Convert.ToInt32(_Row.Cells[4].Value.ToString());
                        _BillMaster.AuditUserID = MDIForm.UserID;
                        _BillMaster.IsEnabled = EnableDisable;
                        _listBillMaster.Add(_BillMaster);
                    }
                }
            }
            BillDescription _BillDescription = new BillDescription();
            _BillDescription.BillMaster = _listBillMaster;
            TransactionResult _Result = null;
            _Result = _BillDescription.Commit(ScreenMode.Add);
            MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            FillGrid();
        }

        private void ostrpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvBillingDesc[9, _row].Value == null)
                    if (userMode == ScreenMode.Add)
                    {
                        if (_gridRowIndex < dvBillingDesc.Rows.Count - 1)
                            if (dvBillingDesc[9, _row].Value == null)
                                dvBillingDesc.Rows.RemoveAt(_row);
                    }
            }
            catch { }
        }

        private void dvBillingDesc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dvBillingDesc.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dvBillingDesc.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void dvBillingDesc_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dvBillingDesc[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dvBillingDesc[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dvBillingDesc.RowCount - 1);
                }

                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex == dvBillingDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                    }
                }
                if (e.ColumnIndex == 6)
                {
                    if (e.RowIndex == dvBillingDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    if (dvBillingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        dvBillingDesc[7, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvBillingDesc[7, e.RowIndex].ReadOnly = true;
                        dvBillingDesc[7, e.RowIndex].Value = false;
                        dvBillingDesc.Rows[e.RowIndex].Cells[7].Selected = false;
                    }
                }

            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                string status;
                _listBillMaster.Clear();
                foreach (DataGridViewRow _Row in dvBillingDesc.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[7].FormattedValue) == true)
                    {
                        status = _Row.Cells[7].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            BillDescription _BillMaster = new BillDescription();
                            _BillMaster.BillDescriptionID = Convert.ToInt32(_Row.Cells[9].Value.ToString());
                            _listBillMaster.Add(_BillMaster);
                        }

                    }
                }
                BillDescription _BillDescription = new BillDescription();
                _BillDescription.BillMaster = _listBillMaster;
                if (_listBillMaster.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected Bill(s) will be Deleted. Do You Want to Delete?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _BillDescription.Commit(ScreenMode.Delete);
                        MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
            catch { }

        }

        private void UpdateCancelClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvBillingDesc.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvBillingDesc.Rows[e.RowIndex].Cells["CancelRecord"];

                if (dvBillingDesc.Columns[e.ColumnIndex].Name == "UpdateRecord" || dvBillingDesc.Columns[e.ColumnIndex].Name == "CancelRecord")
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dvBillingDesc.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidation(e.ColumnIndex, e.RowIndex)) { return; }
                            _listBillMaster.Clear();
                            BillDescription _BillMaster = new BillDescription();
                            _BillMaster.BillDescriptionID = Convert.ToInt32(dvBillingDesc.Rows[e.RowIndex].Cells[9].Value.ToString());
                            _BillMaster.BillCode = dvBillingDesc.Rows[e.RowIndex].Cells[1].Value.ToString();
                            _BillMaster.Description = dvBillingDesc.Rows[e.RowIndex].Cells[2].Value.ToString();
                            _BillMaster.Price = Convert.ToInt32(dvBillingDesc.Rows[e.RowIndex].Cells[3].Value.ToString());
                            _BillMaster.ServiceTax = Convert.ToInt32(dvBillingDesc.Rows[e.RowIndex].Cells[4].Value.ToString());
                            _BillMaster.AuditUserID = MDIForm.UserID;
                            _listBillMaster.Add(_BillMaster);

                            BillDescription _BillDescription = new BillDescription();
                            _BillDescription.BillMaster = _listBillMaster;
                            TransactionResult _Result = null;
                            _Result = _BillDescription.Commit(ScreenMode.Edit);
                            dvBillingDesc.Columns.Remove("CancelRecord");
                            dvBillingDesc.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        if (dvBillingDesc.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            dvBillingDesc.Columns.Remove("CancelRecord");
                            dvBillingDesc.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
            }
            catch { }
        }

        private void dvBillingDesc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dvBillingDesc[0, e.RowIndex].Value = _RowNumber;

                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
        }

        private void dvBillingDesc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
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

        private void dvBillingDesc_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                ostrpDelete.Visible = true;
                _variables.FnSetEnabledButton(btnSave);
                
            }
            catch { }
        }

        private void dvBillingDesc_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnSave);
            
        }

        private void dvBillingDesc_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dvBillingDesc.CurrentCell.ColumnIndex == 3)
                {
                    if (e.Control is TextBox)
                    {
                        TextBox _TextBox = e.Control as TextBox;
                        _TextBox.KeyPress -= new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                        _TextBox.KeyPress += new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                    }
                }
                else if (dvBillingDesc.CurrentCell.ColumnIndex == 4)
                {
                    if (e.Control is TextBox)
                    {
                        TextBox _TextBox = e.Control as TextBox;
                        _TextBox.KeyPress -= new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                        _TextBox.KeyPress += new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                    }
                }
                else if ((dvBillingDesc.CurrentCell.ColumnIndex == 2))
                {
                    if (e.Control is TextBox)
                    {
                        TextBox _TextBox1 = e.Control as TextBox;
                        _TextBox1.KeyPress -= new KeyPressEventHandler(CharacterTextBox_KeyPress);
                        _TextBox1.KeyPress += new KeyPressEventHandler(CharacterTextBox_KeyPress);
                    }
                }
                else if ((dvBillingDesc.CurrentCell.ColumnIndex == 1))
                {
                    if (e.Control is TextBox)
                    {
                        TextBox _TextBox1 = e.Control as TextBox;
                        _TextBox1.KeyPress -= new KeyPressEventHandler(CharacterTextBox_KeyPress);
                        _TextBox1.KeyPress += new KeyPressEventHandler(CharacterTextBox_KeyPress);
                    }
                }
            }
            catch { }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                Keys key = (Keys)e.KeyChar;
                if (!(key == Keys.Back || key == Keys.Delete))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void NumericNoDecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                Keys key = (Keys)e.KeyChar;
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                if (!(key == Keys.Back || key == Keys.Delete))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void CharacterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsLetterOrDigit(e.KeyChar))))
            {
                Keys key = (Keys)e.KeyChar;
                if (!(key == Keys.Space || e.KeyChar == '-' || key == Keys.Back || key == Keys.Delete || key == Keys.Separator))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void frmBilling_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method(s)

        private void SettingGridColumnOrder()
        {
            BillSno.DisplayIndex = 0;
            BillCode.DisplayIndex = 1;
            BillDesc.DisplayIndex = 2;
            BillPrice.DisplayIndex = 3;
            BillServiceTax.DisplayIndex = 4;
            BillEdit.DisplayIndex = 5;
            BillStatus.DisplayIndex = 6;
            BillDelete.DisplayIndex = 7;
            BillEditingChk.DisplayIndex = 8;
            Billno.DisplayIndex = 9;

            BillSno.Visible = true;
            BillSno.ReadOnly = true;
            BillDesc.Visible = true;
            BillPrice.Visible = true;
            BillServiceTax.Visible = true;
            BillEdit.Visible = true;
            BillStatus.Visible = true;
            BillDelete.Visible = true;
            BillEditingChk.Visible = false;
            Billno.Visible = false;
            dvBillingDesc.AllowUserToAddRows = true;
        }

        private void UpdateBill(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dvBillingDesc.Columns.Add(column2);
                dvBillingDesc.Columns.Add(column3);
                dvBillingDesc.AllowUserToAddRows = false;
                dvBillingDesc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dvBillingDesc.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dvBillingDesc.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvBillingDesc.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvBillingDesc.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dvBillingDesc.Rows[RowIndex].ReadOnly = false;

                dvBillingDesc.CellClick += new DataGridViewCellEventHandler(UpdateCancelClick);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Billing", "frmBilling", "UpdateBill",ex.Message);
            }
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 7)
            {
                for (int i = 0; i < dvBillingDesc.RowCount - 1; i++)
                {
                    if (dvBillingDesc.Rows[i].Cells[7].Value != null)
                        if (Convert.ToBoolean(dvBillingDesc.Rows[i].Cells[7].Value) == true)
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
        
        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnGridTheme(dvBillingDesc);
            _variables.FnSetToolTip(btnClose, "Alt+C Close");
            _variables.FnSetToolTip(btnDelete, "Alt+D Delete");
            _variables.FnSetToolTip(btnSave, "Alt+S Save");
            _variables.FnSubTitleTheme(lblStatus);
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
                _listBillMaster = BillDescription.GetEnableDisableBills(_appConnection, EnableDisable);

                 dvBillingDesc.Rows.Clear();
                 foreach (BillDescription _BillMaster in _listBillMaster)
                {
                    dvBillingDesc.Rows.Add();
                    dvBillingDesc.Rows[_RowIndex].ReadOnly = true;
                    dvBillingDesc[9, _RowIndex].Value = _BillMaster.BillDescriptionID.ToString();
                    dvBillingDesc[0, _RowIndex].Value = _RowIndex + 1;
                    dvBillingDesc[1, _RowIndex].Value = _BillMaster.BillCode;
                    dvBillingDesc[2, _RowIndex].Value = _BillMaster.Description;
                    dvBillingDesc[3, _RowIndex].Value = _BillMaster.Price;
                    dvBillingDesc[4, _RowIndex].Value = _BillMaster.ServiceTax;
                    DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dvBillingDesc.Rows[_RowIndex].Cells["BillEdit"];
                    DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dvBillingDesc.Rows[_RowIndex].Cells["BillStatus"];
                    buttonEdit.Enabled = true;
                    buttonStatus.Enabled = true;
                    BillEdit.UseColumnTextForButtonValue = false;
                    dvBillingDesc[5, _RowIndex].Value = "Edit";
                    BillStatus.UseColumnTextForButtonValue = false;
                    if (_ShowStatus == ShowStatus.Disabled)
                        dvBillingDesc[6, _RowIndex].Value = "Enable";
                    else
                        dvBillingDesc[6, _RowIndex].Value = "Disable";
                    _RowIndex++;
                }
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetDisabledButton(btnDelete);
                
                userMode = ScreenMode.Add;
                ostrpDelete.Visible = false;
            }
            catch (Exception ex)
            {   
                ErrorLog.LogErrorMessageToDB("Billing", "frmBilling", "FillGrid", ex.Message);
            }
        }

        private bool FormValidation()
        {
            bool valid = true;
            for (int t = 0; t < dvBillingDesc.Rows.Count - 1; t++)
            {
                if (dvBillingDesc[9, t].Value == null)
                {
                    if (dvBillingDesc[1, t].Value == null)
                    {
                        MessageBox.Show("Please Enter The Bill Code.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvBillingDesc[1, t].Selected = true;
                        break;
                    }
                    else if (dvBillingDesc[2, t].Value == null)
                    {
                        MessageBox.Show("Please Enter The Bill Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvBillingDesc[2, t].Selected = true;
                        break;
                    }
                    else if (dvBillingDesc[3, t].Value == null)
                    {
                        MessageBox.Show("Please Enter The Price.", "SoftwareName",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvBillingDesc[3, t].Selected = true;
                        break;
                    }
                    else if (dvBillingDesc[4, t].Value == null)
                    {
                        MessageBox.Show("Please Enter The Service Tax.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvBillingDesc[4, t].Selected = true;
                        break;
                    }
                    else if (FindDuplicateBill(2))
                    {
                        MessageBox.Show("Please Remove The Duplicate Bill Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvBillingDesc[2, t].Selected = true;
                        break;
                    }
                    else if (FindDuplicateBill(1))
                    {
                        MessageBox.Show("Please Remove The Duplicate Bill Code.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvBillingDesc[1, t].Selected = true;
                        break;
                    }
                    else if (dvBillingDesc[3, t].Value != null || dvBillingDesc[4, t].Value != null)
                    {
                        if (Utility.ValidateNumber(dvBillingDesc[3, t].Value.ToString()) <= 0)
                        {
                            dvBillingDesc[3, t].Value = null;
                            MessageBox.Show("Amount Should be Numeric.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            dvBillingDesc[3, t].Selected = true;
                            valid = false;
                            break;
                        }
                        if (Utility.ValidateNumber(dvBillingDesc[4, t].Value.ToString()) <= 0)
                        {
                            dvBillingDesc[4, t].Value = null;
                            MessageBox.Show("Service Tax Should be Numeric.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            dvBillingDesc[4, t].Selected = true;
                            valid = false;
                            break;
                        }
                    }
                }
            }
            
            return valid;
        }

        private bool UpdateFormValidation(int columnIndex,int rowIndex)
        {
            bool valid = true;
            
                if (Convert.ToString(dvBillingDesc[9,rowIndex].Value.ToString()) != null)
                {
                    if (dvBillingDesc[1, rowIndex].Value == null)
                    {
                        dvBillingDesc[1, rowIndex].ErrorText = "Please Enter The Bill Code.";
                        dvBillingDesc[1, rowIndex].Selected = true;
                        valid = false;
                    }
                    else if (dvBillingDesc[2, rowIndex].Value == null)
                    {
                        dvBillingDesc[2, rowIndex].ErrorText = "Please Enter The Bill Description.";
                        dvBillingDesc[2, rowIndex].Selected = true;
                        valid = false;
                    }
                    else if (dvBillingDesc[3, rowIndex].Value == null)
                    {
                        dvBillingDesc[3, rowIndex].ErrorText = "Please Enter The Price.";
                        dvBillingDesc[3, rowIndex].Selected = true;
                        valid = false;
                    }
                    else if (dvBillingDesc[4, rowIndex].Value == null)
                    {
                        dvBillingDesc[4, rowIndex].ErrorText = "Please Enter The Service Tax.";
                        dvBillingDesc[4, rowIndex].Selected = true;
                        valid = false;
                    }
                    else if (dvBillingDesc[3, rowIndex].Value != null || dvBillingDesc[4, rowIndex].Value != null)
                    {
                        if (Utility.ValidateNumber(dvBillingDesc[3, rowIndex].Value.ToString()) <= 0)
                        {
                            dvBillingDesc[3, rowIndex].ErrorText = "Amount Should be Numeric.";
                            dvBillingDesc[3, rowIndex].Selected = true;
                            valid = false;
                        }
                        if (Utility.ValidateNumber(dvBillingDesc[4, rowIndex].Value.ToString()) <= 0)
                        {
                            dvBillingDesc[4, rowIndex].ErrorText = "Service Tax Should be Numeric.";
                            dvBillingDesc[4, rowIndex].Selected = true;
                            valid = false;
                        }
                    }
                    else if (FindDuplicateBill(2))
                    {
                        dvBillingDesc[2, rowIndex].ErrorText = "Please Remove the Duplicate Bill Description.";
                        dvBillingDesc[2, rowIndex].Selected = true;
                        valid = false;
                        dvBillingDesc.Focus();
                    }
                    else if (FindDuplicateBill(1))
                    {
                        dvBillingDesc[1, rowIndex].ErrorText = "Please Remove the Duplicate Bill Code.";
                        dvBillingDesc[1, rowIndex].Selected = true;
                        valid = false;
                        dvBillingDesc.Focus();
                    }
                }
            return valid;
        }

        private bool FindDuplicateBill(int _column)
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dvBillingDesc.Rows.Count;
            rCountWithEntries = 0;

            // Loop to count the number of complaints entered
            for (int i = 0; i < rCount; i++)
            {

                if (dvBillingDesc[_column, i].Value != null && dvBillingDesc[_column, i].Value.ToString().Trim() != "")
                {
                    rCountWithEntries = rCountWithEntries + 1;
                }
                else
                {
                    break;
                }
            }
            string[] arPatientDuplicate = new string[rCountWithEntries];
            // If Complaints have been entered, then it is saved
            if (rCountWithEntries > 0)
            {
                int j = 0;
                for (int i = 0; i < rCountWithEntries; i++)
                {
                    if (dvBillingDesc[_column, i].Value != null && dvBillingDesc[_column, i].Value.ToString().Trim() != "")
                    {
                        arPatientDuplicate[j] = dvBillingDesc[_column, i].Value.ToString();
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

        #endregion
     
    }
}