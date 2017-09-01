using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class PurchaseOrderReport : Form
    {
        private PurchaseOrder PurchaseOrderervice = new PurchaseOrder();
		private PurchaseOrderProduct PurchaseOrderProductService = new PurchaseOrderProduct();
        private Client clientService = new Client();
        int currentPage = 1;
        int TotalPage = 0;

        public PurchaseOrderReport()
        {
            InitializeComponent();
        }

        private void PurchaseOrderReport_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            BindClientName();
            BindPaymentStatus();
            SetDefaultDates();
            BindPurchaseOrderReportsDataGrid();            
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

        private void btnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            AddEditPurchaseOrder addEditPurchaseOrder = new AddEditPurchaseOrder();
            addEditPurchaseOrder.StartPosition = FormStartPosition.CenterParent;
            addEditPurchaseOrder.ShowDialog(this);
            BindPurchaseOrderReportsDataGrid();
        }

        private void BindPurchaseOrderReportsDataGrid()
        {
            int resultsPerPage = Convert.ToInt32(txtResultsPerPage.Text);
            List<PurchaseOrder> PurchaseOrderList = PurchaseOrderervice.GetAllPurchaseOrderList();

            foreach (PurchaseOrder PurchaseOrder in PurchaseOrderList)
            {
				PurchaseOrder.PurchaseOrderProductList = PurchaseOrderProductService.GetAllPurchaseOrderProductList().Where(v => v.PurchaseOrderId == PurchaseOrder.PurchaseOrderId).ToList<PurchaseOrderProduct>();
            }


            int clientId = Convert.ToInt32(cmbClientName.SelectedValue);

            if (clientId != 0)
                PurchaseOrderList = (from PurchaseOrder in PurchaseOrderList
                                 .Where(v => v.ClientId == clientId)
                               select PurchaseOrder).ToList<PurchaseOrder>();

            if (!String.IsNullOrEmpty(txtPurchaseOrderNumber.Text))
                PurchaseOrderList = (from PurchaseOrder in PurchaseOrderList
                                 .Where(v => v.PurchaseOrderId == Convert.ToInt32(txtPurchaseOrderNumber.Text))
                               select PurchaseOrder).ToList<PurchaseOrder>();

            //if (cmbStatus.SelectedIndex != 0)
            //    PurchaseOrderList = (from PurchaseOrder in PurchaseOrderList
            //                     .Where(v => v.PaymentStatus.Equals(cmbStatus.Text, StringComparison.OrdinalIgnoreCase))
            //                   select PurchaseOrder).ToList<PurchaseOrder>();

            if (!String.IsNullOrEmpty(dtpIssueBetn1.Value.ToString()) && !String.IsNullOrEmpty(dtpissueBetn2.Value.ToString()))
            {
                PurchaseOrderList = (from PurchaseOrder in PurchaseOrderList
                                 .Where(v => v.IssueDate.Date >= Convert.ToDateTime(dtpIssueBetn1.Value).Date && v.IssueDate.Date <= Convert.ToDateTime(dtpissueBetn2.Value).Date)
                               select PurchaseOrder).ToList<PurchaseOrder>();
            }

            if (dtpDueBetn1.Text != "__ /__ /____" && dtpDueBetn2.Text != "__ /__ /____")
            {
                PurchaseOrderList = (from PurchaseOrder in PurchaseOrderList
                                 .Where(v => v.DueDate.Date >= Convert.ToDateTime(dtpDueBetn1.Value).Date && v.DueDate.Date <= Convert.ToDateTime(dtpDueBetn2.Value).Date)
                               select PurchaseOrder).ToList<PurchaseOrder>();
            }

            int totalRecords = PurchaseOrderList.Count;
            CalculateTotalPages(totalRecords);
            int srNo = 0;

            var columns = from PurchaseOrder in PurchaseOrderList
                          join client in clientService.GetAllClientsList()
                          on PurchaseOrder.ClientId equals client.ClientId
                          select new
                          {
                              No = ++srNo,
                              ClientName = client.ClientName,
                              PurchaseOrderNo = PurchaseOrder.PurchaseOrderId,
                              IssueDate = PurchaseOrder.IssueDate,
                              DueDate = PurchaseOrder.DueDate,
                              Amount = PurchaseOrder.PurchaseOrderProductList.Sum(v => v.TotalPrice),
                              Tax = PurchaseOrder.PurchaseOrderProductList.Sum(v => v.TaxValue),
                              Total = PurchaseOrder.TotalAmount,
                              Status = PurchaseOrder.PaymentStatus,
                              PrivateNotes = PurchaseOrder.PrivateNotes,
                              AmountPaid = PurchaseOrder.AmountPaid,
                              Balance = PurchaseOrder.TotalAmount - PurchaseOrder.AmountPaid
                          };

            if (currentPage == 1)
            {
                this.dgvPurchaseOrder.DataSource = columns.Take(resultsPerPage).ToList();
            }
            else
            {
                int skipRecordsNo = resultsPerPage * (currentPage - 1);
                this.dgvPurchaseOrder.DataSource = columns.Skip(skipRecordsNo).Take(resultsPerPage).ToList();
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
            BindPurchaseOrderReportsDataGrid();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
                currentPage--;

            BindPurchaseOrderReportsDataGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPage)
                currentPage++;

            BindPurchaseOrderReportsDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindPurchaseOrderReportsDataGrid();
        }
    }
}
