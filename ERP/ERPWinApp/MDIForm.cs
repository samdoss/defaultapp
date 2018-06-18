using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Linq;
using ERP.DataLayer;
using ERP.CommonLayer;

namespace ERPWinApp
{
    public partial class MDIForm : Form
    {
        #region Constructors

        public MDIForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        public static bool IsDoctor
        {
            get { return _isDoctor; }
            set { _isDoctor = value; }
        }

        public static int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public static int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        public static string UserNames
        {
            get { return _userNames; }
            set { _userNames = value; }
        }

        public static string CurrencySymbol { get; set; }

        #endregion

        #region Private Variables

        ApplicationConnection _ApplicationConnection = new ApplicationConnection();
        static bool _isDoctor;
        private DateTime _serverDateTime = new DateTime();
        static string _userNames;
        static int _userID, _companyID;
        public static string _userName, _CompanyName;
        public static string CompanyPan { get; set; }
        public static string CompanyBankName { get; set; }
        public static string CompanyBankAccountNumber { get; set; }
        public static string CompanyBankIfscCode { get; set; }

        private int _imgWidth = 34;
        internal string reportname = "\\Help\\HelpFile.chm";
        Microsoft.Win32.RegistryKey key;

        #endregion

        #region Private Event(s)

        private void MDIPCS_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = _ApplicationConnection.ConnectConnectionString();

                GetCurrentServerDateTime();
                lblStatusSystemDate.Text = _serverDateTime.ToString("dd/MM/yyyy");

                tstripCustomers.Visible = false;

                tstripCustomersBlank1.Width = tstripCustomersBlank1.Width + _imgWidth;

                tstripHelp.Visible = false;
                tstripHelpBlank1.Width = tstripHelpBlank1.Width + _imgWidth;

                toolStripLogout.Visible = true;
                tstripSeparator1.Width = 10 + (8 * 100) + 60 + 96;

                Company companyService = new Company();

                Company activeCompany = (from company in companyService.GetAllCompanyList()
                                                        .Where(v => v.Status == true)
                                         select company).SingleOrDefault();

                SetControlsWithData(activeCompany);
                SetMenuForUser();
                lblStatusUserName.Text = _userName;
                _userNames = _userName;

                if (_CompanyName.ToString() == "")
                    lblStatusCompanyName.Text = "<Company Name>";
                else
                    lblStatusCompanyName.Text = _CompanyName;

                lblStatusCopyright.Text = "©2017 SamsTechnologies";

