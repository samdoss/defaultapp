using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.CommonLayer;
using ERP.DataLayer;


namespace ERPWinApp
{
    public partial class AddEditProduct : Form
    {
		private Tax masterService = new Tax();
        public int productID = 0;
        public eFormsState formsState;

        public AddEditProduct()
        {
            InitializeComponent();
        }

        private void AddEditProduct_Load(object sender, EventArgs e)
        {
            try
            {
                Common.SetDialogCoordinate(this);
                LoadTaxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void LoadTaxes()
        {
            var lstTax = (from tax in masterService.GetAllTaxList()
                                .Where(v => v.Status == true)
                                select new Tax {
                                        TaxId = tax.TaxId,
                                        TaxName = tax.TaxName + " (" + tax.TaxPercentage + ")"                                
                                    }).ToList();

            lstTax.Insert(0, new Tax(0, "-- Select Tax --"));
            cmbTaxRate.DataSource = lstTax;
            cmbTaxRate.DisplayMember = "TaxName";
            cmbTaxRate.ValueMember = "TaxId";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = txtProductName.Text.Trim();
                product.Description = txtProdDesc.Text.Trim();
                //product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                //product.Quantity = Convert.ToInt32(txtQuantity.Text);
				//product.TaxId = Convert.ToInt32(cmbTaxRate.SelectedValue);
                product.Status = true;

                if (productID == 0)
                {
	                TransactionResult result = null;
					result = product.Commit(ScreenMode.Add);

					int productId = product.ProductId;
                    ResetControls();
                    CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_PRODUCT, txtProductName.Text),
                                                              Constants.CONSTANT_INFORMATION,
                                                              CustomMessageBox.eDialogButtons.OK,
                                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
                }
                else
                {
                    product.ProductId = productID;
					TransactionResult result = null;
					result = product.Commit(ScreenMode.Edit);
	                
                    CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtProductName.Text),
                                                                  Constants.CONSTANT_INFORMATION,
                                                                  CustomMessageBox.eDialogButtons.OK,
                                                                  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void ResetControls()
        {
            txtProductName.Text = String.Empty;
            txtProdDesc.Text = String.Empty;
            txtUnitPrice.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            cmbTaxRate.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
    }
}
