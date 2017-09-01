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
    public partial class frmStockMaster : Form
    {
        #region Constructors

		public frmStockMaster()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
        ShowStatus _ShowStatus;
		List<StockDescription> _listStockMaster = new List<StockDescription>();
        internal string helpFile = "\\Help\\HelpFile.chm";
        ScreenMode userMode;
        private int _gridRowIndex = 0;
        private int _row = 0;
        private int _col = 0;

        #endregion

        #region Private Event(s)

        private void frmStocking_Load(object sender, EventArgs e)
        {
            try
            {
                ostrpDelete.Visible = false;
                SettingGridColumnOrder();
                FillShowStatus();
                
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetDisabledButton(btnDelete);
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmStocking.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                BindProductDropdown();
                LoadDefaultColorandFonts();
            }
            catch { }
        }
        private void BindProductDropdown()
        {
            Product productService = new Product();
            List<Product> lstProduct = productService.GetAllProductList();
            lstProduct.Insert(0, new Product(0, "-- Select Product --"));
            ddlProduct.DataSource = lstProduct;
            ddlProduct.DisplayMember = "ProductName";
            ddlProduct.ValueMember = "ProductId";
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

        private void dvStockingDesc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 5)
                {
                    if (dvStockingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        StockEdit.Visible = false;
                        StockStatus.Visible = false;
                        StockDelete.Visible = false;
                        UpdateStock(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    if (dvStockingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        DialogResult isQuit;
                        TransactionResult _result = null;
                        if (dvStockingDesc[6, e.RowIndex].Value.ToString() == "Enable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Enabled?", "ApplicationName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = StockDescription.EnableDisableStock(_appConnection, Convert.ToInt32(dvStockingDesc[9, e.RowIndex].Value.ToString()), true);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Stock Description Successfully Enabled.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Enabling Stock Description.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        else if (dvStockingDesc[6, e.RowIndex].Value.ToString() == "Disable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Disabled?", "ApplicationName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
                                _result = StockDescription.EnableDisableStock(_appConnection, Convert.ToInt32(dvStockingDesc[9, e.RowIndex].Value.ToString()), false);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Stock Description Successfully Disabled.", "ApplicationName",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Disabling Stock Description.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    if (dvStockingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        dvStockingDesc[7, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvStockingDesc[7, e.RowIndex].ReadOnly = true;
                        dvStockingDesc[7, e.RowIndex].Value = false;
                    }
                }

                if (e.ColumnIndex == 7)
                {
                    dvStockingDesc_CellEndEdit(sender, e);
                }
               
            }
            catch(Exception ex)
            {
	            ErrorLog.LogErrorMessageToDB("Stocking", "frmStocking", "dvStockingDesc_CellContentClick", ex.InnerException.ToString());
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidation()) { return; }
            bool EnableDisable = true;
            if (_ShowStatus == ShowStatus.Disabled)
                EnableDisable = false;

            _listStockMaster.Clear();
	        StockDescription stockMaster = new StockDescription();
            foreach (DataGridViewRow row in dvStockingDesc.Rows)
            {
                if ((row.Cells[9].Value == null))
                {
                    if ((row.Cells[3].Value != null) && (row.Cells[4].Value != null))
                    {

	                    //stockMaster.ServiceTax = Convert.ToInt32(_Row.Cells[1].Value.ToString());
	                    //stockMaster. = _Row.Cells[2].Value.ToString();
                        stockMaster.MaterialID = Convert.ToInt32(ddlMaterial.SelectedValue.ToString());
	                    stockMaster.AvailableCount = Convert.ToInt32(row.Cells[3].Value.ToString());
						stockMaster.SupplierMaterialPrice= Convert.ToDecimal(row.Cells[4].Value.ToString());
	                    stockMaster.AuditID = MDIForm.UserID;
	                    stockMaster.IsEnabled = EnableDisable;
						_listStockMaster.Add(stockMaster);
                    }
                }
            }
	        stockMaster.StockList = _listStockMaster;
            TransactionResult _Result = null;
			_Result = stockMaster.Commit(ScreenMode.Add);
            MessageBox.Show(_Result.Message, "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            FillGrid();
        }

        private void ostrpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvStockingDesc[9, _row].Value == null)
                    if (userMode == ScreenMode.Add)
                    {
                        if (_gridRowIndex < dvStockingDesc.Rows.Count - 1)
                            if (dvStockingDesc[9, _row].Value == null)
                                dvStockingDesc.Rows.RemoveAt(_row);
                    }
            }
            catch { }
        }

        private void dvStockingDesc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dvStockingDesc.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dvStockingDesc.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void dvStockingDesc_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dvStockingDesc[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dvStockingDesc[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dvStockingDesc.RowCount - 1);
                }

                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex == dvStockingDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                    }
                }
                if (e.ColumnIndex == 6)
                {
                    if (e.RowIndex == dvStockingDesc.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    if (dvStockingDesc.Rows[e.RowIndex].Cells[9].Value != null)
                    {
                        dvStockingDesc[7, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dvStockingDesc[7, e.RowIndex].ReadOnly = true;
                        dvStockingDesc[7, e.RowIndex].Value = false;
                        dvStockingDesc.Rows[e.RowIndex].Cells[7].Selected = false;
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
                _listStockMaster.Clear();
	            StockDescription stockMaster = new StockDescription();
                foreach (DataGridViewRow row in dvStockingDesc.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[7].FormattedValue) == true)
                    {
                        status = row.Cells[7].Value.ToString();
                        if (status == "1" || status == "True")
                        {

	                        stockMaster.StockID = Convert.ToInt32(row.Cells[9].Value.ToString());
							_listStockMaster.Add(stockMaster);
                        }

                    }
                }

	            stockMaster.StockList = _listStockMaster;
                if (_listStockMaster.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected Stock(s) will be Deleted. Do You Want to Delete?", "ApplicationName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    if (isQuit == DialogResult.Yes)
                    {
						_Result = stockMaster.Commit(ScreenMode.Delete);
                        MessageBox.Show(_Result.Message, "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvStockingDesc.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvStockingDesc.Rows[e.RowIndex].Cells["CancelRecord"];

                if (dvStockingDesc.Columns[e.ColumnIndex].Name == "UpdateRecord" || dvStockingDesc.Columns[e.ColumnIndex].Name == "CancelRecord")
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dvStockingDesc.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidation(e.ColumnIndex, e.RowIndex)) { return; }
                            _listStockMaster.Clear();
							StockDescription stockMaster = new StockDescription();
                            stockMaster.StockID = Convert.ToInt32(dvStockingDesc.Rows[e.RowIndex].Cells[9].Value.ToString());
                            //stockMaster.StockCode = dvStockingDesc.Rows[e.RowIndex].Cells[1].Value.ToString();
                           // stockMaster.Description = dvStockingDesc.Rows[e.RowIndex].Cells[2].Value.ToString();
                            stockMaster.AvailableCount = Convert.ToInt32(dvStockingDesc.Rows[e.RowIndex].Cells[3].Value.ToString());
                            stockMaster.SupplierMaterialPrice = Convert.ToDecimal(dvStockingDesc.Rows[e.RowIndex].Cells[4].Value.ToString());
                            stockMaster.AuditID = MDIForm.UserID;

                            stockMaster.AddEditOption = 1;

                            bool EnableDisable = true;
                            if (_ShowStatus == ShowStatus.Disabled)
                                EnableDisable = false;

                            stockMaster.IsEnabled = EnableDisable;
                            _listStockMaster.Add(stockMaster);


	                        stockMaster.StockList = _listStockMaster;
                            TransactionResult _Result = null;
							_Result = stockMaster.Commit(ScreenMode.Add);
                           // dvStockingDesc.Columns.Remove("CancelRecord");
                            //dvStockingDesc.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        if (dvStockingDesc.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            //dvStockingDesc.Columns.Remove("CancelRecord");
                            //dvStockingDesc.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
            }
            catch { }
        }

        private void dvStockingDesc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dvStockingDesc[0, e.RowIndex].Value = _RowNumber;

                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
        }

        private void dvStockingDesc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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

        private void dvStockingDesc_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                ostrpDelete.Visible = true;
                _variables.FnSetEnabledButton(btnSave);
                
            }
            catch { }
        }

        private void dvStockingDesc_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnSave);
            
        }

        private void dvStockingDesc_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dvStockingDesc.CurrentCell.ColumnIndex == 3)
                {
                    if (e.Control is TextBox)
                    {
                        TextBox textBox = e.Control as TextBox;
                        textBox.KeyPress -= new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                        textBox.KeyPress += new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                    }
                }
                else if (dvStockingDesc.CurrentCell.ColumnIndex == 4)
                {
                    if (e.Control is TextBox)
                    {
						TextBox textBox = e.Control as TextBox;
	                    textBox.KeyPress -= new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
	                    textBox.KeyPress += new KeyPressEventHandler(NumericNoDecimalTextBox_KeyPress);
                    }
                }
                else if ((dvStockingDesc.CurrentCell.ColumnIndex == 2))
                {
                    if (e.Control is TextBox)
                    {
						TextBox textBox = e.Control as TextBox;
	                    textBox.KeyPress -= new KeyPressEventHandler(CharacterTextBox_KeyPress);
	                    textBox.KeyPress += new KeyPressEventHandler(CharacterTextBox_KeyPress);
                    }
                }
                else if ((dvStockingDesc.CurrentCell.ColumnIndex == 1))
                {
                    if (e.Control is TextBox)
                    {
						TextBox textBox = e.Control as TextBox;
	                    textBox.KeyPress -= new KeyPressEventHandler(CharacterTextBox_KeyPress);
	                    textBox.KeyPress += new KeyPressEventHandler(CharacterTextBox_KeyPress);
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

        private void frmStocking_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method(s)

        private void SettingGridColumnOrder()
        {
            StockSno.DisplayIndex = 0;
            StockCode.DisplayIndex = 1;
            StockDesc.DisplayIndex = 2;
            StockPrice.DisplayIndex = 3;
            StockServiceTax.DisplayIndex = 4;
            StockEdit.DisplayIndex = 5;
            StockStatus.DisplayIndex = 6;
            StockDelete.DisplayIndex = 7;
            StockEditingChk.DisplayIndex = 8;
            Stockno.DisplayIndex = 9;

            StockSno.Visible = true;
            StockSno.ReadOnly = true;
			StockCode.Visible = false;
            StockDesc.Visible = false;
            StockPrice.Visible = true;
            StockServiceTax.Visible = true;
            StockEdit.Visible = true;
            StockStatus.Visible = true;
            StockDelete.Visible = true;
            StockEditingChk.Visible = false;
            Stockno.Visible = false;
            dvStockingDesc.AllowUserToAddRows = true;
        }

        private void UpdateStock(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dvStockingDesc.Columns.Add(column2);
                dvStockingDesc.Columns.Add(column3);
                dvStockingDesc.AllowUserToAddRows = false;
                dvStockingDesc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dvStockingDesc.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dvStockingDesc.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dvStockingDesc.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dvStockingDesc.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dvStockingDesc.Rows[RowIndex].ReadOnly = false;

                dvStockingDesc.CellClick += new DataGridViewCellEventHandler(UpdateCancelClick);
            }
            catch (Exception ex)
            {
	            ErrorLog.LogErrorMessageToDB("Stocking", "frmStocking", "UpdateStock", ex.InnerException.ToString());
            }
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 7)
            {
                for (int i = 0; i < dvStockingDesc.RowCount - 1; i++)
                {
                    if (dvStockingDesc.Rows[i].Cells[7].Value != null)
                        if (Convert.ToBoolean(dvStockingDesc.Rows[i].Cells[7].Value) == true)
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
            _variables.FnGridTheme(dvStockingDesc);
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
            if (ddlProduct.SelectedIndex != 0 && ddlProduct.SelectedValue != null && ddlMaterial.SelectedValue != null && ddlMaterial.SelectedIndex != 0)
            {
                try
                {
                    int _RowIndex = 0;
                    bool EnableDisable = true;
                    if (_ShowStatus == ShowStatus.Disabled)
                        EnableDisable = false;
                    _listStockMaster = StockDescription.GetEnableDisableStock(_appConnection, Convert.ToInt32(ddlMaterial.SelectedValue.ToString()), EnableDisable);

                    dvStockingDesc.Rows.Clear();
                    foreach (StockDescription _StockMaster in _listStockMaster)
                    {
                        dvStockingDesc.Rows.Add();
                        dvStockingDesc.Rows[_RowIndex].ReadOnly = true;
                        dvStockingDesc[9, _RowIndex].Value = _StockMaster.StockID.ToString();
                        dvStockingDesc[0, _RowIndex].Value = _RowIndex + 1;
                        //dvStockingDesc[1, _RowIndex].Value = _StockMaster.StockCode;
                        //dvStockingDesc[2, _RowIndex].Value = _StockMaster.Description;
                        dvStockingDesc[3, _RowIndex].Value = _StockMaster.AvailableCount;
                        dvStockingDesc[4, _RowIndex].Value = _StockMaster.SupplierMaterialPrice;
                        DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dvStockingDesc.Rows[_RowIndex].Cells["StockEdit"];
                        DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dvStockingDesc.Rows[_RowIndex].Cells["StockStatus"];
                        buttonEdit.Enabled = true;
                        buttonStatus.Enabled = true;
                        StockEdit.UseColumnTextForButtonValue = false;
                        dvStockingDesc[5, _RowIndex].Value = "Edit";
                        StockStatus.UseColumnTextForButtonValue = false;
                        if (_ShowStatus == ShowStatus.Disabled)
                            dvStockingDesc[6, _RowIndex].Value = "Enable";
                        else
                            dvStockingDesc[6, _RowIndex].Value = "Disable";
                        _RowIndex++;
                    }
                    _variables.FnSetDisabledButton(btnSave);
                    _variables.FnSetDisabledButton(btnDelete);

                    userMode = ScreenMode.Add;
                    ostrpDelete.Visible = false;
                }
                catch (Exception ex)
                {
                    ErrorLog.LogErrorMessageToDB("Stocking", "frmStocking", "FillGrid", ex.InnerException.ToString());
                }
            }
        }

        private bool FormValidation()
        {
            bool valid = true;
            for (int t = 0; t < dvStockingDesc.Rows.Count - 1; t++)
            {
                if (dvStockingDesc[9, t].Value == null)
                {
					//if (dvStockingDesc[1, t].Value == null)
					//{
					//	MessageBox.Show("Please Enter The Stock Code.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					//	valid = false;
					//	dvStockingDesc[1, t].Selected = true;
					//	break;
					//}
					//else if (dvStockingDesc[2, t].Value == null)
					//{
					//	MessageBox.Show("Please Enter The Stock Description.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					//	valid = false;
					//	dvStockingDesc[2, t].Selected = true;
					//	break;
					//}
                    if (dvStockingDesc[3, t].Value == null)
                    {
                        MessageBox.Show("Please Enter The Availability.", "ApplicationName",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvStockingDesc[3, t].Selected = true;
                        break;
                    }
                    else if (dvStockingDesc[4, t].Value == null)
                    {
                        MessageBox.Show("Please Enter The Cost of the Material per item.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        valid = false;
                        dvStockingDesc[4, t].Selected = true;
                        break;
                    }
					//else if (FindDuplicateStock(2))
					//{
					//	MessageBox.Show("Please Remove The Duplicate Stock Description.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					//	valid = false;
					//	dvStockingDesc[2, t].Selected = true;
					//	break;
					//}
					//else if (FindDuplicateStock(1))
					//{
					//	MessageBox.Show("Please Remove The Duplicate Stock Code.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					//	valid = false;
					//	dvStockingDesc[1, t].Selected = true;
					//	break;
					//}
                    else if (dvStockingDesc[3, t].Value != null || dvStockingDesc[4, t].Value != null)
                    {
                        if (Utility.ValidateNumber(dvStockingDesc[3, t].Value.ToString()) <= 0)
                        {
                            dvStockingDesc[3, t].Value = null;
                            MessageBox.Show("Amount Should be Numeric.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            dvStockingDesc[3, t].Selected = true;
                            valid = false;
                            break;
                        }
                        if (Utility.ValidateNumber(dvStockingDesc[4, t].Value.ToString()) <= 0)
                        {
                            dvStockingDesc[4, t].Value = null;
                            MessageBox.Show("Price Should be Numeric.", "ApplicationName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            dvStockingDesc[4, t].Selected = true;
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
            
                if (Convert.ToString(dvStockingDesc[9,rowIndex].Value.ToString()) != null)
                {
					//if (dvStockingDesc[1, rowIndex].Value == null)
					//{
					//	dvStockingDesc[1, rowIndex].ErrorText = "Please Enter The Stock Code.";
					//	dvStockingDesc[1, rowIndex].Selected = true;
					//	valid = false;
					//}
					//else if (dvStockingDesc[2, rowIndex].Value == null)
					//{
					//	dvStockingDesc[2, rowIndex].ErrorText = "Please Enter The Stock Description.";
					//	dvStockingDesc[2, rowIndex].Selected = true;
					//	valid = false;
					//}
                    if (dvStockingDesc[3, rowIndex].Value == null)
                    {
                        dvStockingDesc[3, rowIndex].ErrorText = "Please Enter The Price.";
                        dvStockingDesc[3, rowIndex].Selected = true;
                        valid = false;
                    }
                    else if (dvStockingDesc[4, rowIndex].Value == null)
                    {
                        dvStockingDesc[4, rowIndex].ErrorText = "Please Enter The Service Tax.";
                        dvStockingDesc[4, rowIndex].Selected = true;
                        valid = false;
                    }
                    else if (dvStockingDesc[3, rowIndex].Value != null || dvStockingDesc[4, rowIndex].Value != null)
                    {
                        if (Utility.ValidateNumber(dvStockingDesc[3, rowIndex].Value.ToString()) <= 0)
                        {
                            dvStockingDesc[3, rowIndex].ErrorText = "Availability Should be Numeric.";
                            dvStockingDesc[3, rowIndex].Selected = true;
                            valid = false;
                        }
                        if (Utility.ValidateNumber(dvStockingDesc[4, rowIndex].Value.ToString()) <= 0)
                        {
                            dvStockingDesc[4, rowIndex].ErrorText = "Amount Should be Numeric.";
                            dvStockingDesc[4, rowIndex].Selected = true;
                            valid = false;
                        }
                    }
					//else if (FindDuplicateStock(2))
					//{
					//	dvStockingDesc[2, rowIndex].ErrorText = "Please Remove the Duplicate Stock Description.";
					//	dvStockingDesc[2, rowIndex].Selected = true;
					//	valid = false;
					//	dvStockingDesc.Focus();
					//}
					//else if (FindDuplicateStock(1))
					//{
					//	dvStockingDesc[1, rowIndex].ErrorText = "Please Remove the Duplicate Stock Code.";
					//	dvStockingDesc[1, rowIndex].Selected = true;
					//	valid = false;
					//	dvStockingDesc.Focus();
					//}
                }
            return valid;
        }

        private bool FindDuplicateStock(int _column)
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dvStockingDesc.Rows.Count;
            rCountWithEntries = 0;

            // Loop to count the number of complaints entered
            for (int i = 0; i < rCount; i++)
            {

                if (dvStockingDesc[_column, i].Value != null && dvStockingDesc[_column, i].Value.ToString().Trim() != "")
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
                    if (dvStockingDesc[_column, i].Value != null && dvStockingDesc[_column, i].Value.ToString().Trim() != "")
                    {
                        arPatientDuplicate[j] = dvStockingDesc[_column, i].Value.ToString();
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

		private void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (ddlProduct.SelectedIndex != 0)
            {
                int productId = Convert.ToInt32(ddlProduct.SelectedValue);
                //Product product = new Product(productId);
                //txtDescription.Text = product.Description;
                //txtQuantity.Text = Convert.ToString(1);
                //txtUnitPrice.Text = Convert.ToString(product.UnitPrice);
                //cmbTax.SelectedValue = product.TaxId;
                BindMaterialDropdown();
                ddlMaterial.Focus();
               
            }
            else
            {
                BindMaterialDropdown();
                
            }
		}

        private void BindMaterialDropdown()
        {
            if (ddlProduct.SelectedIndex != 0)
            {
                List<Material> lstMaterial = Material.GetMaterialRequisition(_appConnection, Convert.ToInt32(ddlProduct.SelectedValue));
                lstMaterial.Insert(0, new Material(0, "-- Select Material --"));
                ddlMaterial.DataSource = lstMaterial;
                ddlMaterial.DisplayMember = "MaterialDescription";
                ddlMaterial.ValueMember = "MaterialID";
            }
            else
            {
                List<Material> lstMaterial = new List<Material>();
                lstMaterial.Insert(0, new Material(0, "-- Select Material --"));
                ddlMaterial.DataSource = lstMaterial;
                ddlMaterial.DisplayMember = "MaterialDescription";
                ddlMaterial.ValueMember = "MaterialID";
            }
        }

		private void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillGrid();
		}
     
    }
}