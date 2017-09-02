using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class EstimateReport : Form
    {
        private Estimate Estimateervice = new Estimate();
		private EstimateProduct EstimateProductService = new EstimateProduct();
        private Client clientService = new Client();
        int currentPage = 1;
        int TotalPage = 0;

        public EstimateReport()
        {
            InitializeComponent();
        }

        private void EstimateReport_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            BindClientName();
            BindPaymentStatus();
            SetDefaultDates();
            BindEstimateReportsDataGrid();            
        }

        private void SetDefaultDates()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            dtpIssueBetn1.Value = startDate.Date;
            dtpissueBetn2.Value = endDate.Date;
        }

        private void BindClientName()
        {
            List<Client> clientList = clientService.GetAllClientsList();
            clientList.Insert(0, new Client(0, "-- Select Client Name --"));
            cmbClientName.DataSource = clientList;
            cmbClientName.DisplayMember = "ClientName";
            cmbClientName.ValueMember = "ClientId";
        }

        private void BindPaymentStatus()
        {
            List<PaymentStatus> lstPaymentStatus = new List<PaymentStatus>();
            lstPaymentStatus.Insert(0, new PaymentStatus(0, ePaymentStatus.All.ToString()));
            lstPaymentStatus.Insert(1, new PaymentStatus(0, ePaymentStatus.Paid.ToString()));
            lstPaymentStatus.Insert(2, new PaymentStatus(0, ePaymentStatus.Unpaid.ToString()));
            lstPaymentStatus.Insert(3, new PaymentStatus(0, ePaymentStatus.Partial.ToString()));
            lstPaymentStatus.Insert(4, new PaymentStatus(0, ePaymentStatus.Overdue.ToString()));
            cmbStatus.DataSource = lstPaymentStatus;
            cmbStatus.DisplayMember = "PaymentStatusName";
            cmbStatus.ValueMember = "PaymentStatusId";
        }

        private void btnNewEstimate_Click(object sender, EventArgs e)
        {
            AddEditEstimate addEditEstimate = new AddEditEstimate();
            addEditEstimate.StartPosition = FormStartPosition.CenterParent;
            addEditEstimate.ShowDialog(this);
            BindEstimateReportsDataGrid();
        }

        private void BindEstimateReportsDataGrid()
        {
            int resultsPerPage = Convert.ToInt32(txtResultsPerPage.Text);
            List<Estimate> EstimateList = Estimateervice.GetAllEstimateList();

            foreach (Estimate Estimate in EstimateList)
            {
				Estimate.EstimateProductList = EstimateProductService.GetAllEstimateProductList().Where(v => v.EstimateId == Estimate.EstimateId).ToList<EstimateProduct>();
            }


            int clientId = Convert.ToInt32(cmbClientName.SelectedValue);

            if (clientId != 0)
                EstimateList = (from Estimate in EstimateList
                                 .Where(v => v.ClientId == clientId)
                               select Estimate).ToList<Estimate>();

            if (!String.IsNullOrEmpty(txtEstimateNumber.Text))
                EstimateList = (from Estimate in EstimateList
                                 .Where(v => v.EstimateId == Convert.ToInt32(txtEstimateNumber.Text))
                               select Estimate).ToList<Estimate>();

            //if (cmbStatus.SelectedIndex != 0)
            //    EstimateList = (from Estimate in EstimateList
            //                     .Where(v => v.PaymentStatus.Equals(cmbStatus.Text, StringComparison.OrdinalIgnoreCase))
            //                   select Estimate).ToList<Estimate>();

            if (!String.IsNullOrEmpty(dtpIssueBetn1.Value.ToString()) && !String.IsNullOrEmpty(dtpissueBetn2.Value.ToString()))
            {
                EstimateList = (from Estimate in EstimateList
                                 .Where(v => v.IssueDate.Date >= Convert.ToDateTime(dtpIssueBetn1.Value).Date && v.IssueDate.Date <= Convert.ToDateTime(dtpissueBetn2.Value).Date)
                               select Estimate).ToList<Estimate>();
            }

            if (dtpDueBetn1.Text != "__ /__ /____" && dtpDueBetn2.Text != "__ /__ /____")
            {
                EstimateList = (from Estimate in EstimateList
                                 .Where(v => v.DueDate.Date >= Convert.ToDateTime(dtpDueBetn1.Value).Date && v.DueDate.Date <= Convert.ToDateTime(dtpDueBetn2.Value).Date)
                               select Estimate).ToList<Estimate>();
            }

            int totalRecords = EstimateList.Count;
            CalculateTotalPages(totalRecords);
            int srNo = 0;

            var columns = from Estimate in EstimateList
                          join client in clientService.GetAllClientsList()
                          on Estimate.ClientId equals client.ClientId
                          select new
                          {
                              No = ++srNo,
                              ClientName = client.ClientName,
                              EstimateNo = Estimate.EstimateId,
                              IssueDate = Estimate.IssueDate,
                              DueDate = Estimate.DueDate,
                              Amount = Estimate.EstimateProductList.Sum(v => v.TotalPrice),
                              Tax = Estimate.EstimateProductList.Sum(v => v.TaxValue),
                              Total = Estimate.TotalAmount,
                              Status = Estimate.PaymentStatus,
                              PrivateNotes = Estimate.PrivateNotes,
                              AmountPaid = Estimate.AmountPaid,
                              Balance = Estimate.TotalAmount - Estimate.AmountPaid
                          };

            if (currentPage == 1)
            {
                this.dgvEstimate.DataSource = columns.Take(resultsPerPage).ToList();
            }
            else
            {
                int skipRecordsNo = resultsPerPage * (currentPage - 1);
                this.dgvEstimate.DataSource = columns.Skip(skipRecordsNo).Take(resultsPerPage).ToList();
            }

            if (currentPage <= TotalPage)
            {
                txtPageEnd.Visible = true;
                txtPageStart.Visible = true;
                btnLeft.Visible = true;
                btnRight.Visible = true;
                lblSeperator.Visible = true;
                txtPageStart.Text = Convert.ToString(currentPage);
                txtPageEnd.Text = Convert.ToString(TotalPage);
                txtPageEnd.Enabled = false;

                if (currentPage == 1)
                {
                    btnLeft.Enabled = false;
                    btnRight.Enabled = true;
                }
                else if (currentPage == TotalPage)
                {
                    btnRight.Enabled = false;
                    btnLeft.Enabled = true;
                }
                else
                {
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                }

                if (TotalPage == 1)
                {
                    txtPageEnd.Visible = false; ;
                    txtPageStart.Visible = false;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    lblSeperator.Visible = false;
                }
            }
        }

        private void CalculateTotalPages(int rowCount)
        {
            int pageSize = Convert.ToInt32(txtResultsPerPage.Text);
            TotalPage = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                TotalPage += 1;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindEstimateReportsDataGrid();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
                currentPage--;

            BindEstimateReportsDataGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPage)
                currentPage++;

            BindEstimateReportsDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindEstimateReportsDataGrid();
        }
    }
}
