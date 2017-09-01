using System;
using System.Windows.Forms;
using ERP.CommonLayer;
using ERP.DataLayer;


namespace ERPWinApp
{
    public partial class EditTax : Form
    {
        private Tax masterService = new Tax();
        public int TaxId = 0;
        public eFormsState formsState;

        public EditTax()
        {
            InitializeComponent();
        }

        private void EditTax_Load(object sender, EventArgs e)
        {
            try
            {
                Common.SetDialogCoordinate(this);

                if (TaxId != 0)
                {
                    ShowSelectedTaxData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void ShowSelectedTaxData()
        {
            Tax taxRecord = new Tax(TaxId);
            txtTaxName.Text = taxRecord.TaxName;
            txtTaxPercentage.Text = Convert.ToString(taxRecord.TaxPercentage);

            if (formsState == eFormsState.View)
            {
                DisableControls();
            }
        }

        private void DisableControls()
        {
            txtTaxName.Enabled = false;
            txtTaxPercentage.Enabled = false;            
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tax tax = new Tax();
            tax.TaxId = TaxId;
            tax.TaxName = txtTaxName.Text.Trim();
            tax.TaxPercentage = Convert.ToDecimal(txtTaxPercentage.Text);
            TransactionResult result = null;
            result = tax.Commit(ScreenMode.Edit);

            CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_TAX_SAVE_MESSAGE, txtTaxName.Text),
                                                              Constants.CONSTANT_INFORMATION,
                                                              CustomMessageBox.eDialogButtons.OK,
                                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
            this.Close();
        }
    }
}