                ApplicationHelp.HelpNamespace = (Application.StartupPath + reportname);
                ApplicationHelp.SetHelpKeyword(this, "hm_welcome.htm");
                ApplicationHelp.SetHelpNavigator(this, HelpNavigator.Topic);
            }
            catch { }
        }




        private void SetControlsWithData(Company activeCompany)
        {
            if (activeCompany == null)
                return;

            CompanyID = activeCompany.CompanyId;
            _CompanyName = activeCompany.CompanyName;
            CurrencySymbol = activeCompany.Currency;
            CompanyPan = activeCompany.PAN;
            CompanyBankName = activeCompany.BankName;
            CompanyBankAccountNumber = activeCompany.BankAccountNumber;
            CompanyBankIfscCode = activeCompany.BankIFSC;


            //txtAddress.Text = activeCompany.Address;

        }
        //Doctor Menu 


        //Registration Menu
        private void smnuClients_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    ClientsReport childForm = new ClientsReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "ClientsReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        ClientsReport childForm = new ClientsReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuProduct_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    ProductServiceReport childForm = new ProductServiceReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "ProductServiceReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        ProductServiceReport childForm = new ProductServiceReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuStock_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmStockMaster childForm = new frmStockMaster();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmStockMaster")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmStockMaster childForm = new frmStockMaster();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmAttendance childForm = new frmAttendance();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmAttendance")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmAttendance childForm = new frmAttendance();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuEstimate_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    AddEditEstimate childForm = new AddEditEstimate();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "AddEditEstimate")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        AddEditEstimate childForm = new AddEditEstimate();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuProductMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmProductMaterial childForm = new frmProductMaterial();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmProductMaterial")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmProductMaterial childForm = new frmProductMaterial();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        //Billing Menu
        private void smnuInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    AddEditInvoice childForm = new AddEditInvoice();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "AddEditInvoice")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        AddEditInvoice childForm = new AddEditInvoice();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuInvoicesReport_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    InvoicesReport childForm = new InvoicesReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "InvoicesReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        InvoicesReport childForm = new InvoicesReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }



        private void smnuPurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    AddEditPurchaseOrder childForm = new AddEditPurchaseOrder();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "AddEditPurchaseOrder")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        AddEditPurchaseOrder childForm = new AddEditPurchaseOrder();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        //Tax Company Master
        private void smnuTax_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    AddTaxes childForm = new AddTaxes();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "AddTaxes")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        AddTaxes childForm = new AddTaxes();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        //Help Menu
        private void smnuHelpContents_Click(object sender, EventArgs e)
        {
            try
            {
                tstripHelp_Click(sender, e);
            }
            catch { }
        }

        private void smnuHelpAbout_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    bool found = false;

            //    // get all of the MDI children in an array

            //    Form[] charr = this.MdiChildren;

            //    if (charr.Length == 0)      // no child form is opened
            //    {
            //        frmHelpAbout childForm = new frmHelpAbout();
            //        childForm.MdiParent = this;
            //        // The StartPosition property is essential

            //        // for the location property to work

            //        childForm.StartPosition = FormStartPosition.CenterScreen;
            //        childForm.Location = new Point(0, 0);
            //        childForm.Show();
            //    }
            //    else      // child forms are opened
            //    {

            //        foreach (Form chform in charr)
            //        {
            //            if (chform.Name == "frmHelpAbout")
            //            // one instance of the form is already opened
            //            {
            //                chform.Activate();
            //                found = true;
            //                break;   // exit loop

            //            }
            //            else
            //                found = false;      // make sure flag is set to

            //            // false if the form is not found

            //        }

            //        if (found == false)
            //        {
            //            frmHelpAbout childForm = new frmHelpAbout();
            //            childForm.MdiParent = this;
            //            // The StartPosition property is essential

            //            // for the location property to work

            //            childForm.StartPosition = FormStartPosition.CenterScreen;
            //            childForm.Location = new Point(0, 0);
            //            childForm.Show();
            //        }
            //    }
            //}
            //catch { }
        }

        private void smnuBillDescriptions_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmBilling childForm = new frmBilling();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmBilling")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmBilling childForm = new frmBilling();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        //
        //Cheque Process
        private void smnuBankDetails_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmFindBankDetails childForm = new frmFindBankDetails();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmFindBankDetails")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmFindBankDetails childForm = new frmFindBankDetails();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }




        private void smnuCreditDebit_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    CreditDebitReport childForm = new CreditDebitReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "CreditDebitReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        CreditDebitReport childForm = new CreditDebitReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        //Cheque Process
        private void smnuEntryCheque_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    ChequeProcessReport childForm = new ChequeProcessReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "ChequeProcessReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        ChequeProcessReport childForm = new ChequeProcessReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuManageSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    SuppliersReport childForm = new SuppliersReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "SuppliersReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        SuppliersReport childForm = new SuppliersReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuManageEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    EmployeesReport childForm = new EmployeesReport();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "EmployeesReport")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        EmployeesReport childForm = new EmployeesReport();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuUnits_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmUnitMaster childForm = new frmUnitMaster();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmUnitMaster")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmUnitMaster childForm = new frmUnitMaster();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuRoleDescription_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmRoleMaster childForm = new frmRoleMaster();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmRoleMaster")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmRoleMaster childForm = new frmRoleMaster();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuCSCity_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmCountryStateCity childForm = new frmCountryStateCity();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmCountryStateCity")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmCountryStateCity childForm = new frmCountryStateCity();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        // User Form
        private void smnuUsers_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmUser childForm = new frmUser();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmUser")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmUser childForm = new frmUser();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuCompanyInformation_Click(object sender, EventArgs e)
        {
            try
            {
                Company companyService = new Company();
                Company activeCompany = (from company in companyService.GetAllCompanyList()
                        .Where(v => v.Status == true)
                                         select company).SingleOrDefault();

                if (activeCompany.CompanyId != 0 || activeCompany.CompanyId != -1)
                {
                    bool found = false;

                    // get all of the MDI children in an array

                    Form[] charr = this.MdiChildren;

                    if (charr.Length == 0) // no child form is opened
                    {
                        EditCompanyDetails childForm = new EditCompanyDetails();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                    else // child forms are opened
                    {

                        foreach (Form chform in charr)
                        {
                            if (chform.Name == "EditCompanyDetails")
                            // one instance of the form is already opened
                            {
                                chform.Activate();
                                found = true;
                                break; // exit loop

                            }
                            else
                                found = false; // make sure flag is set to

                            // false if the form is not found

                        }

                        if (found == false)
                        {
                            EditCompanyDetails childForm = new EditCompanyDetails();
                            childForm.MdiParent = this;
                            // The StartPosition property is essential

                            // for the location property to work

                            childForm.StartPosition = FormStartPosition.CenterScreen;
                            childForm.Location = new Point(0, 0);
                            childForm.Show();
                        }
                    }
                }
                else
                {
                    bool found = false;

                    // get all of the MDI children in an array

                    Form[] charr = this.MdiChildren;

                    if (charr.Length == 0) // no child form is opened
                    {
                        AddCompanyDetails childForm = new AddCompanyDetails();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                    else // child forms are opened
                    {

                        foreach (Form chform in charr)
                        {
                            if (chform.Name == "AddCompanyDetails")
                            // one instance of the form is already opened
                            {
                                chform.Activate();
                                found = true;
                                break; // exit loop

                            }
                            else
                                found = false; // make sure flag is set to

                            // false if the form is not found

                        }

                        if (found == false)
                        {
                            AddCompanyDetails childForm = new AddCompanyDetails();
                            childForm.MdiParent = this;
                            // The StartPosition property is essential

                            // for the location property to work

                            childForm.StartPosition = FormStartPosition.CenterScreen;
                            childForm.Location = new Point(0, 0);
                            childForm.Show();
                        }
                    }
                }
            }
            catch { }
        }

        private void smnuResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmResetPassword childForm = new frmResetPassword();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmResetPassword")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmResetPassword childForm = new frmResetPassword();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void smnuChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmChangePassword childForm = new frmChangePassword();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmChangePassword")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmChangePassword childForm = new frmChangePassword();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        // User Role Management Form
        private void smnuRoles_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmRole childForm = new frmRole();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmRole")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmRole childForm = new frmRole();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        // User Rights Form
        private void smnuUserRights_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmUserRole childForm = new frmUserRole();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmUserRole")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmUserRole childForm = new frmUserRole();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        //Form Theme Settings
        private void smnuThemeSettings_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;

                // get all of the MDI children in an array

                Form[] charr = this.MdiChildren;

                if (charr.Length == 0)      // no child form is opened
                {
                    frmTheme childForm = new frmTheme();
                    childForm.MdiParent = this;
                    // The StartPosition property is essential

                    // for the location property to work

                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Location = new Point(0, 0);
                    childForm.Show();
                }
                else      // child forms are opened
                {

                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "frmTheme")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop

                        }
                        else
                            found = false;      // make sure flag is set to

                        // false if the form is not found

                    }

                    if (found == false)
                    {
                        frmTheme childForm = new frmTheme();
                        childForm.MdiParent = this;
                        // The StartPosition property is essential

                        // for the location property to work

                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Location = new Point(0, 0);
                        childForm.Show();
                    }
                }
            }
            catch { }
        }

        private void toolStripLogout_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                isQuit = MessageBox.Show("Do You Want to Logout?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (isQuit == DialogResult.Yes)
                {
                    ActiveUsers _activeUsers = new ActiveUsers();
                    TransactionResult removeUserResult = _activeUsers.RemoveActiveUser(MDIForm.UserID);
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(_userName, true);
                    if (key != null)
                        Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(_userName);


                    Application.Restart();
                }
            }
            catch { }
        }
        // Exit 
        private void tstripExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult isQuit;
                isQuit = MessageBox.Show("Do You Really Want to Close The Application?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (isQuit == DialogResult.Yes)
                {
                    ActiveUsers _activeUsers = new ActiveUsers();
                    TransactionResult removeUserResult = _activeUsers.RemoveActiveUser(MDIForm.UserID);
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(_userName, true);
                    if (key != null)
                        Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(_userName);
                    Application.Exit();
                }
            }
            catch { }
        }

        private void tstripHelp_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F1}");
        }

        private void MDIPCS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = (e.CloseReason == CloseReason.UserClosing && MessageBox.Show("Do You Really Want to Close The Application?", "SoftwareName", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.Yes);
                if (e.Cancel == false)
                {
                    ActiveUsers _activeUsers = new ActiveUsers();
                    TransactionResult removeUserResult = _activeUsers.RemoveActiveUser(MDIForm.UserID);
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(_userName, true);
                    if (key != null)
                        Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(_userName);
                    Application.Exit();
                }
            }
            catch { }
        }

        private void MDIPCS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method(s)

        private void GetCurrentServerDateTime()
        {
            _serverDateTime = Utility.GetServerDate(_ApplicationConnection);
        }

        private void SetMenuForUser()
        {
            int tCount = 0;

            MDIMenu objMDIMenu1 = new MDIMenu();

            _userName = objMDIMenu1.GetUserName(_userID);
            //_CompanyName = objMDIMenu1.GetCompanyName();
            _isDoctor = objMDIMenu1.IsUserADoctor(_userID);

            tCount = objMDIMenu1.GetCountOfMenuItems();

            tCount = tCount + 1; //to ignore the zeroth element of the array ToolStripMenuItem & consider from 1.
            if (tCount > 0)
            {
                MenuStrip menuPCS = new MenuStrip();
                ToolStripMenuItem[] menuItemPCS = new ToolStripMenuItem[tCount];
                ToolStripMenuItem[] menuSubItemPCS = new ToolStripMenuItem[tCount];
                DataSet ds2 = null;
                MDIMenu objMDIMenu2 = new MDIMenu();
                ds2 = objMDIMenu2.GetTopMenuItems(_userID);

                tstripMenuIcons.Items.Clear();
                foreach (DataRow dRow in ds2.Tables[0].Rows)
                {
                    ToolStripMenuItem tempItem = new ToolStripMenuItem();
                    tempItem.Text = dRow["Name"].ToString();
                    tempItem.Font = new Font("Verdana", 8, FontStyle.Bold);
                    tempItem.AutoSize = false;
                    if (tempItem.Text == "Help")
                    {
                        tempItem.Size = new System.Drawing.Size(60, 20);
                    }
                    else
                    {
                        tempItem.Size = new System.Drawing.Size(100, 20);
                    }

                    switch (dRow["Name"].ToString())
                    {

                        case "Clients":
                            tstripMenuIcons.Items.Add(tstripCustomersBlank1);
                            tstripMenuIcons.Items.Add(tstripCustomers);
                            tstripMenuIcons.Items.Add(tstripCustomersBlank1);
                            tstripSeparator1.Width = tstripSeparator1.Width - 100;
                            break;
                        case "Invoice":
                            tstripMenuIcons.Items.Add(tstripInvoice);
                            tstripMenuIcons.Items.Add(tstripInvoiceBlank2);
                            tstripSeparator1.Width = tstripSeparator1.Width - 100;
                            break;

                        case "Reports":
                            tstripSeparator1.Width = tstripSeparator1.Width - 100;
                            break;
                        case "Help":
                            tstripMenuIcons.Items.Add(tstripHelpBlank1);
                            tstripMenuIcons.Items.Add(tstripHelp);
                            tstripMenuIcons.Items.Add(tstripHelpBlank2);
                            tstripSeparator1.Width = tstripSeparator1.Width - 60;
                            break;
                        case "Administration":
                            tstripMenuIcons.Items.Add(tstripAdministrationBlank);
                            tstripSeparator1.Width = tstripSeparator1.Width - 96;
                            break;
                    }
                    menuItemPCS[Convert.ToInt32(dRow["MenuID"])] = tempItem;
                    menuPCS.Items.Add(menuItemPCS[Convert.ToInt32(dRow["MenuID"])]);

                }
                tstripMenuIcons.Items.Add(tstripSeparator1);
                tstripMenuIcons.Items.Add(toolStripLogout);
                tstripMenuIcons.Items.Add(tstripExit);
                ds2 = objMDIMenu2.GetSubMenuItems(_userID);
                foreach (DataRow dRow in ds2.Tables[0].Rows)
                {
                    ToolStripMenuItem tempItem = new ToolStripMenuItem();
                    tempItem.Text = dRow["Name"].ToString();
                    switch (dRow["MenuName"].ToString())
                    {

                        case "smnuClients":
                            tempItem.Click += new EventHandler(smnuClients_Click);
                            tstripCustomers.Click += new EventHandler(smnuClients_Click);
                            tstripCustomers.ImageScaling = ToolStripItemImageScaling.None;

                            tstripCustomers.Visible = true;
                            tstripCustomersBlank1.Width = tstripCustomersBlank1.Width - _imgWidth;
                            tstripCustomers.Enabled = true;
                            break;
                        case "smnuManageSupplier":
                            tempItem.Click += new EventHandler(smnuManageSupplier_Click);
                            toolStripLabel3.Click += new EventHandler(smnuManageSupplier_Click);
                            toolStripLabel3.ImageScaling = ToolStripItemImageScaling.None;

                            toolStripLabel3.Visible = true;
                            toolStripLabel3.Width = toolStripLabel3.Width - _imgWidth;
                            toolStripLabel3.Enabled = true;
                            break;

                        case "smnuManageEmployee":
                            tempItem.Click += new EventHandler(smnuManageEmployee_Click);
                            toolStripLabel4.Click += new EventHandler(smnuManageEmployee_Click);
                            toolStripLabel4.ImageScaling = ToolStripItemImageScaling.None;

                            toolStripLabel4.Visible = true;
                            toolStripLabel4.Width = toolStripLabel4.Width - _imgWidth;
                            toolStripLabel4.Enabled = true;
                            break;

                        case "smnuEntryCheque":
                            tempItem.Click += new EventHandler(smnuEntryCheque_Click);
                            toolStripLabel5.Click += new EventHandler(smnuEntryCheque_Click);
                            toolStripLabel5.ImageScaling = ToolStripItemImageScaling.None;

                            toolStripLabel5.Visible = true;
                            toolStripLabel5.Width = toolStripLabel4.Width - _imgWidth;
                            toolStripLabel5.Enabled = true;
                            break;

                        case "smnuInvoice":
                            tempItem.Click += new EventHandler(smnuInvoice_Click);
                            tstripInvoice.Click += new EventHandler(smnuInvoice_Click);
                            tstripInvoice.ImageScaling = ToolStripItemImageScaling.None;
                            tstripInvoice.Enabled = true;
                            break;
                        case "smnuInvoicesReport":
                            tempItem.Click += new EventHandler(smnuInvoicesReport_Click);
                            break;
                        case "smnuStock":
                            tempItem.Click += new EventHandler(smnuStock_Click);
                            break;
                        case "smnuEstimate":
                            tempItem.Click += new EventHandler(smnuEstimate_Click);
                            break;

                        case "smnuPurchaseOrder":
                            tempItem.Click += new EventHandler(smnuPurchaseOrder_Click);
                            tstripInvoice.Click += new EventHandler(smnuPurchaseOrder_Click);
                            tstripInvoice.ImageScaling = ToolStripItemImageScaling.None;
                            tstripInvoice.Enabled = true;
                            break;

                        case "smnuTax":
                            tempItem.Click += new EventHandler(smnuTax_Click);
                            break;

                        case "smnuRegistrationReport":
                            //tempItem.Click += new EventHandler(smnuRegistrationReport_Click);
                            break;

                        case "smnuHelpContents":
                            tempItem.Click += new EventHandler(smnuHelpContents_Click);
                            tstripHelp.Click += new EventHandler(smnuHelpContents_Click);
                            tstripHelp.ImageScaling = ToolStripItemImageScaling.None;

                            tstripHelp.Visible = true;
                            tstripHelpBlank1.Width = tstripHelpBlank1.Width - _imgWidth;
                            tstripHelp.Enabled = true;
                            break;
                        case "smnuHelpAbout":
                            tempItem.Click += new EventHandler(smnuHelpAbout_Click);
                            break;


                        case "smnuBillDescriptions":
                            tempItem.Click += new EventHandler(smnuBillDescriptions_Click);
                            break;
                        case "smnuUnits":
                            tempItem.Click += new EventHandler(smnuUnits_Click);
                            break;

                        case "smnuRoleDescription":
                            tempItem.Click += new EventHandler(smnuRoleDescription_Click);
                            break;

                        case "smnuCSCity":
                            tempItem.Click += new EventHandler(smnuCSCity_Click);
                            break;
                        case "smnuUsers":
                            tempItem.Click += new EventHandler(smnuUsers_Click);
                            break;
                        case "smnuCompanyInformation":
                            tempItem.Click += new EventHandler(smnuCompanyInformation_Click);
                            break;
                        case "smnuResetPassword":
                            tempItem.Click += new EventHandler(smnuResetPassword_Click);
                            break;
                        case "smnuChangePassword":
                            tempItem.Click += new EventHandler(smnuChangePassword_Click);
                            break;
                        case "smnuRoles":
                            tempItem.Click += new EventHandler(smnuRoles_Click);
                            break;
                        case "smnuUserRights":
                            tempItem.Click += new EventHandler(smnuUserRights_Click);
                            break;
                        case "smnuThemeSettings":
                            tempItem.Click += new EventHandler(smnuThemeSettings_Click);
                            break;
                        case "smnuProduct":
                            tempItem.Click += new EventHandler(smnuProduct_Click);
                            break;
                        case "smnuAttendance":
                            tempItem.Click += new EventHandler(smnuAttendance_Click);
                            break;                            
                        case "smnuProductMaterial":
                            tempItem.Click += new EventHandler(smnuProductMaterial_Click);
                            break;
                        case "smnuBankDetails":
                            tempItem.Click += new EventHandler(smnuBankDetails_Click);
                            break;
                        case "smnuCreditDebit":
                            tempItem.Click += new EventHandler(smnuCreditDebit_Click);
                            break;



                    }
                    menuSubItemPCS[Convert.ToInt32(dRow["MenuID"])] = tempItem;
                    if (menuItemPCS[Convert.ToInt32(dRow["ParentMenuID"])] == null)
                    {
                        menuSubItemPCS[Convert.ToInt32(dRow["ParentMenuID"])].DropDownItems.Add(menuSubItemPCS[Convert.ToInt32(dRow["MenuID"])]);
                    }
                    else
                    {
                        menuItemPCS[Convert.ToInt32(dRow["ParentMenuID"])].DropDownItems.Add(menuSubItemPCS[Convert.ToInt32(dRow["MenuID"])]);
                    }
                }
                this.Controls.Add(menuPCS);
                ds2 = null;
            }
        }

        #endregion

    }
}
