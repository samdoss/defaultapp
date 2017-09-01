using System;
using System.Collections;
using System.Xml;
using System.Windows.Forms.VisualStyles;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using ERP.DataLayer;
using ERP.CommonLayer;

namespace ERPWinApp
{
    public partial class frmCountryStateCity : Form
    {

        #region Constructor(s)

        public frmCountryStateCity()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variable(s)

        Variables _variables = new Variables();

        ApplicationConnection _appConnection = new ApplicationConnection();
        ScreenMode userMode;
        List<Country> _listCountry = new List<Country>();
        List<State> _listState = new List<State>();
        List<City> _listCity = new List<City>();
        internal string helpFile = "\\Help\\HelpFile.chm";
        private int _gridRowIndex = 0;
        private int _row = 0;
        private int _col = 0;

        #endregion

        #region Private Event(s)

        #region Common Private Event(s)

        private void frmCountryStateCity_Load(object sender, EventArgs e)
        {
            try
            {
                string sSelected = "--Select--";
                // Fill Country
                ddlCityCountry.DataSource = State.GetCountry(_appConnection).Tables[0];
                ddlCityCountry.DisplayMember = "Country";
                ddlCityCountry.ValueMember = "CountryID";
                ddlCityCountry.SelectedValue = 0;

                ddlStateCountry.DataSource = State.GetCountry(_appConnection).Tables[0];
                ddlStateCountry.DisplayMember = "Country";
                ddlStateCountry.ValueMember = "CountryID";
                ddlStateCountry.SelectedValue = 0;

                //ddlCityState.DataSource = null;
                //ddlCityState.DisplayMember = "City";
                //ddlCityState.ValueMember = "CityID";
                //ddlCityState.SelectedValue = 0;

                ddlCityState.Items.Add(sSelected);
                ddlCityState.SelectedIndex = 0;
                _variables.FnSetDisabledButton(btnCitySave);
                _variables.FnSetDisabledButton(btnCountrySave);
                _variables.FnSetDisabledButton(btnStateSave);
                _variables.FnSetDisabledButton(btnCityDelete);
                _variables.FnSetDisabledButton(btnCountryDelete);
                _variables.FnSetDisabledButton(btnStateDelete);
                FillGrid();

                PCSHelp.HelpNamespace = (Application.StartupPath + helpFile);
                PCSHelp.SetHelpKeyword(this, "frmCountryStateCity.htm");
                PCSHelp.SetHelpNavigator(this, HelpNavigator.Topic);
                LoadDefaultColorandFonts();
                ostrpDeleteCountry.Visible = false;
                ostrpDeleteState.Visible = false;
                ostrpDeleteCity.Visible = false;
            }
            catch { }
        }

        private void frmCountryStateCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }
        
        #endregion

        #region Country Private Event(s)

        private void dgvCountry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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

