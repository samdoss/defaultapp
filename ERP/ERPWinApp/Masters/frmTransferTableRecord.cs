using ERP.CommonLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPWinApp.Masters
{
    public partial class frmTransferTableRecord : Form
    {
        public frmTransferTableRecord()
        {
            InitializeComponent();
        }

        private void dgvSearchRecords_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            
            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void dgvSearchRecords_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvSearchRecords.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    lblTableMemberID.Text = dgvSearchRecords.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DataGridViewCell cell = dgvSearchRecords[0, e.RowIndex];
                    if (cell.OwningColumn is DataGridViewRadioButtonColumn)
                    {
                        if (cell.FormattedValue.ToString().Length == 0)
                        {
                            for (int i = 0; i < dgvSearchRecords.RowCount; i++)
                            {
                                dgvSearchRecords[0, i].Value = string.Empty;
                            }
                            cell.Value = "Selected";
                        }
                    }

                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmTransferRequestMaster frmTransferRequest = new frmTransferRequestMaster();
            frmTransferRequest.ShowDialog();
            //LoadGridViewData(txtSearchKeyword.Text, 1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridViewData(txtSearchKeyword.Text, 1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //frmTransferRequestMaster frmTransferRequest = new frmTransferRequestMaster();
            //frmTransferRequest.FormMode = "EDIT";
            //frmTransferRequest.TransferRequestID = Convert.ToInt32(lblTableMemberID.Text);
            //frmTransferRequest.ShowDialog();
            //LoadGridViewData(txtSearchKeyword.Text, 1);
        }

        private void LoadGridViewData(string searchKeyword, int searchOption)
        {
            //dgvSearchRecords.Rows.Clear();
            //DataSet dsRecord = new DataSet();
            //TransferRequestDL cmDL = new TransferRequestDL();
            //dsRecord = cmDL.GetFindTransferRequestList(searchKeyword, searchOption);
            //int rowCount = 0;
            //if (dsRecord.Tables.Count > 0)
            //{
            //    if (dsRecord.Tables[0].Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dsRecord.Tables[0].Rows)
            //        {
            //            dgvSearchRecords.Rows.Add();
            //            dgvSearchRecords.Rows[rowCount].Cells[1].Value = rowCount + 1;
            //            dgvSearchRecords.Rows[rowCount].Cells[2].Value = Convert.ToString(row["TransferRequestID"].ToString());
            //            dgvSearchRecords.Rows[rowCount].Cells[3].Value = Convert.ToString(row["TableName"].ToString());
                        
            //            rowCount++;
            //        }
            //    }
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
