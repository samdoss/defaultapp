using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class frmBill : Form
    {
        #region Constructor(s)

        public frmBill()
        {
            InitializeComponent();

        }

        #endregion

        #region Private Variables

        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
        
        private string _hospitalName;
        private string _hospitalAddressDetails1;
        private string _hospitalAddressDetails2;
        private int _patientID;
        private int _gridRowIndex = 0;
        private int _CardTypeLength = 0;
        internal string reportname = "\\Reports\\BillingReport.rpt";
        internal string helpFile = "\\Help\\HelpFile.chm";
        bool _isPreviousBillClicked = false;
        #endregion

        #region Private Event(s)

        private void frmBill_Load(object sender, EventArgs e)
        {
            try
            {
                string sSelected = "--Select--";

                DateTime CurrentDate = Convert.ToDateTime(Utility.GetServerDate(_appConnection).ToString("MM/dd/yyyy"));
                dtpDateDD.MaxDate = CurrentDate;
                dtpDOB.MaxDate = CurrentDate;
                dtpDOB.Value = Convert.ToDateTime(Utility.GetServerDate(_appConnection).ToString("MM/dd/yyyy"));
                dtpDOB.MaxDate = CurrentDate.AddDays(45);
                dtpDateDD.Value = CurrentDate;
                dtpDateDD.MaxDate = CurrentDate.AddDays(45);
                ostrpDelete.Visible = false;
                ddlBillMode.DataSource = null;
                ddlBillMode.Items.Clear();
                ddlBillMode.Items.Add(sSelected);
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmBill.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                DisplayOrderinginGrid();
                ddlBillMode.SelectedIndex = 0;
                ddlBillMode.Enabled = false;
                tabPayment.Visible = false;
                _variables.FnSetDisabledButton(btnPrint);
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetEnabledButton(btnCancel);
                _variables.FnSetDisabledButton(btnAddBill);
                LoadDefaultColorandFonts();
                ClearForm();
                dgvBill.AllowUserToAddRows = false;
            }
            catch { }
        }

        private void frmBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmFindPatient frm = new frmFindPatient();
            //    frm.PatientNumber = txtPatientNumber.Text;
            //    frm.ShowDialog();
            //    txtPatientNumber.Text = frm.PatientNumber;
            //    if (txtPatientNumber.Text != null)
            //        PatientInformation(txtPatientNumber.Text);
            //}
            //catch { }
        }

        private void txtPatientNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dgvBill_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _RowNumber = 0;
                _RowNumber = e.RowIndex + 1;
                dgvBill[0, e.RowIndex].Value = _RowNumber;
            }
            catch { }
        }

        private void dgvBill_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ddlBillMode.Enabled == true)
                {
                    string _BillCode = "";
                    decimal _GrossAmt = 0;
                    int Discount = 0;
                    if (e.ColumnIndex == 1)
                    {
                        dgvBill[5, e.RowIndex].Value = "";
                        dgvBill[3, e.RowIndex].Value = "";
                        dgvBill[4, e.RowIndex].Value = "";
                        _BillCode = Convert.ToString(dgvBill[1, e.RowIndex].Value);
                        FillBillData(e.ColumnIndex, e.RowIndex, _BillCode);
                    }

                    if ((dgvBill[2, e.RowIndex].Value != null))
                    {
                        decimal _ServiceTax = Convert.ToDecimal(dgvBill[3, e.RowIndex].Value);
                        decimal _Price = Convert.ToDecimal(dgvBill[4, e.RowIndex].Value);
                        decimal _Total = ((_Price * _ServiceTax) / 100) + _Price;
                        dgvBill[5, e.RowIndex].Value = _Total;
                    }

                    foreach (DataGridViewRow _Row in dgvBill.Rows)
                    {
                        if ((_Row.Cells[2].Value != null) && (Convert.ToDecimal(_Row.Cells[5].Value) > 0))
                            _GrossAmt = _GrossAmt + Convert.ToDecimal(_Row.Cells[5].Value);
                    }
                    txtGrossAmount.Text = _GrossAmt.ToString("0.00");

                    if (txtDiscountAmount.Text != "")
                        Discount = Convert.ToInt32(txtDiscountAmount.Text.ToString());
                    else
                        Discount = 0;
                    _GrossAmt = _GrossAmt - Discount;
                    txtNetAmount.Text = _GrossAmt.ToString("0.00");
                }

                txtReceivedAmount.Text = "";
                txtBalanceAmount.Text = "";
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isClose;
                if (!FormValidation()) { return; }
                PatientBilling _PatientBilling = new PatientBilling();
                lblBillid.Text = "";
                _PatientBilling.PatientID = _patientID;
                _PatientBilling.GrossAmount = Convert.ToDecimal(txtGrossAmount.Text);
                if (txtDiscountAmount.Text != "")
                    _PatientBilling.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                _PatientBilling.NetAmount = Convert.ToDecimal(txtNetAmount.Text);
                _PatientBilling.PaymentModes = Convert.ToInt32(ddlBillMode.SelectedIndex.ToString());
                if (ddlBillMode.SelectedIndex == 1)
                {
                    _PatientBilling.PaidAmount = Convert.ToDecimal(txtReceivedAmount.Text);
                    _PatientBilling.BalanceDue = Convert.ToDecimal(txtBalanceAmount.Text);
                }
                _PatientBilling.AuditUserID = MDIForm.UserID;

                List<PatientBillDetails> _listPatientBillDetails = new List<PatientBillDetails>();
                foreach (DataGridViewRow _Row in dgvBill.Rows)
                {
                    if ((_Row.Cells[2].Value != null) && (Convert.ToDecimal(_Row.Cells[5].Value) > 0))
                    {
                        PatientBillDetails _StructsPatientBillDetails = new PatientBillDetails();
                        _StructsPatientBillDetails.BillDescriptionID = Convert.ToInt32(_Row.Cells[6].Value);
                        _StructsPatientBillDetails.BillCode = Convert.ToString(_Row.Cells[1].Value);
                        _StructsPatientBillDetails.ServiceTax = Convert.ToDecimal(_Row.Cells[3].Value);
                        _StructsPatientBillDetails.Price = Convert.ToDecimal(_Row.Cells[4].Value);
                        _StructsPatientBillDetails.Total = Convert.ToDecimal(_Row.Cells[5].Value);
                        _listPatientBillDetails.Add(_StructsPatientBillDetails);
                    }
                }
                _PatientBilling.PatientBillDetails = _listPatientBillDetails;

                List<PaymentMode> _listPaymentMode = new List<PaymentMode>();
                if (txtChequeNo.Text != "")
                {
                    PatientChequePayment _StructsPatientChequePayment = new PatientChequePayment();
                    _StructsPatientChequePayment.ChequeNumber = Convert.ToInt32(txtChequeNo.Text);
                    _StructsPatientChequePayment.ChequeDate = dtpDOB.Value;
                    _StructsPatientChequePayment.BankName = txtChequeBankName.Text;
                    _StructsPatientChequePayment.Place = txtChequeBranchName.Text;
                    if (txtChequeAmt.Text != "")
                        _StructsPatientChequePayment.Amount = Convert.ToDecimal(txtChequeAmt.Text);
                    _PatientBilling.PatientChequePayment = _StructsPatientChequePayment;
                    _listPaymentMode.Add(PaymentMode.Cheque);
                }

                if (txtDDNo.Text != "")
                {
                    PatientDDPayment _StructsPatientDDPayment = new PatientDDPayment();
                    _StructsPatientDDPayment.DDNumber = Convert.ToInt32(txtDDNo.Text);
                    _StructsPatientDDPayment.DDDate = dtpDateDD.Value;
                    _StructsPatientDDPayment.BankName = txtDDBankName.Text;
                    _StructsPatientDDPayment.Place = txtDDBranchName.Text;
                    if (txtDDAmt.Text != "")
                        _StructsPatientDDPayment.Amount = Convert.ToDecimal(txtDDAmt.Text);
                    _PatientBilling.PatientDDPayment = _StructsPatientDDPayment;
                    _listPaymentMode.Add(PaymentMode.DemandDraft);
                }

                if (txtCardNo.Text != "")
                {
                    PatientCardPayment _StructsPatientCardPayment = new PatientCardPayment();
                    _StructsPatientCardPayment.CardType = ddlCardType.SelectedIndex;
                    _StructsPatientCardPayment.CardNumber = txtCardNo.Text;
                    _StructsPatientCardPayment.HolderName = txtCardHolderName.Text;
                    if (txtCardAmt.Text != "")
                        _StructsPatientCardPayment.Amount = Convert.ToDecimal(txtCardAmt.Text);
                    _PatientBilling.PatientCardPayment = _StructsPatientCardPayment;
                    _listPaymentMode.Add(PaymentMode.CreditOrDebitCard);
                }
                _PatientBilling.ModeOfPayment = _listPaymentMode;
                isClose = MessageBox.Show("No More Details Can be Added to the Billing.\nDo You Want to Close the Bill?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (isClose.ToString() == "Yes")
                {
                    TransactionResult _result = _PatientBilling.Commit(ScreenMode.Add);
                    MessageBox.Show(_result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (_result.Status == TransactionStatus.Success)
                    {
                        lblBillid.Text = "1";
                        dgvBill.AllowUserToAddRows = false;
                        dgvBill.ReadOnly = true;
                        ddlBillMode.SelectedIndex = 0;
                        dgvBill.Rows.Clear();
                        txtDiscountAmount.Text = "";
                        txtNetAmount.Text = "";
                        txtGrossAmount.Text = "";
                        txtPatientNumber_TextChanged(sender, e);
                        _variables.FnSetDisabledButton(btnSave);

                    }
                }
            }
            catch { }
        }

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal _NetAmt = 0;
                if (txtGrossAmount.Text != "")
                {
                    _NetAmt = Convert.ToDecimal(txtGrossAmount.Text) - Convert.ToDecimal(txtDiscountAmount.Text);
                    txtNetAmount.Text = _NetAmt.ToString("0.00");
                }
            }
            catch { }
        }

        private void dgvBill_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if ((dgvBill.CurrentCell.ColumnIndex == 1) || (dgvBill.CurrentCell.ColumnIndex == 1))
                {
                    if (e.Control is TextBox)
                    {
                        TextBox _TextBox = e.Control as TextBox;
                        _TextBox.KeyPress -= new KeyPressEventHandler(CharacterTextBox_KeyPress);
                        _TextBox.KeyPress += new KeyPressEventHandler(CharacterTextBox_KeyPress);
                    }
                }
            }
            catch { }
        }

        private void CharacterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch { }
        }

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtChequeAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                Keys key = (Keys)e.KeyChar;
                if (!(key == Keys.Back || key == Keys.Delete))
                    e.Handled = true;
            }
        }

        private void txtDDNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtDDAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                Keys key = (Keys)e.KeyChar;
                if (!(key == Keys.Back || key == Keys.Delete))
                    e.Handled = true;
            }
        }

        private void txtCardAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                Keys key = (Keys)e.KeyChar;
                if (!(key == Keys.Back || key == Keys.Delete))
                    e.Handled = true;
            }
        }

        private void txtPatientNumber_TextChanged(object sender, EventArgs e)
        {
            string sSelected = "--Select--";
            try
            {
                if (txtPatientNumber.Text.ToString().Trim().Length == txtPatientNumber.MaxLength)
                {
                    PatientInformation(txtPatientNumber.Text);
                    lstPreviousBill.DataSource = PatientBilling.GetPatientBillDates(_appConnection, Convert.ToString(txtPatientNumber.Text)).Tables[0];
                    lstPreviousBill.DisplayMember = "PatientBillDate";
                    lstPreviousBill.ValueMember = "BillingID";
                    if (lstPreviousBill.Items.Count > 0)
                        lstPreviousBill.SelectedIndex = -1;
                    ddlBillMode.Enabled = false;
                }
                else
                {
                    lstPreviousBill.DataSource = null;
                    lstPreviousBill.Items.Clear();
                    ddlBillMode.DataSource = null;
                    ddlBillMode.Items.Clear();
                    ddlBillMode.Items.Add(sSelected);
                    ddlBillMode.SelectedIndex = 0;
                    ddlBillMode.Enabled = false;
                    dgvBill.Rows.Clear();
                    txtGrossAmount.Text = "";
                    txtNetAmount.Text = "";
                    txtDiscountAmount.ReadOnly = false;
                    txtDiscountAmount.Text = "";
                    txtChequeNo.Text = "";
                    txtChequeDate.Text = "";
                    txtChequeAmt.Text = "";
                    txtChequeBankName.Text = "";
                    txtChequeBranchName.Text = "";
                    txtDDNo.Text = "";
                    txtDDDate.Text = "";
                    txtDDAmt.Text = "";
                    txtDDBankName.Text = "";
                    txtDDBranchName.Text = "";
                    txtCardNo.Text = "";
                    txtCardHolderName.Text = "";
                    txtCardAmt.Text = "";
                    txtPatientNumber.Focus();
                    dgvBill.AllowUserToAddRows = false;
                    lblBillid.Text = "";
                    dgvBill.ReadOnly = false;
                    _variables.FnSetEnabledButton(btnCancel);
                    _variables.FnSetDisabledButton(btnSave);
                    _variables.FnSetDisabledButton(btnPrint);
                    _variables.FnSetDisabledButton(btnAddBill);

                }
            }
            catch { }
        }

        private void lstPreviousBill_Click(object sender, EventArgs e)
        {
            try
            {

                _isPreviousBillClicked = true;
            
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetEnabledButton(btnPrint);

                TextboxEmpty();
                ViewBillDetails();

                ddlBillMode.Enabled = false;
                txtCardAmt.ReadOnly = true;
                txtCardHolderName.ReadOnly = true;
                ddlCardType.Enabled = false;
                txtCardNo.ReadOnly = true;
                txtChequeAmt.ReadOnly = true;
                txtChequeBankName.ReadOnly = true;
                txtChequeBranchName.ReadOnly = true;
                txtChequeDate.ReadOnly = true;
                txtChequeNo.ReadOnly = true;
                txtDDAmt.ReadOnly = true;
                txtDDBankName.ReadOnly = true;
                txtDDBranchName.ReadOnly = true;
                txtDDDate.ReadOnly = true;
                txtDDNo.ReadOnly = true;
                txtDiscountAmount.ReadOnly = true;
                txtGrossAmount.ReadOnly = true;
                txtNetAmount.ReadOnly = true;
                txtReceivedAmount.ReadOnly = true;
                ddlCardType.Enabled = false;
                txtCardNo.Enabled = false;
                txtCardHolderName.Enabled = false;
                ddlCardType.Enabled = false;
                txtReceivedAmount.Visible = true;
                txtBalanceAmount.Visible = true;

                _isPreviousBillClicked = false;
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblBillid.Text != "")
                {
                    

                    //ReportDocument rpt = new ReportDocument();
                    ////rpt.Load(@"..\..\Reports\BillingReport.rpt");
                    //rpt.Load(Application.StartupPath + reportname);
                    //rpt.Database.Tables[0].SetDataSource(tempDS);
                    //PrintForm.ReportViewer.ReportSource = rpt;
                    //PrintForm.ReportViewer.Show();
                    //PrintForm.ShowDialog(this);
                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("PatientBilling", "frmBill", "btnPrint", ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string sSelected = "--Select--";
                ddlBillMode.DataSource = null;
                ddlBillMode.Items.Clear();
                ddlBillMode.Items.Add(sSelected);
                dgvBill.Rows.Clear();
                TextboxEmpty();
                txtPatientNumber.Text = "";
                txtPatientNumber.Focus();
                lstPreviousBill.DataSource = null;
                lstPreviousBill.Items.Clear();
                dgvBill.AllowUserToAddRows = false;
                txtReceivedAmount.ReadOnly = false;
                ddlBillMode.SelectedIndex = 0;
                ddlBillMode_SelectedIndexChanged(sender, e);
                lblPatientName.Text = "";
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetEnabledButton(btnCancel);
                _variables.FnSetDisabledButton(btnPrint);

            }
            catch { }
        }

        private void txtCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)))
            {
                Keys key = (Keys)e.KeyChar;
                if (!(key == Keys.Back || e.KeyChar == '.' || key == Keys.Delete))
                    e.Handled = true;
            }
        }

        private void ddlBillMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBillMode.SelectedIndex == 1)
            {
                tabPayment.Visible = false;
                tabDD.Visible = false;
                tabCredit.Visible = false;
                tbCash.Visible = true;
            }
            else if (ddlBillMode.SelectedIndex == 2)
            {
                tabPayment.Visible = true;
                tabDD.Visible = false;
                tabCredit.Visible = false;
                tbCash.Visible = false;
            }
            else if (ddlBillMode.SelectedIndex == 3)
            {
                tabPayment.Visible = false;
                tabDD.Visible = true;
                tabCredit.Visible = false;
                tbCash.Visible = false;
            }
            else if (ddlBillMode.SelectedIndex == 4)
            {
                tabPayment.Visible = false;
                tabDD.Visible = false;
                tabCredit.Visible = true;
                ddlCardType.Enabled = true;
                ddlCardType.SelectedIndex = 0;
                tbCash.Visible = false;
            }
            else if (ddlBillMode.SelectedIndex == 0)
            {
                tabPayment.Visible = false;
                tabDD.Visible = false;
                tabCredit.Visible = false;
                tbCash.Visible = false;

            }
        }

        private void dgvBill_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            txtDiscountAmount.ReadOnly = false;
            ostrpDelete.Visible = true;
            _variables.FnSetEnabledButton(btnSave);
            _variables.FnSetDisabledButton(btnPrint);
            txtReceivedAmount.Text = "";
            txtBalanceAmount.Text = "";
        }

        private void dgvBill_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _variables.FnSetDisabledButton(btnSave);
            ostrpDelete.Visible = false;
            txtReceivedAmount.Text = "";
            txtBalanceAmount.Text = "";
        }

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {
            txtDDAmt.Text = txtNetAmount.Text;
            txtCardAmt.Text = txtNetAmount.Text;
            txtChequeAmt.Text = txtNetAmount.Text;
            txtCashBillAmount.Text = txtNetAmount.Text;
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPatientName.Text != "")
                {
                    lstPreviousBill.SelectedIndex = -1;
                    ddlBillMode.SelectedIndex = 0;
                    ddlBillMode.Enabled = true;
                    txtCardAmt.ReadOnly = true;
                    txtCardHolderName.ReadOnly = false;
                    txtCardNo.ReadOnly = false;
                    txtChequeAmt.ReadOnly = true;
                    txtChequeBankName.ReadOnly = false;
                    txtChequeBranchName.ReadOnly = false;
                    txtChequeDate.ReadOnly = false;
                    txtChequeNo.ReadOnly = false;
                    txtDDAmt.ReadOnly = true;
                    txtDDBankName.ReadOnly = false;
                    txtDDBranchName.ReadOnly = false;
                    txtDDDate.ReadOnly = false;
                    txtDDNo.ReadOnly = false;
                    txtDiscountAmount.ReadOnly = false;
                    txtGrossAmount.ReadOnly = true;
                    txtNetAmount.ReadOnly = true;
                    dgvBill.Rows.Clear();
                    dgvBill.AllowUserToAddRows = true;
                    dgvBill.ReadOnly = false;
                    txtReceivedAmount.ReadOnly = false;
                    ddlCardType.Enabled = true;
                    txtCardNo.Enabled = true;
                    txtCardHolderName.Enabled = true;
                    TextboxEmpty();
                }
                else
                {
                    ddlBillMode.Enabled = false;
                    btnCancel_Click(sender, e);
                }
            }
            catch { }
        }

        private void txtDiscountAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _NetAmt = 0;
                if (txtGrossAmount.Text != "")
                    if (txtDiscountAmount.Text == "")
                    {
                        _NetAmt = Convert.ToDecimal(txtGrossAmount.Text);
                        txtNetAmount.Text = _NetAmt.ToString("0.00");
                    }
            }
            catch { }

        }

        private void txtChequeDate_Validated(object sender, EventArgs e)
        {
            if (txtChequeDate.Text.Trim() != "")
            {
                try
                {
                    String[] date = txtChequeDate.Text.Split('/');
                    string mmddyy = date[1].ToString().Trim() + "/" + date[0].ToString().Trim() + "/" + date[2].ToString().Trim();
                    dtpDOB.Value = DateTime.Parse(mmddyy.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Enter Valid Date.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeDate.Focus();
                }
            }
        }

        private void txtDDDate_Validated(object sender, EventArgs e)
        {
            if (txtDDDate.Text.Trim() != "")
            {
                try
                {
                    String[] date = txtDDDate.Text.Split('/');
                    string mmddyy = date[1].ToString().Trim() + "/" + date[0].ToString().Trim() + "/" + date[2].ToString().Trim();
                    dtpDateDD.Value = DateTime.Parse(mmddyy.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Enter Valid Date.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeDate.Focus();
                }
            }
        }

        private void dtpDateDD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dtDate = new DateTime();
                dtDate = dtpDateDD.Value;
                txtDDDate.Text = dtDate.ToString("dd/MM/yyyy");
            }
            catch { }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dtDate = new DateTime();
                dtDate = dtpDOB.Value;
                txtChequeDate.Text = dtDate.ToString("dd/MM/yyyy");
            }
            catch { }
        }

        private void dgvBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBill[1, e.RowIndex].Value == null)
                {
                    dgvBill[5, e.RowIndex].Value = "";
                    dgvBill[3, e.RowIndex].Value = "";
                    dgvBill[4, e.RowIndex].Value = "";
                    dgvBill.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    dgvBill_CellValidated(sender, e);
                }
            }
            catch { }
        }

        private void txtReceivedAmount_TextChanged(object sender, EventArgs e)
        {

            if (_isPreviousBillClicked)
            {

            }
            else
            {
                try
                {
                    decimal _ReceivedAmount = 0;
                    decimal _CashBillAmount = 0;

                    if (txtCashBillAmount.Text != "")
                        _CashBillAmount = Convert.ToDecimal(txtCashBillAmount.Text);
                    else
                        _CashBillAmount = 0;
                    if (txtReceivedAmount.Text != "")
                        _ReceivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
                    else
                        _ReceivedAmount = 0;

                    txtBalanceAmount.Text = Convert.ToString(_CashBillAmount - _ReceivedAmount);
                }
                catch { }
            }
        }

        private void txtReceivedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void ostrpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gridRowIndex < dgvBill.Rows.Count - 1)
                    dgvBill.Rows.RemoveAt(_gridRowIndex);
            }
            catch { }
        }

        private void dgvBill_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = dgvBill.PointToClient(System.Windows.Forms.Cursor.Position);
                DataGridView.HitTestInfo hti = dgvBill.HitTest(pt.X, pt.Y);
                _gridRowIndex = hti.RowIndex;
            }
            catch { }
        }

        private void txtCardNo_Leave(object sender, EventArgs e)
        {
            //string cardNumber = txtCardNo.Text;
            //string CardType = Convert.ToString(CardValidation.GetCardType(cardNumber));
            //MessageBox.Show(CardType);
            //MessageBox.Show(Convert.ToString(CardValidation.ValidateCreditCardNumber(cardNumber)));
            //Console.ReadLine();
        }

        private void dgvBill_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (ddlBillMode.Enabled == true)
                {
                    string _BillCode = "";
                    decimal _GrossAmt = 0;
                    int Discount = 0;
                    int _Col = 0;
                    int _Row = 0;
                    if (e.KeyCode == Keys.F2)
                    {
                        if (this.dgvBill.CurrentCellAddress.X == 1) //gvMedicinalTreatmentColDrugCombo.DisplayIndex)
                        {
                            _Col = this.dgvBill.CurrentCellAddress.X;
                            _Row = this.dgvBill.CurrentCellAddress.Y;
                            frmFindBill objFindBill = new frmFindBill();
                            objFindBill.ShowDialog();
                            if (objFindBill.BillDescriptionID != "-1")
                            {
                                if (this.dgvBill.CurrentCellAddress.Y == dgvBill.Rows.Count - 1)
                                {
                                    dgvBill.Rows.Add(1);
                                    dgvBill[1, this.dgvBill.CurrentCellAddress.Y].ReadOnly = false;
                                    dgvBill[1, this.dgvBill.CurrentCellAddress.Y - 1].Value = objFindBill.BillDescriptionID;
                                    FillBillData(dgvBill.CurrentCellAddress.X, dgvBill.CurrentCellAddress.Y - 1, objFindBill.BillDescriptionID);
                                    //dgvBill.Rows[dgvBill.CurrentCellAddress.Y - 1].Selected = true;
                                }
                            }
                            if (_Col == 1)
                            {
                                dgvBill[5, _Row].Value = "";
                                dgvBill[3, _Row].Value = "";
                                dgvBill[4, _Row].Value = "";
                                _BillCode = Convert.ToString(dgvBill[1, _Row].Value);
                                FillBillData(_Col, _Row, objFindBill.BillDescriptionID);
                            }

                            if ((dgvBill[2, _Row].Value != null))
                            {
                                decimal _ServiceTax = Convert.ToDecimal(dgvBill[3, _Row].Value);
                                decimal _Price = Convert.ToDecimal(dgvBill[4, _Row].Value);
                                decimal _Total = ((_Price * _ServiceTax) / 100) + _Price;
                                dgvBill[5, _Row].Value = _Total;
                            }

                            foreach (DataGridViewRow _Rows in dgvBill.Rows)
                            {
                                if ((_Rows.Cells[2].Value != null) && (Convert.ToDecimal(_Rows.Cells[5].Value) > 0))
                                    _GrossAmt = _GrossAmt + Convert.ToDecimal(_Rows.Cells[5].Value);

                                _Rows.Cells[0].Value = _Rows.Index + 1;
                            }
                            txtGrossAmount.Text = _GrossAmt.ToString("0.00");

                            if (txtDiscountAmount.Text != "")
                                Discount = Convert.ToInt32(txtDiscountAmount.Text.ToString());
                            else
                                Discount = 0;
                            _GrossAmt = _GrossAmt - Discount;
                            txtNetAmount.Text = _GrossAmt.ToString("0.00");
                        }
                    }
                }
            }
            catch { }

        }

        private void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCardType.SelectedIndex != 0)
                {
                    txtCardNo.ReadOnly = false;

                    if (ddlCardType.SelectedIndex == 1)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 2)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 3)
                    {
                        txtCardNo.Mask = "0000-0000-0000-000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 4)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 5)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 6)
                    {
                        txtCardNo.Mask = "0000-0000-000-000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 7)
                    {
                        txtCardNo.Mask = "0000-0000-000-000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 8)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 9)
                    {
                        txtCardNo.Mask = "0000-0000-0000-00";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 10)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 11)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000-000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 12)
                    {
                        txtCardNo.Mask = "0000-0000-0000-0000-000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    else if (ddlCardType.SelectedIndex == 13)
                    {
                        txtCardNo.Mask = "0000-0000-0000-000";
                        _CardTypeLength = txtCardNo.Mask.Length;
                    }
                    //txtCardNo.Text = "";
                    txtCardNo.Focus();
                }
                else
                {
                    txtCardNo.ReadOnly = true;
                    txtCardNo.Mask = "";
                    txtCardNo.Text = "";
                }
            }
            catch { }
        }

        #endregion

        #region Private Method(s)

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnButtonTheme(btnSave);
            _variables.FnButtonTheme(btnPrint);
            _variables.FnButtonTheme(btnClose);
            _variables.FnButtonTheme(btnSearch);
            _variables.FnButtonTheme(btnCancel);
            _variables.FnButtonTheme(btnAddBill);

            _variables.FnSetToolTip(btnAddBill, "Alt+N New Bill");
            _variables.FnSetToolTip(btnSave, "Alt+S Save");
            _variables.FnSetToolTip(btnPrint, "Alt+P Print");
            _variables.FnSetToolTip(btnClose, "Alt+C Close");
            _variables.FnSetToolTip(btnClose, "Alt+H Search");
            _variables.FnSetToolTip(btnCancel, "Alt+R Reset");
            _variables.FnGridTheme(dgvBill);
            _variables.FnSubTitleTheme(lblPatientNumber);
        }

        private void ClearForm()
        {
            txtPatientNumber.Text = "";
            lblPatientName.Text = "";
            dgvBill.Rows.Clear();
            TextboxEmpty();
            ostrpDelete.Visible = false;
            txtPatientNumber.Focus();
            dgvBill.AllowUserToAddRows = true;
            ddlBillMode.Enabled = false;
            _variables.FnSetDisabledButton(btnAddBill);
            _variables.FnSetDisabledButton(btnSave);
            _variables.FnSetDisabledButton(btnPrint);
            _variables.FnSetEnabledButton(btnCancel);

        }

        private void TextboxEmpty()
        {
            txtDiscountAmount.Text = "";
            txtNetAmount.Text = "";
            txtGrossAmount.Text = "";
            txtCardAmt.Text = "";
            txtCardHolderName.Text = "";
            txtCardNo.Text = "";
            ddlCardType.SelectedIndex = 0;
            txtChequeAmt.Text = "";
            txtChequeBankName.Text = "";
            txtChequeBranchName.Text = "";
            txtChequeDate.Text = "";
            txtChequeNo.Text = "";
            txtDDAmt.Text = "";
            txtDDBankName.Text = "";
            txtDDBranchName.Text = "";
            txtDDDate.Text = "";
            txtDDNo.Text = "";
            txtDiscountAmount.Text = "";
            txtGrossAmount.Text = "";
            txtNetAmount.Text = "";
            txtReceivedAmount.Text = "";
            txtCashBillAmount.Text = "";
            txtBalanceAmount.Text = "";
        }

        private void DisplayOrderinginGrid()
        {
            BillSNo.DisplayIndex = 0;
            BillCode.DisplayIndex = 1;
            BillDesc.DisplayIndex = 2;
            BillServiceTax.DisplayIndex = 3;
            BillPrice.DisplayIndex = 4;
            BillTotal.DisplayIndex = 5;
        }

        private void PatientInformation(string PatientNumber)
        {
            string sSelected = "--Select--";
            try
            {
                //lblPatientName.Text = "";
                //Registration _Registration = new Registration(txtPatientNumber.Text, true);
                //if (_Registration.PatientID > 0)
                //{
                //    _patientID = _Registration.PatientID;
                //    lblPatientName.Text = _Registration.Title + " " + _Registration.Name +
                //        "[" + _Registration.Gender + "]" + " " + Utility.CalculateAge(_Registration.DateOfBirth);
                //    ddlBillMode.DataSource = null;
                //    ddlBillMode.Items.Clear();
                //    ddlBillMode.Items.Add(sSelected);
                //    ddlBillMode.Items.Add("Cash");
                //    ddlBillMode.Items.Add("Cheque");
                //    ddlBillMode.Items.Add("Demand Draft");
                //    ddlBillMode.Items.Add("Credit Card");
                //    ddlBillMode.SelectedIndex = 0;
                //    if (lblPatientName.Text != "")
                //        _variables.FnSetEnabledButton(btnAddBill);
                //    else
                //        _variables.FnSetDisabledButton(btnAddBill);


                //}
                dgvBill.Focus();
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("PatientBilling", "frmBill", "Patient Information", ex.Message);
            }
        }

        private bool FormValidation()
        {
            bool valid = true;
            if (dgvBill.Rows.Count <= 1)
            {
                valid = false;
                MessageBox.Show("Please Enter Atleast One Bill Transaction.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (ddlBillMode.SelectedIndex == 0)
            {
                valid = false;
                MessageBox.Show("Please Select The Payment Mode.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ddlBillMode.Focus();
            }
            else if (ddlBillMode.SelectedIndex == 1)
            {
                if ((txtReceivedAmount.Text.ToString().Trim() == "") || (txtReceivedAmount.Text.ToString().Trim() == null))
                {
                    valid = false;
                    MessageBox.Show("Please Enter The Cash Tendered.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtReceivedAmount.Focus();
                }
                else if (Convert.ToDecimal(txtReceivedAmount.Text) <= Convert.ToDecimal(txtCashBillAmount.Text))
                {
                    valid = false;
                    MessageBox.Show("Please Enter The Tendered Amount Correctly.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtReceivedAmount.Focus();
                }

            }
            else if (ddlBillMode.SelectedIndex == 2)
            {
                if ((txtChequeNo.Text.ToString().Trim() == "") || (txtChequeNo.Text.ToString().Trim() == null))
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid Cheque Number.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeNo.Focus();
                }
                else if (!Utility.ValidateDate(txtChequeDate.Text))
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid Cheque Date.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeDate.Focus();
                }
                else if ((txtChequeAmt.Text.Trim() == "") || Convert.ToDecimal(txtChequeAmt.Text) <= 0)
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid Cheque Amount.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeAmt.Focus();
                }
                else if (txtChequeBankName.Text.Trim() == "")
                {
                    valid = false;
                    MessageBox.Show("Please Enter Cheque Bank Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeBankName.Focus();
                }
                else if (txtChequeBranchName.Text.Trim() == "")
                {
                    valid = false;
                    MessageBox.Show("Please Enter Cheque Branch Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtChequeBranchName.Focus();
                }
            }
            else if (ddlBillMode.SelectedIndex == 3)
            {
                if (txtDDNo.Text.Trim() == "")
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid DD Number.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDDNo.Focus();
                }
                else if (!Utility.ValidateDate(txtDDDate.Text))
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid DD Date.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDDDate.Focus();
                }
                else if ((txtDDAmt.Text.Trim() == "") || Convert.ToDecimal(txtDDAmt.Text) <= 0)
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid DD Amount.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDDAmt.Focus();
                }
                else if (txtDDBankName.Text.Trim() == "")
                {
                    valid = false;
                    MessageBox.Show("Please Enter DD Bank Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDDBankName.Focus();
                }
                else if (txtDDBranchName.Text.Trim() == "")
                {
                    valid = false;
                    MessageBox.Show("Please Enter DD Branch Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDDBranchName.Focus();
                }
            }
            else if (ddlBillMode.SelectedIndex == 4)
            {
                if (ddlCardType.SelectedIndex == 0)
                {
                    valid = false;
                    MessageBox.Show("Please Select The Card Type.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ddlCardType.Focus();
                }
                else if (txtCardNo.Text.Length != _CardTypeLength)
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid Card Number.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtCardNo.Focus();
                }
                else if (!ValidCards())
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid Card Number.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtCardNo.Focus();
                }
                else if (txtCardHolderName.Text.Trim() == "")
                {
                    valid = false;
                    MessageBox.Show("Please Enter Card Holder Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtCardHolderName.Focus();
                }
                else if ((txtCardAmt.Text.Trim() == "") || Convert.ToDecimal(txtCardAmt.Text) <= 0)
                {
                    valid = false;
                    MessageBox.Show("Please Enter Valid Card Amount.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtCardAmt.Focus();
                }
            }

            return valid;
        }

        private bool ValidCards()
        {
            //bool IsValidCard = false;
            //try
            //{
            //    string cardNumber = txtCardNo.Text;
            //    string CardType = Convert.ToString(CardValidation.GetCardType(cardNumber));
            //    if (CardType == ddlCardType.Text)
            //        IsValidCard = true;
            //    else
            //        IsValidCard = false;
            //    //MessageBox.Show(Convert.ToString(CardValidation.ValidateCreditCardNumber(cardNumber)));
            //}
            //catch { }
            //return IsValidCard;
            return true;

        }
        private void FillBillData(int ColumnIndex, int RowIndex, string BillCode)
        {
            try
            {
                BillDescription _BillDescription = new BillDescription(BillCode, true);
                dgvBill[1, RowIndex].Value = _BillDescription.BillCode;
                dgvBill[2, RowIndex].Value = _BillDescription.Description;
                dgvBill[3, RowIndex].Value = _BillDescription.ServiceTax.ToString();
                dgvBill[4, RowIndex].Value = _BillDescription.Price.ToString();
                dgvBill[6, RowIndex].Value = _BillDescription.BillDescriptionID.ToString();
                txtDiscountAmount.ReadOnly = false;
                ostrpDelete.Visible = true;
                _variables.FnSetEnabledButton(btnSave);
                _variables.FnSetDisabledButton(btnPrint);

            }
            catch (Exception ex)
            {                
                ErrorLog.LogErrorMessageToDB("Patient Billing", "frmBill", "Fill Bill Data", ex.Message);
            }
        }

        private void ReportDataSet()
        {
            //dtInvRes.Rows.Clear();
            //for (int i = 0; i < dgvBill.Rows.Count; i++)
            //{
            //    if (dgvBill[1, i].Value != null)
            //    {
            //        try
            //        {
            //            DataRow nRow = dtInvRes.NewRow();
            //            nRow["AmountofBillDescription"] = dgvBill[4, i].Value;
            //            nRow["BillDescription"] = dgvBill[2, i].Value;
            //            nRow["Tax"] = dgvBill[3, i].Value;
            //            nRow["Total"] = dgvBill[5, i].Value;
            //            dtInvRes.Rows.Add(nRow);
            //        }
            //        catch (Exception ex)
            //        {                        
            //            ErrorLog.LogErrorMessageToDB("Patient Billing", "frmBill", "ReportDataSet");
            //        }
            //    }
            //}
        }

        private bool ViewBillDetails()
        {
            bool dataExist = false;
            int paymentType = 0;
            int _RowIndex = 0;
            try
            {
                PatientBilling objPatientBilling = new PatientBilling(Convert.ToInt32(lstPreviousBill.SelectedValue), true);
                if (objPatientBilling.PatientBillID > 0)
                {
                    
                    paymentType = Convert.ToInt32(objPatientBilling.PaymentModes.ToString());
                    ddlBillMode.SelectedIndex = paymentType;
                    txtDiscountAmount.Text = objPatientBilling.DiscountAmount.ToString();
                    txtNetAmount.Text = objPatientBilling.NetAmount.ToString();
                    txtGrossAmount.Text = objPatientBilling.GrossAmount.ToString();
                    txtCashBillAmount.Text = objPatientBilling.NetAmount.ToString();
                    txtReceivedAmount.Text = objPatientBilling.PaidAmount.ToString();
                    txtBalanceAmount.Text = objPatientBilling.BalanceDue.ToString();
                    lblBillDate.Text = objPatientBilling.BillDate.ToString();
                    dgvBill.Rows.Clear();
                    List<PatientBillDetails> _listPatientBilling = new List<PatientBillDetails>();
                    _listPatientBilling = PatientBilling.GetPatientBillingDetails(_appConnection, Convert.ToInt32(lstPreviousBill.SelectedValue));
                    foreach (PatientBillDetails _StructsPatientBillDetails in _listPatientBilling)
                    {
                        dgvBill.Rows.Add();
                        dgvBill[0, _RowIndex].Value = _RowIndex + 1;
                        lblBillid.Text = Convert.ToString(lstPreviousBill.SelectedValue);
                        dgvBill[1, _RowIndex].Value = _StructsPatientBillDetails.BillCode;
                        dgvBill[2, _RowIndex].Value = _StructsPatientBillDetails.BillDescription;
                        dgvBill[3, _RowIndex].Value = _StructsPatientBillDetails.ServiceTax;
                        dgvBill[4, _RowIndex].Value = _StructsPatientBillDetails.Price;
                        dgvBill[5, _RowIndex].Value = _StructsPatientBillDetails.Total;
                        dgvBill[6, _RowIndex].Value = _StructsPatientBillDetails.BillDescriptionID;
                        dgvBill.Rows[_RowIndex].ReadOnly = true;
                        _RowIndex++;
                    }
                    if (ddlBillMode.SelectedIndex == 2)
                    {
                        List<PatientChequePayment> _listChequePayment = new List<PatientChequePayment>();
                        _listChequePayment = PatientBilling.GetPatientBillChequeDetails(_appConnection, Convert.ToInt32(lstPreviousBill.SelectedValue));
                        foreach (PatientChequePayment _StructsChequePayment in _listChequePayment)
                        {
                            txtChequeNo.Text = Convert.ToString(_StructsChequePayment.ChequeNumber);
                            txtChequeDate.Text = Convert.ToString(_StructsChequePayment.ChequeDate.ToString("dd/MM/yyyy"));
                            txtChequeBankName.Text = _StructsChequePayment.BankName;
                            txtChequeBranchName.Text = _StructsChequePayment.Place;
                            txtChequeAmt.Text = Convert.ToString(_StructsChequePayment.Amount);

                        }
                    }
                    else if (ddlBillMode.SelectedIndex == 3)
                    {
                        List<PatientDDPayment> _listDDPayment = new List<PatientDDPayment>();
                        _listDDPayment = PatientBilling.GetPatientBillDDDetails(_appConnection, Convert.ToInt32(lstPreviousBill.SelectedValue));
                        foreach (PatientDDPayment _StructsDDPayment in _listDDPayment)
                        {
                            txtDDNo.Text = Convert.ToString(_StructsDDPayment.DDNumber);
                            txtDDDate.Text = Convert.ToString(_StructsDDPayment.DDDate.ToString("dd/MM/yyyy"));
                            txtDDBankName.Text = _StructsDDPayment.BankName;
                            txtDDBranchName.Text = _StructsDDPayment.Place;
                            txtDDAmt.Text = Convert.ToString(_StructsDDPayment.Amount);
                        }
                    }
                    else if (ddlBillMode.SelectedIndex == 4)
                    {
                        List<PatientCardPayment> _listCardPayment = new List<PatientCardPayment>();
                        _listCardPayment = PatientBilling.GetPatientBillCardDetails(_appConnection, Convert.ToInt32(lstPreviousBill.SelectedValue));
                        foreach (PatientCardPayment _StructsCardPayment in _listCardPayment)
                        {
                            ddlCardType.SelectedIndex = _StructsCardPayment.CardType;
                            txtCardNo.Text = _StructsCardPayment.CardNumber;
                            txtCardHolderName.Text = _StructsCardPayment.HolderName;
                            txtCardAmt.Text = Convert.ToString(_StructsCardPayment.Amount);
                        }
                    }
                    dgvBill.AllowUserToAddRows = false;
                    txtDiscountAmount.ReadOnly = true;
                }
                dataExist = true;
            }
            catch { }
            return dataExist;
        }

        private void GetHospitalInformation()
        {
            // Gets the Hospital Information - For printing in reports
            try
            {
                DataSet hospitalDS;
                hospitalDS = CommonDL.GetHospitalDetails(_appConnection);
                foreach (DataRow dRow in hospitalDS.Tables[0].Rows)
                {
                    _hospitalName = dRow["Name"].ToString().Trim();

                    _hospitalAddressDetails1 = dRow["AddressLine1"].ToString().Trim() + ", " +
                                               dRow["AddressLine2"].ToString().Trim() + "  " +
                                               dRow["AddressLine3"].ToString().Trim();

                    _hospitalAddressDetails2 = dRow["Area"].ToString().Trim() + ", " +
                                               dRow["City"].ToString().Trim() + " - " +
                                               dRow["PostalCode"].ToString().Trim() + ".";
                }

                hospitalDS = null;
            }
            catch (Exception ex)
            {


                ErrorLog.LogErrorMessageToDB("Patient Billing", "frmBill", "GetHospitalInformation", ex.Message);
            }
        }

        #endregion

    }
}