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
    public partial class frmProductMaterial : Form
    {

        #region Constructor(s)

		public frmProductMaterial()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        
		ApplicationConnection _applicationConnection = new ApplicationConnection();
        ShowStatus _ShowStatus;
        List<Material> _listMaterial = new List<Material>();
		internal string helpFile = "\\Help\\HelpFile.chm";
        private int _gridRowIndex = 0;
        private int _row = 0;
        private int _col = 0;

        #endregion

        #region Private Event(s)

        private void frmProductMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                dgMaterial.EnableHeadersVisualStyles = false;
                FillShowStatus();
                SettingGridColumnOrder();
                MaterialDisplay();
				LoadSupplier();
                UnitDisplay();
	            TaxDisplay();
                ApplicationHelp.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelp.SetHelpKeyword(this, "frmProductMaterial.htm");
                ApplicationHelp.SetHelpNavigator(this, HelpNavigator.Topic);
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

        private void dgMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 9)
                {
                    if (dgMaterial.Rows[e.RowIndex].Cells[13].Value != null)
                    {
                        Editinggrid.Visible = false;
                        EnabledDisabled.Visible = false;
                        DeleteInvest.Visible = false;
                        UpdateMaterial(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    if (dgMaterial.Rows[e.RowIndex].Cells[13].Value != null)
                    {
                        DialogResult isQuit;
                        TransactionResult _result = null;
                        if (dgMaterial[10, e.RowIndex].Value.ToString() == "Enable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Enabled?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
	                            _result = Material.EnableDisableMaterial(_applicationConnection, Convert.ToInt32(dgMaterial[13, e.RowIndex].Value.ToString()), true);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Material Description Successfully Enabled.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Enabling Material Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        else if (dgMaterial[10, e.RowIndex].Value.ToString() == "Disable")
                        {
                            isQuit = MessageBox.Show("Are You Sure This Record Should be Disabled?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (isQuit == DialogResult.Yes)
                            {
								_result = Material.EnableDisableMaterial(_applicationConnection, Convert.ToInt32(dgMaterial[13, e.RowIndex].Value.ToString()), false);
                                if (_result.Status == TransactionStatus.Success)
                                    MessageBox.Show("Material Description Successfully Disabled.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                else
                                    MessageBox.Show("Failure Disabling Material Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }
                }
                else if (e.ColumnIndex == 11)
                {
                    if (dgMaterial.Rows[e.RowIndex].Cells[13].Value != null)
                    {
                        dgMaterial[11, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgMaterial[11, e.RowIndex].ReadOnly = true;
                        dgMaterial[11, e.RowIndex].Value = false;
                        dgMaterial.Rows[e.RowIndex].Cells[11].Selected = false;
                    }
                }

                if (e.ColumnIndex == 11)
                {
                    dgMaterial_CellEndEdit(sender, e);
                }
            }
            catch { }
        }

        private void dgMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowNumber = 0;
                rowNumber = e.RowIndex + 1;
                dgMaterial[0, e.RowIndex].Value = rowNumber;
                dgMaterial[14, e.RowIndex].Value = Convert.ToInt32(dgMaterial[5, e.RowIndex].Value.ToString());
	            dgMaterial[15, e.RowIndex].Value = Convert.ToInt32(dgMaterial[6, e.RowIndex].Value.ToString());

                if (e.ColumnIndex == 11)
                {
                    //dont remove these two lines
                    //purposefully i called two times
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                    GridValueChanged(e.RowIndex, e.ColumnIndex);
                }
            }
            catch { }
        }

        private void UpdateCancelClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgMaterial.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgMaterial.Rows[e.RowIndex].Cells["CancelRecord"];

                if ((dgMaterial.Columns[e.ColumnIndex].Name == "UpdateRecord") || (dgMaterial.Columns[e.ColumnIndex].Name == "CancelRecord"))
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dgMaterial.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidation(e.ColumnIndex,e.RowIndex)) { return; }
                            _listMaterial.Clear();
                            Material _Material = new Material();


                            _Material.ProductID = Convert.ToInt32(ddlProduct.SelectedValue);
                            _Material.MaterialID = Convert.ToInt32(dgMaterial.Rows[e.RowIndex].Cells[13].Value.ToString());
                            _Material.MaterialCode = dgMaterial.Rows[e.RowIndex].Cells[1].Value.ToString();
                            _Material.UnitID = Convert.ToInt32(dgMaterial.Rows[e.RowIndex].Cells[14].Value.ToString());
	                        _Material.TaxID = Convert.ToInt32(dgMaterial.Rows[e.RowIndex].Cells[15].Value.ToString());
                            _Material.MaterialDescription = Convert.ToString(dgMaterial.Rows[e.RowIndex].Cells[2].Value.ToString());
                            _Material.MaterialQuality = Convert.ToString(dgMaterial.Rows[e.RowIndex].Cells[3].Value.ToString());
							if (dgMaterial.Rows[e.RowIndex].Cells[4].Value == null)
								_Material.TaxInclusive = false;
							else
								_Material.TaxInclusive = Convert.ToBoolean(dgMaterial.Rows[e.RowIndex].Cells[4].Value.ToString());

                            _Material.MaterialRate = Convert.ToDecimal(dgMaterial.Rows[e.RowIndex].Cells[7].Value.ToString());
                            _Material.SpecialInstruction = dgMaterial.Rows[e.RowIndex].Cells[8].Value.ToString();
                            _Material.AuditUserID = MDIForm.UserID;
                            _listMaterial.Add(_Material);

							Material _materialList = new Material();
                            _materialList.MaterialList = _listMaterial;
                            TransactionResult result = null;
                            result = _materialList.Commit(ScreenMode.Edit);
                            dgMaterial.Columns.Remove("CancelRecord");
                            dgMaterial.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        if (dgMaterial.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            dgMaterial.Columns.Remove("CancelRecord");
                            dgMaterial.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }

                    }
                }
            }
            catch { }
          }

        private void cmdSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidation()) { return; }
                bool EnableDisable = true;
                if (_ShowStatus == ShowStatus.Disabled)
                    EnableDisable = false;

                _listMaterial.Clear();
                foreach (DataGridViewRow _Row in dgMaterial.Rows)
                {
                    if ((_Row.Cells[13].Value == null))
                    {
                        if ((_Row.Cells[1].Value != null) && (_Row.Cells[2].Value != null) && (_Row.Cells[3].Value != null))
                        {
                            Material _Material = new Material();
							_Material.SupplierID = Convert.ToInt32(ddlSupplier.SelectedValue);
                            _Material.ProductID = Convert.ToInt32(ddlProduct.SelectedValue);
                            _Material.MaterialCode = _Row.Cells[1].Value.ToString();
                            _Material.UnitID = Convert.ToInt32(_Row.Cells[14].Value.ToString());
	                        _Material.TaxID = Convert.ToInt32(_Row.Cells[15].Value.ToString());
	                        _Material.MaterialDescription = Convert.ToString(_Row.Cells[2].Value.ToString());
							_Material.MaterialQuality = Convert.ToString(_Row.Cells[3].Value.ToString());
							if(_Row.Cells[4].Value == null)
								_Material.TaxInclusive = false;
							else
								_Material.TaxInclusive = Convert.ToBoolean(_Row.Cells[4].Value.ToString());

                            _Material.MaterialRate = Convert.ToDecimal(_Row.Cells[7].Value.ToString());
                            if (_Row.Cells[8].Value != null)
                                _Material.SpecialInstruction = _Row.Cells[8].Value.ToString();
                            _Material.AuditUserID = MDIForm.UserID;
                            _Material.IsEnabled = EnableDisable;
                            _listMaterial.Add(_Material);
                        }
                    }
                }
				Material _LabTestParameter = new Material();
                _LabTestParameter.MaterialList = _listMaterial;
                TransactionResult _Result = null;
                _Result = _LabTestParameter.Commit(ScreenMode.Add);
                MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                FillGrid();
            }
            catch { }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                string status;
                _listMaterial.Clear();
                foreach (DataGridViewRow _Row in dgMaterial.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[11].FormattedValue) == true)
                    {
                        status = _Row.Cells[11].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            Material _Material = new Material();
                            _Material.MaterialID = Convert.ToInt32(_Row.Cells[13].Value);
                            _listMaterial.Add(_Material);
                        }

                    }
                }
				Material _LabTestParameter = new Material();
                _LabTestParameter.MaterialList = _listMaterial;
                if (_listMaterial.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected Material(s) will be Deleted. Do You Want to Delete?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _LabTestParameter.Commit(ScreenMode.Delete);
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
            catch { }
        }

        private void dgMaterial_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (ddlProduct.SelectedIndex == 0)
                MessageBox.Show("Please Select Material.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void dgMaterial_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dgMaterial[0, e.RowIndex].Value = _RowNumber;
	            DataGridViewComboBoxCell comboBoxCellTax = (DataGridViewComboBoxCell)this.dgMaterial.Rows[e.RowIndex].Cells[5];
	            DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)this.dgMaterial.Rows[e.RowIndex].Cells[6];
                comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
	            comboBoxCellTax.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
    }

        private void dgMaterial_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)this.dgMaterial.Rows[e.RowIndex].Cells[5];
                comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

	            DataGridViewComboBoxCell comboBoxCellTax = (DataGridViewComboBoxCell)this.dgMaterial.Rows[e.RowIndex].Cells[6];
	            comboBoxCellTax.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            }
            catch { }
        }
		
        private void ostrpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gridRowIndex < dgMaterial.Rows.Count - 1)
                    if (dgMaterial[13, _row].Value == null)
                        dgMaterial.Rows.RemoveAt(_row);
            }
            catch { }
        }

        private void dgMaterial_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dgMaterial.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dgMaterial.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void dgMaterial_DataError(object sender, DataGridViewDataErrorEventArgs anError)
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

        private void dgMaterial_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgMaterial[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dgMaterial[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dgMaterial.RowCount - 1);
                }

                if (e.ColumnIndex == 9)
                {
                    if (e.RowIndex == dgMaterial.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dgMaterial Should Not be Empty");
                    }
                }
                if (e.ColumnIndex == 10)
                {
                    if (e.RowIndex == dgMaterial.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        // MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dgMaterial Should Not be Empty");
                    }
                }
                else if (e.ColumnIndex == 11)
                {
                    if (dgMaterial.Rows[e.RowIndex].Cells[13].Value != null)
                    {
                        dgMaterial[11, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgMaterial[11, e.RowIndex].ReadOnly = true;
                        dgMaterial[11, e.RowIndex].Value = false;
                        dgMaterial.Rows[e.RowIndex].Cells[11].Selected = false;
                    }
                }

            }
            catch { }
        }

        private void dgMaterial_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ostrpDelete.Visible = true;
            _variables.FnSetEnabledButton(btnSave);
            
        }

        private void dgMaterial_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnSave);
            
        }

        private void dgMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgMaterial.CurrentCell.ColumnIndex == 7)
                {
                    if (e.Control is TextBox)
                    {
                        TextBox textBox = e.Control as TextBox;
                        textBox.KeyPress -= new KeyPressEventHandler(NumericTextBox_KeyPress);
                        textBox.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
                    }
                }
				else if ((dgMaterial.CurrentCell.ColumnIndex == 1) || (dgMaterial.CurrentCell.ColumnIndex == 2) || (dgMaterial.CurrentCell.ColumnIndex == 3) || (dgMaterial.CurrentCell.ColumnIndex == 8))
				{
					if (e.Control is TextBox)
					{
						TextBox textBox1 = e.Control as TextBox;
						textBox1.KeyPress -= new KeyPressEventHandler(CharacterTextBox_KeyPress);
						textBox1.KeyPress += new KeyPressEventHandler(CharacterTextBox_KeyPress);
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

        private void frmProductMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Methods(s)

        private void MaterialDisplay()
        {
	        Product pdt = new Product();
			ddlProduct.DataSource = pdt.GetAllProduct().Tables[0];
            ddlProduct.DisplayMember = "ProductName";
            ddlProduct.ValueMember = "ProductID";	        
	        ddlProduct.SelectedIndex = 0;
        }

		private void LoadSupplier()
		{
			SupplierDL pdt = new SupplierDL();
			ddlSupplier.DataSource = pdt.GetSupplierDropDownList(MDIForm.CompanyID).Tables[0];
			ddlSupplier.DisplayMember = "SupplierName";
			ddlSupplier.ValueMember = "SupplierID";
			ddlSupplier.SelectedIndex = 0;
		}

        private void UnitDisplay()
        {
            Unit.DataSource = UnitDescription.GetUnitList(_applicationConnection).Tables[0];
            Unit.DisplayMember = "Unit";
            Unit.ValueMember = "UnitID";
        }

	    private void TaxDisplay()
	    {
			ERP.DataLayer.Tax txTax = new ERP.DataLayer.Tax();
			Tax.DataSource = txTax.GetAllTax().Tables[0];
		    Tax.DisplayMember = "TaxName";
		    Tax.ValueMember = "TaxId";
	    }

        private bool FormValidation()
        {
            bool valid = true;
            for (int t = 0; t < dgMaterial.Rows.Count - 1; t++)
            {
                if (dgMaterial[1, t].Value == null)
                {
                    MessageBox.Show("Please Enter Material Code.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dgMaterial[1, t].Selected = true;
                    break;
                }
                else if (dgMaterial[2, t].Value == null)
                {
                    MessageBox.Show("Please Enter Material Description.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMaterial[2, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (dgMaterial[3, t].Value == null)
                {
                    MessageBox.Show("Please Enter Material Quality.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMaterial[3, t].Selected = true;
                    valid = false;
                    break;
                }                
                else if (dgMaterial[5, t].Value == null)
                {
                    MessageBox.Show("Please Select Tax.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMaterial[5, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (dgMaterial[6, t].Value == null)
                {
                    MessageBox.Show("Please Select Unit.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMaterial[6, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (dgMaterial[7, t].Value == null)
                {
                    MessageBox.Show("Please Enter Rate of Material.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMaterial[7, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (FindDuplicateMaterial())
                {
                    MessageBox.Show("Please Remove The Duplicate Material.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMaterial[1, t].Selected = true;
                    valid = false;
                    break;
                }
            }
            return valid;
        }
        private bool UpdateFormValidation(int columnIndex, int rowIndex)
        {
             bool valid = true;

                if (dgMaterial[1, rowIndex].Value == null)
                {
                    dgMaterial[1, rowIndex].ErrorText = "Please Enter Code.";
                    dgMaterial[1, rowIndex].Selected = true;
                    valid = false;
                }
                else if (dgMaterial[2, rowIndex].Value == null)
                {
                    dgMaterial[2, rowIndex].ErrorText = "Please Select Material Description.";
                    dgMaterial[2, rowIndex].Selected = true;
                    valid = false;
                }
                else if (dgMaterial[3, rowIndex].Value == null)
                {
                    dgMaterial[3, rowIndex].ErrorText = "Please Enter Material Quality.";
                    dgMaterial[3, rowIndex].Selected = true;
                    valid = false;
                }
                else if (dgMaterial[4, rowIndex].Value == null)
                {
                    dgMaterial[4, rowIndex].ErrorText = "Please Enter Tax Inclusive (True/ False).";
                    dgMaterial[4, rowIndex].Selected = true;
                    valid = false;
                }
                else if (dgMaterial[5, rowIndex].Value == null)
                {
                    dgMaterial[5, rowIndex].ErrorText = "Please Enter Tax.";
                    dgMaterial[5, rowIndex].Selected = true;
                    valid = false;
                }
                else if (dgMaterial[6, rowIndex].Value == null)
                {
                    dgMaterial[6, rowIndex].ErrorText = "Please Enter Unit.";
                    dgMaterial[6, rowIndex].Selected = true;
                    valid = false;
                }
                else if (dgMaterial[7, rowIndex].Value == null)
                {
                    dgMaterial[7, rowIndex].ErrorText = "Please Enter Rate of Material.";
                    dgMaterial[7, rowIndex].Selected = true;
                    valid = false;
                }
              
                else if (FindDuplicateMaterial())
                {
                    dgMaterial[1, rowIndex].ErrorText = "Please Remove Duplicate Material.";
                    dgMaterial[1, rowIndex].Selected = true;
                    valid = false;
                }
                return valid;
        }

        private bool FindDuplicateMaterial()
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dgMaterial.Rows.Count;
            rCountWithEntries = 0;

            // Loop to count the number of Material entered
            for (int i = 0; i < rCount; i++)
            {

                if (dgMaterial[1, i].Value != null && dgMaterial[1, i].Value.ToString().Trim() != "")
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
                    if (dgMaterial[1, i].Value != null && dgMaterial[1, i].Value.ToString().Trim() != "")
                    {
                        arPatientDuplicate[j] = dgMaterial[1, i].Value.ToString();
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
            if (ddlProduct.SelectedIndex != 0)
            {
                try
                {
                    int _RowIndex = 0;
                    bool EnableDisable = true;
                    if (_ShowStatus == ShowStatus.Disabled)
                        EnableDisable = false;
                    _listMaterial = Material.GetEnableDisableMaterial(_applicationConnection, Convert.ToInt32(ddlProduct.SelectedValue), Convert.ToInt32(ddlSupplier.SelectedValue), EnableDisable);

                    dgMaterial.Rows.Clear();
                    foreach (Material _Material in _listMaterial)
                    {
                        dgMaterial.Rows.Add();
                        dgMaterial.Rows[_RowIndex].ReadOnly = true;
                        dgMaterial[13, _RowIndex].Value = _Material.MaterialID.ToString();
                        dgMaterial[0, _RowIndex].Value = _RowIndex + 1;
                        dgMaterial[1, _RowIndex].Value = _Material.MaterialCode;
	                    dgMaterial[2, _RowIndex].Value = _Material.MaterialDescription;
	                    dgMaterial[3, _RowIndex].Value = _Material.MaterialQuality;
                        dgMaterial[4, _RowIndex].Value = _Material.TaxInclusive;
						dgMaterial[5, _RowIndex].Value = _Material.Unit;
						dgMaterial[6, _RowIndex].Value = _Material.TaxName;	                    
	                    dgMaterial[7, _RowIndex].Value = _Material.MaterialRate;
                        dgMaterial[8, _RowIndex].Value = _Material.SpecialInstruction.ToString();
                        dgMaterial[14, _RowIndex].Value = _Material.UnitID.ToString();
	                    dgMaterial[15, _RowIndex].Value = _Material.TaxID.ToString();
                        DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dgMaterial.Rows[_RowIndex].Cells["Editinggrid"];
                        DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dgMaterial.Rows[_RowIndex].Cells["EnabledDisabled"];
                        buttonEdit.Enabled = true;
                        buttonStatus.Enabled = true;
                        Editinggrid.UseColumnTextForButtonValue = false;
                        dgMaterial[9, _RowIndex].Value = "Edit";
                        EnabledDisabled.UseColumnTextForButtonValue = false;
                        if (_ShowStatus == ShowStatus.Disabled)
                            dgMaterial[10, _RowIndex].Value = "Enable";
                        else
                            dgMaterial[10, _RowIndex].Value = "Disable";
                        _RowIndex++;
                    }
                    _variables.FnSetDisabledButton(btnSave);
                    _variables.FnSetDisabledButton(btnDelete);
                    
                    dgMaterial.AllowUserToAddRows = true;
                    ostrpDelete.Visible = false;
                }
                catch (Exception ex)
                {
	                ErrorLog.LogErrorMessageToDB("Material", "frmProductMaterial", "FillGrid", ex.Message);
                }
            }
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 11)
            {
                for (int i = 0; i < dgMaterial.RowCount - 1; i++)
                {
                    if (dgMaterial.Rows[i].Cells[11].Value != null)
                        if (Convert.ToString(dgMaterial.Rows[i].Cells[11].Value) == "1")
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

        private void UpdateMaterial(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dgMaterial.Columns.Add(column2);
                dgMaterial.Columns.Add(column3);
                dgMaterial.AllowUserToAddRows = false;
                dgMaterial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgMaterial.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dgMaterial.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgMaterial.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgMaterial.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dgMaterial.Rows[RowIndex].ReadOnly = false;

                dgMaterial.CellClick += new DataGridViewCellEventHandler(UpdateCancelClick);
            }
            catch (Exception ex)
            {
	            ErrorLog.LogErrorMessageToDB("Material", "frmProductMaterial", "UpdateMaterial", ex.Message);
            }
        }

        private void SettingGridColumnOrder()
        {
            serialno.DisplayIndex = 0;
            MaterialCode.DisplayIndex = 1;
            MaterialDescription.DisplayIndex = 2;
            MaterialQuality.DisplayIndex = 3;
            TaxInclusive.DisplayIndex = 4;            
            Unit.DisplayIndex = 5;
			Tax.DisplayIndex = 6;
	        Rate.DisplayIndex = 7;
            SpecialInstruction.DisplayIndex = 8;
            Editinggrid.DisplayIndex = 9;
            EnabledDisabled.DisplayIndex = 10;
            DeleteInvest.DisplayIndex = 11;
            Edithiddengrid.DisplayIndex = 12;
            Sno.DisplayIndex = 13;
            gUnitID.DisplayIndex = 14;
			gTaxID.DisplayIndex = 15;
            serialno.Visible = true;
            serialno.ReadOnly = true;
	        MaterialCode.Visible = true;
	        MaterialDescription.Visible = true;
	        MaterialQuality.Visible = true;
	        TaxInclusive.Visible = true;
	        Tax.Visible = true;
	        Unit.Visible = true;
	        Rate.Visible = true;
            SpecialInstruction.Visible = true;
            Editinggrid.Visible = true;
            EnabledDisabled.Visible = true;
            DeleteInvest.Visible = true;
            Edithiddengrid.Visible = false;
            Sno.Visible = false;
			gTaxID.Visible = false;
            dgMaterial.AllowUserToAddRows = true;
        }

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnButtonTheme(btnSave);
            _variables.FnButtonTheme(btnDelete);
            _variables.FnButtonTheme(btnClose);
            _variables.FnGridTheme(dgMaterial);
            _variables.FnSetToolTip(btnClose, "Alt+C Close");
            _variables.FnSetToolTip(btnDelete, "Alt+D Delete");
            _variables.FnSetToolTip(btnSave, "Alt+S Save");
            _variables.FnSubTitleTheme(lblMaterial);
            _variables.FnSubTitleTheme(lblStatus);
        }

        #endregion

		private void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (ddlSupplier.SelectedIndex != 0)
					FillGrid();

				if (ddlSupplier.SelectedIndex == 0)
				{
					dgMaterial.Rows.Clear();
					dgMaterial.AllowUserToAddRows = false;
				}
				ostrpDelete.Visible = false;
			}
			catch { }
		}

        private void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSupplier.SelectedIndex != 0)
                    FillGrid();

                if (ddlSupplier.SelectedIndex == 0)
                {
                    dgMaterial.Rows.Clear();
                    dgMaterial.AllowUserToAddRows = false;
                }
                ostrpDelete.Visible = false;
            }
            catch { }
        }

    }
}