        private void ostrpDeleteCountry_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gridRowIndex < dgvCountry.Rows.Count - 1)
                    if (dgvCountry[8, _row].Value == null)
                        dgvCountry.Rows.RemoveAt(_row);
            }
            catch { }
        }

        private void dgvCountry_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dgvCountry.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dgvCountry.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void btnCountryDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                string status;
                _listCountry.Clear();
                foreach (DataGridViewRow _Row in dgvCountry.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[4].FormattedValue) == true)
                    {
                        status = _Row.Cells[4].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            Country _Country = new Country();
                            _Country.CountryID = Convert.ToInt32(_Row.Cells[6].Value.ToString());
                            _listCountry.Add(_Country);
                        }

                    }
                }
                Country _CountryDescription = new Country();
                _CountryDescription.CountryList = _listCountry;
                if (_listCountry.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected Country(s) will be Deleted. Do You Want to Delete?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _CountryDescription.Commit(ScreenMode.Delete);
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
                MessageBox.Show("Please Select The Country.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void UpdateCancelClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgvCountry.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgvCountry.Rows[e.RowIndex].Cells["CancelRecord"];

                if ((dgvCountry.Columns[e.ColumnIndex].Name == "UpdateRecord") || (dgvCountry.Columns[e.ColumnIndex].Name == "CancelRecord"))
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dgvCountry.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidation(e.ColumnIndex,e.RowIndex)) { return; }
                            Country _Country = new Country();
                            _Country.CountryID = Convert.ToInt32(dgvCountry.Rows[e.RowIndex].Cells[6].Value.ToString());
                            _Country.CountryName = dgvCountry.Rows[e.RowIndex].Cells[1].Value.ToString();

                            TransactionResult _Result = null;
                            _Result = _Country.Commit(ScreenMode.Edit);
                            dgvCountry.Columns.Remove("CancelRecord");
                            dgvCountry.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                        if (dgvCountry.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            dgvCountry.Columns.Remove("CancelRecord");
                            dgvCountry.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrder();
                            FillGrid();
                        }
                    }

                }
            }
            catch { }
        }

        private void btnCountryClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCountrySave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidation()) { return; }
                _listCountry.Clear();
                foreach (DataGridViewRow _Row in dgvCountry.Rows)
                {
                    if ((_Row.Cells[6].Value == null))
                    {
                        if ((_Row.Cells[1].Value != null))
                        {
                            Country _Country = new Country();
                            _Country.CountryName = _Row.Cells[1].Value.ToString();
                            _listCountry.Add(_Country);
                        }
                    }
                }
                Country _CountryDescription = new Country();
                _CountryDescription.CountryList = _listCountry;
                TransactionResult _Result = null;
                _Result = _CountryDescription.Commit(ScreenMode.Add);
                MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                FillGrid();
            }
            catch { }
        }

        private void dgvCountry_DataError(object sender, DataGridViewDataErrorEventArgs anError)
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

        private void dgvCountry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;

                if (e.ColumnIndex == 2)
                {
                    if (dgvCountry.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        gCountryEdit.Visible = false;
                        gCountryStatus.Visible = false;
                        gCountryDelete.Visible= false;
                        UpdateCountry(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dgvCountry.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dgvCountry[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgvCountry[4, e.RowIndex].ReadOnly = true;
                        dgvCountry[4, e.RowIndex].Value = false;
                        dgvCountry.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    dgvCountry_CellEndEdit(sender, e);
                }
            }
            catch { }
        }

        private void btnCountryCancel_Click(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch { }
        }

        private void dgvCountry_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dgvCountry[0, e.RowIndex].Value = _RowNumber;

                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
        }

        private void dgvCountry_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCountry[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dgvCountry[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dgvCountry.RowCount - 1);
                }

                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex == dgvCountry.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvUnitDesc Should Not be Empty");
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dgvCountry.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dgvCountry[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgvCountry[4, e.RowIndex].ReadOnly = true;
                        dgvCountry[4, e.RowIndex].Value = false;
                        dgvCountry.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }
            }
            catch { }
        }

        private void dgvCountry_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ostrpDeleteCountry.Visible = true;
            _variables.FnSetEnabledButton(btnCountrySave);
            
        }
 
        private void dgvCountry_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnCountrySave);
            
        }

        #endregion

        #region State Private Event(s)

        private void btnStateDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                string status;
                _listState.Clear();
                foreach (DataGridViewRow _Row in dgvState.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[4].FormattedValue) == true)
                    {
                        status = _Row.Cells[4].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            State _State = new State();
                            _State.StateID = Convert.ToInt32(_Row.Cells[6].Value.ToString());
                            _listState.Add(_State);
                        }

                    }
                }
                State _StateDescription = new State();
                _StateDescription.StateList = _listState;
                if (_listState.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected State(s) will be Deleted. Do You Want to Delete?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _StateDescription.Commit(ScreenMode.Delete);
                        MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        FillGridState();
                        if (_Result.Status == TransactionStatus.Success)
                        {
                            FillGridState();
                        }
                    }
                    else
                    {
                        FillGridState();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Select The State.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void ostrpDeleteState_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gridRowIndex < dgvState.Rows.Count - 1)
                    if (dgvState[6, _row].Value == null)
                        dgvState.Rows.RemoveAt(_row);
            }
            catch { }
        }

        private void dgvState_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dgvState.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dgvState.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }
        private void dgvState_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    //dont remove these two lines
                    //purposefully i called two times 
                    GridValueChangedState(e.RowIndex, e.ColumnIndex);
                    GridValueChangedState(e.RowIndex, e.ColumnIndex);
                    //GridValueChanged(e.RowIndex, e.ColumnIndex);
                }
            }
            catch { }
        }

        private void dgvState_DataError(object sender, DataGridViewDataErrorEventArgs anError)
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

        private void btnStateSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidationState()) { return; }
                _listState.Clear();
                foreach (DataGridViewRow _Row in dgvState.Rows)
                {
                    if ((_Row.Cells[6].Value == null))
                    {
                        if ((_Row.Cells[1].Value != null))
                        {
                            State _State = new State();
                            _State.CountryID = Convert.ToInt32(ddlStateCountry.SelectedValue);
                            _State.StateName = _Row.Cells[1].Value.ToString();
                            _listState.Add(_State);
                        }
                    }
                }
                State _StateDescription = new State();
                _StateDescription.StateList = _listState;
                TransactionResult _Result = null;
                _Result = _StateDescription.Commit(ScreenMode.Add);
                MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                FillGridState();
            }
            catch { }
        }

        private void UpdateCancelStateClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgvState.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgvState.Rows[e.RowIndex].Cells["CancelRecord"];

                if ((dgvState.Columns[e.ColumnIndex].Name == "UpdateRecord") || (dgvState.Columns[e.ColumnIndex].Name == "CancelRecord"))
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dgvState.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidationState(e.ColumnIndex, e.RowIndex)) { return; }
                            State _State = new State();
                            _State.StateID = Convert.ToInt32(dgvState.Rows[e.RowIndex].Cells[6].Value.ToString());
                            _State.StateName = dgvState.Rows[e.RowIndex].Cells[1].Value.ToString();

                            TransactionResult _Result = null;
                            _Result = _State.Commit(ScreenMode.Edit);
                            dgvState.Columns.Remove("CancelRecord");
                            dgvState.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrderState();
                            FillGridState();
                        }
                        if (dgvState.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            dgvState.Columns.Remove("CancelRecord");
                            dgvState.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrderState();
                            FillGridState();
                        }
                    }

                }
            }
            catch { }
        }

        private void btnStateCancel_Click(object sender, EventArgs e)
        {
            ddlStateCountry.SelectedIndex = 0;
            dgvState.Rows.Clear();
        }

        private void btnStateClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlStateCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStateCountry.SelectedIndex != 0)
            {
                FillGridState();
            }
            else if (ddlStateCountry.SelectedIndex == 0)
            {
                dgvState.Rows.Clear();
                dgvState.AllowUserToAddRows = false;
            }
        }

        private void dgvState_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 2)
                {
                    if (dgvState.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        gStateEdit.Visible = false;
                        gStateStatus.Visible = false;
                        gStateDelete.Visible = false;
                        UpdateState(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dgvState.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dgvState[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgvState[4, e.RowIndex].ReadOnly = true;
                        dgvState[4, e.RowIndex].Value = false;
                        dgvState.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    dgvState_CellEndEdit(sender, e);
                }
            }
            catch { }
        }

        private void dgvState_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvState[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dgvState[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dgvState.RowCount - 1);
                }

                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex == dgvState.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvUnitDesc Should Not be Empty");
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dgvState.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dgvState[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgvState[4, e.RowIndex].ReadOnly = true;
                        dgvState[4, e.RowIndex].Value = false;
                        dgvState.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }
            }
            catch { }
        }

        private void dgvState_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dgvState[0, e.RowIndex].Value = _RowNumber;
                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
        }

        private void dgvState_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ostrpDeleteState.Visible = true;
            _variables.FnSetEnabledButton(btnStateSave);
            
        }

        private void dgvState_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnStateSave);
            
        }

        #endregion        

        #region City Private Event(s)

        private void btnCityClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCitySave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidationCity()) { return; }
                _listCity.Clear();
                foreach (DataGridViewRow _Row in dgvCity.Rows)
                {
                    if ((_Row.Cells[6].Value == null))
                    {
                        if ((_Row.Cells[1].Value != null))
                        {
                            City _City = new City();
                            _City.StateID = Convert.ToInt32(ddlCityState.SelectedValue);
                            _City.CityName = _Row.Cells[1].Value.ToString();
                            _listCity.Add(_City);
                        }
                    }
                }
                City _CityDescription = new City();
                _CityDescription.CityList = _listCity;
                TransactionResult _Result = null;
                _Result = _CityDescription.Commit(ScreenMode.Add);
                MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                FillGridCity();
            }
            catch { }
        }

        private void UpdateCancelCityClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgvCity.Rows[e.RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgvCity.Rows[e.RowIndex].Cells["CancelRecord"];

                if ((dgvCity.Columns[e.ColumnIndex].Name == "UpdateRecord") || (dgvCity.Columns[e.ColumnIndex].Name == "CancelRecord"))
                {
                    if (_btnUpdate.Enabled || _btnCancel.Enabled)
                    {
                        if (dgvCity.Columns[e.ColumnIndex].Name == "UpdateRecord")
                        {
                            if (!UpdateFormValidationCity(e.ColumnIndex,e.RowIndex)) { return; }
                            City _City = new City();
                            _City.CityID = Convert.ToInt32(dgvCity.Rows[e.RowIndex].Cells[6].Value.ToString());
                            _City.CityName = dgvCity.Rows[e.RowIndex].Cells[1].Value.ToString();

                            TransactionResult _Result = null;
                            _Result = _City.Commit(ScreenMode.Edit);
                            dgvCity.Columns.Remove("CancelRecord");
                            dgvCity.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrderCity();
                            FillGridCity();
                        }
                        if (dgvCity.Columns[e.ColumnIndex].Name == "CancelRecord")
                        {
                            dgvCity.Columns.Remove("CancelRecord");
                            dgvCity.Columns.Remove("UpdateRecord");
                            SettingGridColumnOrderCity();
                            FillGridCity();
                        }
                    }
                }
            }
            catch { }
        }

        private void btnCityCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ddlCityCountry.SelectedIndex = 0;
                ddlCityState.SelectedIndex = 0;
                FillGridCity();
            }
            catch { }
        }

        private void ddlCityState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCityState.SelectedIndex != 0)
                {
                    FillGridCity();
                }
                else if (ddlCityState.SelectedIndex == 0)
                {
                    dgvCity.Rows.Clear();
                    dgvCity.AllowUserToAddRows = false;
                }
            }
            catch { }
        }

        private void dgvCity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _row = e.RowIndex;
                _col = e.ColumnIndex;
                if (e.ColumnIndex == 2)
                {
                    if (dgvCity.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        gCityEdit.Visible = false;
                        gcityStatus.Visible = false;
                        gCityDelete.Visible = false;
                        UpdateCity(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dgvCity.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dgvCity[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgvCity[4, e.RowIndex].ReadOnly = true;
                        dgvCity[4, e.RowIndex].Value = false;
                        dgvCity.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    dgvCity_CellEndEdit(sender, e);
                }
            }
            catch { }
        }

        private void dgvCity_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dgvCity[0, e.RowIndex].Value = _RowNumber;
                _row = e.RowIndex;
                _col = e.ColumnIndex;
            }
            catch { }
        }

        private void dgvCity_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCity[e.ColumnIndex, e.RowIndex].ValueType.Equals(typeof(bool)))
                {
                    dgvCity[e.ColumnIndex, e.RowIndex].ReadOnly =
                    (e.RowIndex == dgvCity.RowCount - 1);
                }

                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex == dgvCity.RowCount - 1)
                    {

                        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                        messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
                        messageBoxCS.AppendLine();
                        //MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event");
                        //MessageBox.Show("dvUnitDesc Should Not be Empty");
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (dgvCity.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        dgvCity[4, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dgvCity[4, e.RowIndex].ReadOnly = true;
                        dgvCity[4, e.RowIndex].Value = false;
                        dgvCity.Rows[e.RowIndex].Cells[4].Selected = false;
                    }
                }
            }
            catch { }
        }

        private void dgvCity_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ostrpDeleteCity.Visible = true;
            _variables.FnSetEnabledButton(btnCitySave);
            
        }

        private void dgvCity_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnCitySave);
            
        }

        private void ddlCityCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCityCountry.SelectedIndex > 0)
                {
                    // Fill State
                    int countryID = int.Parse(ddlCityCountry.SelectedValue.ToString());
                    ddlCityState.DataSource = ERP.DataLayer.CommonDL.GetState(_appConnection, countryID).Tables[0];
                    ddlCityState.DisplayMember = "State";
                    ddlCityState.ValueMember = "StateID";
                }
                if (ddlCityCountry.SelectedIndex != 0)
                {
                    ddlCityState.DataSource = null;
                    ddlCityState.Items.Clear();
                    int countryID = int.Parse(ddlCityCountry.SelectedValue.ToString());
                    ddlCityState.DataSource = CommonDL.GetState(_appConnection, countryID).Tables[0];
                    ddlCityState.DisplayMember = "State";
                    ddlCityState.ValueMember = "StateID";
                }
            }
            catch { }
        }
        private void btnCityDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                string status;
                _listCity.Clear();
                foreach (DataGridViewRow _Row in dgvCity.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells[4].FormattedValue) == true)
                    {
                        status = _Row.Cells[4].Value.ToString();
                        if (status == "1" || status == "True")
                        {
                            City _City = new City();
                            _City.CityID = Convert.ToInt32(_Row.Cells[6].Value.ToString());
                            _listCity.Add(_City);
                        }

                    }
                }
                City _CityDescription = new City();
                _CityDescription.CityList = _listCity;
                if (_listCity.Count != 0)
                {
                    TransactionResult _Result = null;
                    isQuit = MessageBox.Show("Selected City(s) will be Deleted. Do You Want to Delete?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (isQuit == DialogResult.Yes)
                    {
                        _Result = _CityDescription.Commit(ScreenMode.Delete);
                        MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        FillGridCity();
                        if (_Result.Status == TransactionStatus.Success)
                        {
                            FillGridCity();
                        }
                    }
                    else
                    {
                        FillGridCity();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Select The City.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvCity_DataError(object sender, DataGridViewDataErrorEventArgs anError)
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

        private void dgvCity_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    //dont remove these two lines
                    //purposefully i called two times 
                    GridValueChangedCity(e.RowIndex, e.ColumnIndex);
                    GridValueChangedCity(e.RowIndex, e.ColumnIndex);
                }
            }
            catch { }
        }

        private void dgvCity_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dgvCity.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dgvCity.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void ostrpDeleteCity_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gridRowIndex < dgvCity.Rows.Count - 1)
                    if (dgvCity[6, _row].Value == null)
                        dgvCity.Rows.RemoveAt(_row);
            }
            catch { }
        }

        #endregion

        #endregion

        #region private Method(s)

        #region Common Method

        private void LoadDefaultColorandFonts()
        {
             _variables.FnTitleTheme(lblCaption);
             
            _variables.FnButtonTheme(btnCountrySave);
            _variables.FnButtonTheme(btnStateSave);
            _variables.FnButtonTheme(btnCitySave);
            
            _variables.FnButtonTheme(btnCountryClose);
            _variables.FnButtonTheme(btnStateClose);
            _variables.FnButtonTheme(btnCityClose);

            _variables.FnButtonTheme(btnCountryCancel);
            _variables.FnButtonTheme(btnStateCancel);
            _variables.FnButtonTheme(btnCityCancel);

            _variables.FnButtonTheme(btnCountryDelete);
            _variables.FnButtonTheme(btnStateDelete);
            _variables.FnButtonTheme(btnCityDelete);

            _variables.FnGridTheme(dgvCountry);
            _variables.FnGridTheme(dgvState);
            _variables.FnGridTheme(dgvCity);

            _variables.FnSetToolTip(btnCountryClose, "Alt+C Close");
            _variables.FnSetToolTip(btnStateClose, "Alt+C Close");
            _variables.FnSetToolTip(btnCityClose, "Alt+C Close");

            _variables.FnSetToolTip(btnCountryCancel, "Alt+R Reset");
            _variables.FnSetToolTip(btnStateCancel, "Alt+R Reset");
            _variables.FnSetToolTip(btnCityCancel, "Alt+R Reset");

            _variables.FnSetToolTip(btnCountryDelete, "Alt+D Delete");
            _variables.FnSetToolTip(btnStateDelete, "Alt+D Delete");
            _variables.FnSetToolTip(btnCityDelete, "Alt+D Delete");

            _variables.FnSetToolTip(btnCountrySave, "Alt+S Save Country");
            _variables.FnSetToolTip(btnStateSave, "Alt+S Save State");
            _variables.FnSetToolTip(btnCitySave, "Alt+S Save City");

        }

        #endregion

        #region Country Private Method(s)

        private void FillGrid()
        {
            try
            {
                int _RowIndex = 0;
                _listCountry = Country.GetCountryList(_appConnection);

                dgvCountry.Rows.Clear();
                foreach (Country _CountryDescription in _listCountry)
                {
                    dgvCountry.Rows.Add();
                    dgvCountry.Rows[_RowIndex].ReadOnly = true;
                    dgvCountry[6, _RowIndex].Value = _CountryDescription.CountryID.ToString();
                    dgvCountry[0, _RowIndex].Value = _RowIndex + 1;
                    dgvCountry[1, _RowIndex].Value = _CountryDescription.CountryName;
                    DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dgvCountry.Rows[_RowIndex].Cells["gCountryEdit"];
                    DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dgvCountry.Rows[_RowIndex].Cells["gCountryStatus"];
                    buttonEdit.Enabled = true;
                    buttonStatus.Enabled = true;
                    gCountryEdit.UseColumnTextForButtonValue = false;
                    dgvCountry[2, _RowIndex].Value = "Edit";
                    gCountryStatus.UseColumnTextForButtonValue = false;
                    dgvCountry[3, _RowIndex].Value = "Status";
                    _RowIndex++;
                }
                _variables.FnSetDisabledButton(btnCountrySave);
                _variables.FnSetDisabledButton(btnCountryDelete);
                
                ostrpDeleteCountry.Visible = false;
                
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("CountryStateCity", "frmCountryStateCity", "FillGrid", ex.Message);
            }
        }

        private bool FormValidation()
        {
            bool valid = true;
            for (int t = 0; t < dgvCountry.Rows.Count - 1; t++)
            {
                if (dgvCountry[1, t].Value == null)
                {
                    MessageBox.Show("Please Enter The Country.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dgvCountry[1, t].Selected = true;
                    break;
                }
                else if (FindDuplicateCountries())
                {
                    MessageBox.Show("Please Remove The Duplicate Country.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dgvCountry.Focus();
                    break;
                }

            }
            
            return valid;
        }

        private bool UpdateFormValidation(int columnIndex, int rowIndex)
        {
            bool valid = true;
            
            if (dgvCountry[1, rowIndex].Value == null)
            {
                dgvCountry[1, rowIndex].ErrorText = "Please Enter The Country.";
                dgvCountry[1, rowIndex].Selected = true;
                valid = false;
            }
            else if (FindDuplicateCountries())
            {
                dgvCountry[1, rowIndex].ErrorText = "Please Remove The Duplicate Country.";
                dgvCountry[1, rowIndex].Selected = true;
                valid = false;
                dgvCountry.Focus();
            }
            return valid;
        }

        private bool FindDuplicateCountries()
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dgvCountry.Rows.Count;
            rCountWithEntries = 0;

            for (int i = 0; i < rCount; i++)
            {

                if (dgvCountry[1, i].Value != null && dgvCountry[1, i].Value.ToString().Trim() != "")
                {
                    rCountWithEntries = rCountWithEntries + 1;
                }
                else
                {
                    break;
                }
            }
            string[] arPatientCountry = new string[rCountWithEntries];
            // If Country have been entered, then it is saved
            if (rCountWithEntries > 0)
            {
                int j = 0;
                for (int i = 0; i < rCountWithEntries; i++)
                {
                    if (dgvCountry[1, i].Value != null && dgvCountry[1, i].Value.ToString().Trim() != "")
                    {
                        arPatientCountry[j] = dgvCountry[1, i].Value.ToString();
                        j++;
                    }
                }

                Array.Sort(arPatientCountry);
                j = 0;
                string tempCountry = arPatientCountry[0];
                for (int i = 1; i < rCountWithEntries; i++)
                {
                    if (tempCountry != arPatientCountry[i])
                    {
                        tempCountry = arPatientCountry[i];
                    }
                    else
                    {
                        IsDuplicatesFound = true;
                    }
                }
            }
            return IsDuplicatesFound;
        }

        private void UpdateCountry(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dgvCountry.Columns.Add(column2);
                dgvCountry.Columns.Add(column3);
                dgvCountry.AllowUserToAddRows = false;
                dgvCountry.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCountry.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dgvCountry.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgvCountry.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgvCountry.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dgvCountry.Rows[RowIndex].ReadOnly = false;
                dgvCountry.CellClick += new DataGridViewCellEventHandler(UpdateCancelClick);
            }
            catch { }
        }

        private void SettingGridColumnOrder()
        {
            gCountrySNo.DisplayIndex = 0;
            gCountry.DisplayIndex = 1;
            gCountryEdit.DisplayIndex = 2;
            gCountryStatus.DisplayIndex = 3;
            gCountryDelete.DisplayIndex = 4;
            gCountryEditingChk.DisplayIndex = 5;
            CountryID.DisplayIndex = 6;

            gCountrySNo.Visible = true;
            gCountrySNo.ReadOnly = true;
            gCountry.Visible = true;
            gCountryEdit.Visible = true;
            gCountryStatus.Visible = false;
            gCountryDelete.Visible = true;
            gCountryEditingChk.Visible = false;
            CountryID.Visible = false;
        }

        private void GridValueChanged(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 4)
            {
                for (int i = 0; i < dgvCountry.RowCount - 1; i++)
                {
                    if (dgvCountry.Rows[i].Cells[4].Value != null)
                        if (Convert.ToBoolean(dgvCountry.Rows[i].Cells[4].Value) == true)
                        {
                            delSelected = true;
                        }
                }
                if (delSelected == true)
                {
                    _variables.FnSetEnabledButton(btnCountryDelete);
                    
                }
                else
                {
                    _variables.FnSetDisabledButton(btnCountryDelete);
                    
                }
            }
            this.Validate();
        }


        #endregion

        #region State Private Method(s)

        private void FillGridState()
        {
            try
            {
                if (ddlStateCountry.SelectedIndex != 0)
                {
                    int _RowIndex = 0;
                    _listState = State.GetStateList(_appConnection, Convert.ToInt32(ddlStateCountry.SelectedValue));

                    dgvState.Rows.Clear();
                    foreach (State _StateDescription in _listState)
                    {
                        dgvState.Rows.Add();
                        dgvState.Rows[_RowIndex].ReadOnly = true;
                        dgvState[6, _RowIndex].Value = _StateDescription.StateID.ToString();
                        dgvState[0, _RowIndex].Value = _RowIndex + 1;
                        dgvState[1, _RowIndex].Value = _StateDescription.StateName;
                        DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dgvState.Rows[_RowIndex].Cells["gStateEdit"];
                        DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dgvState.Rows[_RowIndex].Cells["gStateStatus"];
                        buttonEdit.Enabled = true;
                        buttonStatus.Enabled = true;
                        gStateEdit.UseColumnTextForButtonValue = false;
                        dgvState[2, _RowIndex].Value = "Edit";
                        gStateStatus.UseColumnTextForButtonValue = false;
                        dgvState[3, _RowIndex].Value = "Status";
                        _RowIndex++;
                    }
                    dgvState.AllowUserToAddRows = true;
                    _variables.FnSetDisabledButton(btnStateSave);
                    _variables.FnSetDisabledButton(btnStateDelete);
                    
                    ostrpDeleteState.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("CountryStateCity", "frmCountryStateCity", "FillGridState", ex.Message);
            }
        }

        private bool FormValidationState()
        {
            bool valid = true;
            for (int t = 0; t < dgvState.Rows.Count - 1; t++)
            {
                if (dgvState[1, t].Value == null)
                {
                    MessageBox.Show("Please Enter The State.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgvState[1, t].Selected = true;
                    valid = false;
                    break;
                }
                else if (FindDuplicateStates())
                {
                    MessageBox.Show("Please Remove The Duplicate State.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgvState[1, t].Selected = true;
                    valid = false;
                    break;
                }

            }
            
            return valid;
        }

        private bool UpdateFormValidationState(int columnIndex, int rowIndex)
        {
            bool valid = true;
            if (dgvState[1, rowIndex].Value == null)
            {
                dgvState[1, rowIndex].ErrorText = "Please Enter The State.";
                dgvState[1, rowIndex].Selected = true;
                valid = false;
            }
            else if (FindDuplicateStates())
            {
                dgvState[1, rowIndex].ErrorText = "Please Remove The Duplicate State.";
                dgvState[1, rowIndex].Selected = true;
                valid = false;
            }
            return valid;
        }

        private bool FindDuplicateStates()
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;
            rCount = dgvState.Rows.Count;
            rCountWithEntries = 0;

            for (int i = 0; i < rCount; i++)
            {
                if (dgvState[1, i].Value != null && dgvState[1, i].Value.ToString().Trim() != "")
                    rCountWithEntries = rCountWithEntries + 1;
                else
                    break;
            }
            string[] arPatientState = new string[rCountWithEntries];
            // If State have been entered, then it is saved
            if (rCountWithEntries > 0)
            {
                int j = 0;
                for (int i = 0; i < rCountWithEntries; i++)
                {
                    if (dgvState[1, i].Value != null && dgvState[1, i].Value.ToString().Trim() != "")
                    {
                        arPatientState[j] = dgvState[1, i].Value.ToString();
                        j++;
                    }
                }

                Array.Sort(arPatientState);
                j = 0;
                string tempState = arPatientState[0];
                for (int i = 1; i < rCountWithEntries; i++)
                {
                    if (tempState != arPatientState[i])
                    {
                        tempState = arPatientState[i];
                    }
                    else
                    {
                        IsDuplicatesFound = true;
                    }
                }
            }
            return IsDuplicatesFound;
        }

        private void UpdateState(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dgvState.Columns.Add(column2);
                dgvState.Columns.Add(column3);
                dgvState.AllowUserToAddRows = false;
                dgvState.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvState.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dgvState.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgvState.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgvState.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dgvState.Rows[RowIndex].ReadOnly = false;
                dgvState.CellClick += new DataGridViewCellEventHandler(UpdateCancelStateClick);
            }
            catch { }
        }

        private void SettingGridColumnOrderState()
        {
            gStateSNO.DisplayIndex = 0;
            gState.DisplayIndex = 1;
            gStateEdit.DisplayIndex = 2;
            gStateStatus.DisplayIndex = 3;
            gStateDelete.DisplayIndex = 4;
            gStateCheck.DisplayIndex = 5;
            gStateID.DisplayIndex = 6;

            gStateSNO.Visible = true;
            gStateSNO.ReadOnly = true;
            gState.Visible = true;
            gStateEdit.Visible = true;
            gStateStatus.Visible = false;
            gStateDelete.Visible = true;
            gStateCheck.Visible = false;
            gStateID.Visible = false;
        }

        private void GridValueChangedState(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 4)
            {
                for (int i = 0; i < dgvState.RowCount - 1; i++)
                {
                    if (dgvState.Rows[i].Cells[4].Value != null)
                        if (Convert.ToBoolean(dgvState.Rows[i].Cells[4].Value) == true)
                        {
                            delSelected = true;
                        }
                }
                if (delSelected == true)
                {
                    _variables.FnSetEnabledButton(btnStateDelete);
                    
                }
                else
                {
                    _variables.FnSetDisabledButton(btnStateDelete);
                    
                }
            }
            this.Validate();
        }

        #endregion

        #region City Private Method(s)

        private void FillGridCity()
        {
            try
            {
                if (ddlCityState.SelectedIndex != 0)
                {
                    int _RowIndex = 0;
                    _listCity = City.GetCityList(_appConnection, Convert.ToInt32(ddlCityState.SelectedValue));

                    dgvCity.Rows.Clear();
                    foreach (City _CityDescription in _listCity)
                    {
                        dgvCity.Rows.Add();
                        dgvCity.Rows[_RowIndex].ReadOnly = true;
                        dgvCity[6, _RowIndex].Value = _CityDescription.CityID.ToString();
                        dgvCity[0, _RowIndex].Value = _RowIndex + 1;
                        dgvCity[1, _RowIndex].Value = _CityDescription.CityName;
                        DataGridViewDisableButtonCell buttonEdit = (DataGridViewDisableButtonCell)dgvCity.Rows[_RowIndex].Cells["gCityEdit"];
                        DataGridViewDisableButtonCell buttonStatus = (DataGridViewDisableButtonCell)dgvCity.Rows[_RowIndex].Cells["gcityStatus"];
                        buttonEdit.Enabled = true;
                        buttonStatus.Enabled = true;
                        gCityEdit.UseColumnTextForButtonValue = false;
                        dgvCity[2, _RowIndex].Value = "Edit";
                        gcityStatus.UseColumnTextForButtonValue = false;
                        dgvCity[3, _RowIndex].Value = "Status";
                        _RowIndex++;
                    }
                    dgvCity.AllowUserToAddRows = true;
                    _variables.FnSetDisabledButton(btnCitySave);
                    _variables.FnSetDisabledButton(btnCityDelete);
                    
                    ostrpDeleteCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("CountryStateCity", "frmCountryStateCity", "FillGridCity", ex.Message);
            }
        }

        private bool FormValidationCity()
        {
            bool valid = true;
            for (int t = 0; t < dgvCity.Rows.Count - 1; t++)
            {
                if (dgvCity[1, t].Value == null)
                {
                    MessageBox.Show("Please Enter The City.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dgvCity[1, t].Selected = true;
                    break;
                }
                else if (FindDuplicateCity())
                {
                    MessageBox.Show("Please Remove The Duplicate City.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    dgvCity[1, t].Selected = true;
                    break;
                }
             }
            return valid;
            }

        private bool UpdateFormValidationCity(int columnIndex, int rowIndex)
        {
            bool valid = true;

            if (dgvCity[1, rowIndex].Value == null)
            {
                dgvCity[1, rowIndex].ErrorText = "Please Enter The City.";
                dgvCity[1, rowIndex].Selected = true;
                valid = false;
            }
            else if (FindDuplicateCity())
            {
                dgvCity[1, rowIndex].ErrorText = "Please Remove The Duplicate City.";
                dgvCity[1, rowIndex].Selected = true;
                valid = false;
                dgvCity.Focus();
            }

            return valid;
        }

        private bool FindDuplicateCity()
        {
            int rCount, rCountWithEntries;
            bool IsDuplicatesFound = false;

            rCount = dgvCity.Rows.Count;
            rCountWithEntries = 0;

            for (int i = 0; i < rCount; i++)
            {

                if (dgvCity[1, i].Value != null && dgvCity[1, i].Value.ToString().Trim() != "")
                {
                    rCountWithEntries = rCountWithEntries + 1;
                }
                else
                {
                    break;
                }
            }
            string[] arPatientCity = new string[rCountWithEntries];
            // If City have been entered, then it is saved
            if (rCountWithEntries > 0)
            {
                int j = 0;
                for (int i = 0; i < rCountWithEntries; i++)
                {
                    if (dgvCity[1, i].Value != null && dgvCity[1, i].Value.ToString().Trim() != "")
                    {
                        arPatientCity[j] = dgvCity[1, i].Value.ToString();
                        j++;
                    }
                }

                Array.Sort(arPatientCity);
                j = 0;
                string tempCity = arPatientCity[0];
                for (int i = 1; i < rCountWithEntries; i++)
                {
                    if (tempCity != arPatientCity[i])
                    {
                        tempCity = arPatientCity[i];
                    }
                    else
                    {
                        IsDuplicatesFound = true;
                    }
                }
            }
            return IsDuplicatesFound;
        }

        private void UpdateCity(int RowIndex)
        {
            try
            {
                DataGridViewDisableButtonColumn column2 = new DataGridViewDisableButtonColumn();
                DataGridViewDisableButtonColumn column3 = new DataGridViewDisableButtonColumn();

                column2.Name = "UpdateRecord";
                column3.Name = "CancelRecord";

                dgvCity.Columns.Add(column2);
                dgvCity.Columns.Add(column3);
                dgvCity.AllowUserToAddRows = false;
                dgvCity.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCity.Rows[RowIndex].Cells["UpdateRecord"].Value = "Update";
                dgvCity.Rows[RowIndex].Cells["CancelRecord"].Value = "Cancel";
                DataGridViewDisableButtonCell _btnUpdate = (DataGridViewDisableButtonCell)dgvCity.Rows[RowIndex].Cells["UpdateRecord"];
                DataGridViewDisableButtonCell _btnCancel = (DataGridViewDisableButtonCell)dgvCity.Rows[RowIndex].Cells["CancelRecord"];
                _btnUpdate.Enabled = true;
                _btnCancel.Enabled = true;
                dgvCity.Rows[RowIndex].ReadOnly = false;
                dgvCity.CellClick += new DataGridViewCellEventHandler(UpdateCancelCityClick);
            }
            catch { }
        }

        private void SettingGridColumnOrderCity()
        {
            gCitySno.DisplayIndex = 0;
            gCity.DisplayIndex = 1;
            gCityEdit.DisplayIndex = 2;
            gcityStatus.DisplayIndex = 3;
            gCityDelete.DisplayIndex = 4;
            gCityEditchk.DisplayIndex = 5;
            gCityID.DisplayIndex = 6;

            gCitySno.Visible = true;
            gCitySno.ReadOnly = true;
            gCity.Visible = true;
            gCityEdit.Visible = true;
            gcityStatus.Visible = false;
            gCityDelete.Visible = true;
            gCityEditchk.Visible = false;
            gCityID.Visible = false;
        }

        private void GridValueChangedCity(int RowIndex, int ColumnIndex)
        {
            bool delSelected = false;
            if (ColumnIndex == 4)
            {
                for (int i = 0; i < dgvCity.RowCount - 1; i++)
                {
                    if (dgvCity.Rows[i].Cells[4].Value != null)
                        if (Convert.ToBoolean(dgvCity.Rows[i].Cells[4].Value) == true)
                        {
                            delSelected = true;
                        }
                }
                if (delSelected == true)
                {
                    _variables.FnSetEnabledButton(btnCityDelete);
                    
                }
                else
                {
                    _variables.FnSetDisabledButton(btnCityDelete);
                    
                }
            }
            this.Validate();
        }


        #endregion

        
        #endregion

    }
}